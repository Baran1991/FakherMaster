using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fakher.Core.DomainModel;
using Fakher.Core.DomainModel.Order;
using Fakher.Core.Website;
using Telerik.Web.UI;
using rComponents;

public partial class Student_Shop_Buy : Page
{
    private List<int> mSelectedToolIds
    {
        get { return Session["ShopSelectedToolIds"] as List<int>; }
        set { Session["ShopSelectedToolIds"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        bool setting = WebsiteManager.GetAppSetting<bool>(WebsiteHandler.BookShopKey);
        if(!setting)
        {
            Response.Redirect("~/Student/Default.aspx", true);
            return;
        }

        if (!IsPostBack)
        {
            Fill();
        }
    }

    private void Fill()
    {
        RadGrid1.DataSource = WebsiteHandler.CurrentStudent.GetUsableGroupToolsForWebsite();
        RadGrid1.DataBind();

        IList<EducationalTool> selectedTools = GetSelectedTools();
        RadGrid2.DataSource = selectedTools;
        RadGrid2.DataBind();

        lblPayableAmout.Text = selectedTools.Sum(x => x.LastSellPrice).ToString("C0");
    }

    private IList<EducationalTool> GetSelectedTools()
    {
        List<EducationalTool> list = new List<EducationalTool>();
        if (mSelectedToolIds != null)
            foreach (int id in mSelectedToolIds)
            {
                EducationalTool tool = EducationalTool.FromId(id);
                list.Add(tool);
            }
        return list;
    }

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            Label lbl = e.Item.FindControl("lblIndex") as Label;
            lbl.Text = e.Item.ItemIndex + 1 + "";
            e.Item.Font.Name = "Tahoma";

            RadButton btnAddToCart = e.Item.FindControl("btnAddToCart") as RadButton;
            if (btnAddToCart != null)
                btnAddToCart.CommandArgument = HttpServerUtility.UrlTokenEncode(Encoding.UTF8.GetBytes((e.Item.DataItem as EducationalTool).Id + ""));

            RadButton btnRemove = e.Item.FindControl("btnRemove") as RadButton;
            if (btnRemove != null)
                btnRemove.CommandArgument = HttpServerUtility.UrlTokenEncode(Encoding.UTF8.GetBytes((e.Item.DataItem as EducationalTool).Id + ""));
        }
    }

    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        RadButton button = sender as RadButton;
        if (string.IsNullOrEmpty(button.CommandArgument))
        {
            rMessageBox1.ShowInformation("یک کتاب را ابتدا انتخاب کنید.");
            return;
        }

        if (mSelectedToolIds == null)
            mSelectedToolIds = new List<int>();

        try
        {
            string idText = Encoding.UTF8.GetString(HttpServerUtility.UrlTokenDecode(button.CommandArgument));
            int id = Convert.ToInt32(idText);
            EducationalTool tool = EducationalTool.FromId(id);

            if (mSelectedToolIds.Contains(tool.Id))
                throw new MessageException("این کتاب قبلا افزوده شده است.");

            if (!WebsiteHandler.CurrentStudent.CanUse(tool, UseType.Buy, 1))
                throw new MessageException("امکان فروش این کتاب برای شما وجود ندارد.");

            mSelectedToolIds.Add(tool.Id);
        }
        catch (MessageException ex)
        {
            rMessageBox1.ShowInformation(ex.Message);
            return;
        }
        catch (Exception ex)
        {
            WebsiteManager.SaveException(this, ex);
            rMessageBox1.ShowInformation("امکان فروش این کتاب در حال حاضر وجود ندارد.");
            return;
        }

        Fill();
    }

    protected void btnRemove_Click(object sender, EventArgs e)
    {
        RadButton button = sender as RadButton;
        if (string.IsNullOrEmpty(button.CommandArgument))
        {
            rMessageBox1.ShowInformation("یک کتاب را ابتدا انتخاب کنید.");
            return;
        }
        if (mSelectedToolIds == null)
            return;


        string idText = Encoding.UTF8.GetString(HttpServerUtility.UrlTokenDecode(button.CommandArgument));
        int id = Convert.ToInt32(idText);
        EducationalTool tool = EducationalTool.FromId(id);
        mSelectedToolIds.Remove(tool.Id);
        Fill();
    }

    protected void btnPay_Click(object sender, EventArgs e)
    {
        try
        {
            if (mSelectedToolIds == null || mSelectedToolIds.Count == 0)
            {
                rMessageBox1.ShowInformation("ابتدا کتاب های موردنظر خود را به سبد خرید اضافه کنید.");
                return;
            }

            Order order = new Order {Person = WebsiteHandler.CurrentPerson};
            foreach (int id in mSelectedToolIds)
            {
                EducationalTool tool = EducationalTool.FromId(id);
                order.AddItem(tool);
            }

            if (order.PayableAmount == 0)
                throw new MessageException("مبلغ سفارش معتبر نیست");

            order.Save();
            WebsiteHandler.CurrentOrder = order;

            WebsiteHandler.CurrentOrder.GenerateCode();
            WebsiteHandler.CurrentOrder.FinancialDocument = new FinancialDocument();
            WebsiteHandler.CurrentOrder.FinancialDocument.Person = WebsiteHandler.CurrentPerson;
            WebsiteHandler.CurrentOrder.FinancialDocument.Description = "خرید آنلاین جزوه و کتاب شماره " + WebsiteHandler.CurrentOrder.Code;

            FinancialItem financialItem = new FinancialItem(FinancialType.Debt);
            financialItem.Text = "خرید آنلاین جزوه و کتاب شماره " + WebsiteHandler.CurrentOrder.Code;
            financialItem.Amount = WebsiteHandler.CurrentOrder.PayableAmount;

            WebsiteHandler.CurrentOrder.FinancialDocument.AddItem(financialItem);
            WebsiteHandler.CurrentOrder.Save();

            MellatPayTransaction payTransaction = new MellatPayTransaction();
            payTransaction.Person = WebsiteHandler.CurrentStudent;
            payTransaction.Amount = WebsiteHandler.CurrentOrder.PayableAmount;
            payTransaction.Description = "خرید آنلاین جزوه و کتاب شماره " + WebsiteHandler.CurrentOrder.Code;

            PayTransactionItem item = new PayTransactionItem();
            item.Type = PayTransactionItemType.ElectronicPayment;
            item.Amount = WebsiteHandler.CurrentOrder.PayableAmount;
            item.FinancialDocument = WebsiteHandler.CurrentOrder.FinancialDocument;
            item.Text = "پرداخت آنلاین خرید شماره " + WebsiteHandler.CurrentOrder.Code;
            item.Heading = FinancialHeading.ToolSell;

            payTransaction.Items.Add(item);

            // Get Id
            payTransaction.Save();
            WebsiteHandler.CurrentPayTransaction = payTransaction;
            WebsiteHandler.CurrentPayTransaction.Start("http://www.fakher.ac.ir/pageMellatHandler.aspx");
            WebsiteHandler.CurrentPayTransaction.Save();

            WebsiteHandler.CurrentOrder.PayTransaction = payTransaction;
            WebsiteHandler.CurrentOrder.Save();

            WebsiteHandler.ReturnPageUrl = "~/Student/Shop/rptOrderReceipt.aspx";
            Response.Redirect("~/pagePayRequest.aspx", true);
            return;
        }
        catch (MessageException ex)
        {
            rMessageBox1.ShowInformation(ex.Message);
            return;
        }
        catch (PayException ex)
        {
            WebsiteManager.SaveException(this, ex);
            rMessageBox1.ShowInformation("متاسفانه بانک ملت در حال حاضر نمی تواند پاسخگوی شما باشد. لطفا مجددا مراجعه فرمایید. کد [{0}]", false, ex.RawCode);
            return;
        }
        catch (Exception ex)
        {
            WebsiteManager.SaveException(this, ex);
            rMessageBox1.ShowInformation("متاسفانه بانک ملت در حال حاضر نمی تواند پاسخگوی شما باشد. لطفا مجددا مراجعه فرمایید.");
            return;
        }
    }
}
