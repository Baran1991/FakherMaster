using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.ComponentModel;
using Telerik.WinControls.UI;

namespace rComponents
{
    public class rRadDetailForm : rRadForm
    {
        private bool mIsCanceled;

        public List<ControlMapping> ControlMappings { get; set; }
        public List<ControlValidation> ControlValidations {get; set;}
        public bool AutoDataBind { get; set; }
        public bool AutoDialogButtons { get; set; }
        public bool AutoValidate { get; set; }
        public bool IsShowed { get; private set; }
        
        public rRadDetailForm()
        {
            InitializeComponent();
            ControlMappings = new List<ControlMapping>();
            ControlValidations = new List<ControlValidation>();
            AutoDataBind = true;
            AutoValidate = true;
            AutoDialogButtons = true;
            Shown += new EventHandler(rRadDetailForm_Shown);
        }

        void rRadDetailForm_Shown(object sender, EventArgs e)
        {
            IsShowed = true;
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rRadDetailForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "rRadDetailForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "مشخصات";
            this.Load += new System.EventHandler(this.MyDetailForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.rRadDetailForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        } 

        protected virtual void Validate(Control.ControlCollection collection)
        {
            if (collection.Count == 0)
                return;

            foreach (Control control in collection)
            {
                if(control is IValidatableControl)
                {
                    (control as IValidatableControl).Validate();
                }
                Validate(control.Controls);
            }
//
//            foreach (ControlValidation validation in ControlValidations)
//            {
//                validation.Validate();
//            }
        }

        public virtual void BindObjectToControls()
        {
            foreach (ControlMapping mapping in ControlMappings)
            {
                object value = mapping.GetObjectValue();
                PropertyInfo destInfo = mapping.GetControlMember() as PropertyInfo;
                if (value != null && mapping.ConvertNeeded)
                    value = Convert.ChangeType(value, destInfo.PropertyType);
                if (value != null)
                    destInfo.SetValue(mapping.TargetControl, value, null);
                if(value == null && mapping.MapNullValue)
                    destInfo.SetValue(mapping.TargetControl, value, null);
                    
                Tag = mapping.DataObject;
            }
        }

//        public virtual void BindControlsToObject()
//        {
//            foreach (ControlMapping mapping in ControlMappings)
//            {
//                if (!mapping.Control.Enabled)
//                    continue;
//            }
//        }

        public virtual void BindControlsToObject()
        {
            foreach (ControlMapping mapping in ControlMappings)
            {
                try
                {
                    if (!mapping.Control.Enabled)
                        continue;
                    object value = mapping.GetControlValue();
                    PropertyInfo destInfo = mapping.GetObjectMember() as PropertyInfo;

                    if (destInfo == null)
                        throw new Exception(String.Format("Cannot find {0} Property", mapping.ObjectProperty));
                    if (value != null && mapping.ConvertNeeded)
                    {
                        if (mapping.ConvertType == ConvertType.Dynamic)
                            value = Convert.ChangeType(value, destInfo.PropertyType);
                        else
                        {
                            MethodInfo castMethod = destInfo.PropertyType.GetMethod("ByCast");
                            value = castMethod.Invoke(null, new object[] {value});
                        }
                    }
                    destInfo.SetValue(mapping.TargetObject, value, null);
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }

        public void SetProcessingObject(object obj)
        {
            Tag = obj;
        }

        public T GetProcessingObject<T>()
        {
            return (T) Tag;
        }

        protected void CancelClosing()
        {
            DialogResult = DialogResult.None;
            mIsCanceled = true;
        }

        public virtual void FillListControl(ComboBox control, object[] items)
        {
            control.Items.Clear();
            control.Items.AddRange(items);
        }

        private void MyDetailForm_Load(object sender, EventArgs e)
        {
            FormElement.TitleBar.Font = Font;

            BindObjectToControls();
            if (AutoDialogButtons)
            {
                AcceptButton = FindControl(DialogResult.OK);
                CancelButton = FindControl(DialogResult.Cancel);
            }
        }

        private IButtonControl FindControl(DialogResult result)
        {
            foreach (Control control in Controls)
            {
                if (!(control is IButtonControl))
                    continue;
                if ((control as IButtonControl).DialogResult == result)
                    return control as IButtonControl;
            }
            return null;
        }

        public new void Validate()
        {
            Validate(Controls);
        }

        private void rRadDetailForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(DialogResult != DialogResult.OK)
                return;

            if (mIsCanceled)
            {
                e.Cancel = true;
                mIsCanceled = false;
                return;
            }


            if (AutoValidate)
            {
                try
                {
                    BeforeValidate();
                    if (mIsCanceled)
                    {
                        e.Cancel = true;
                        mIsCanceled = false;
                        return;
                    }

                    
                    Validate();

                    if (mIsCanceled)
                    {
                        e.Cancel = true;
                        mIsCanceled = false;
                        return;
                    }

                    AfterValidate();
                    if (mIsCanceled)
                    {
                        e.Cancel = true;
                        mIsCanceled = false;
                        return;
                    }

                }
                catch(ValidationException ex)
                {
                    rMessageBox.ShowError(ex.Message);
                    CancelClosing();
                    ex.Control.Focus();
                }
                catch (Exception ex)
                {
                    rMessageBox.ShowError(ex.Message);
                    CancelClosing();
                }
            }
            
            if(mIsCanceled)
            {
                e.Cancel = true;
                mIsCanceled = false;
                return;
            }

            if(AutoDataBind)
            {
                BeforeBindToObject();
                if (mIsCanceled)
                {
                    e.Cancel = true;
                    mIsCanceled = false;
                    return;
                }

                BindControlsToObject();
                if (mIsCanceled)
                {
                    e.Cancel = true;
                    mIsCanceled = false;
                    return;
                }

                AfterBindToObject();
                if (mIsCanceled)
                {
                    e.Cancel = true;
                    mIsCanceled = false;
                    return;
                }
            }
        }

        protected virtual void BeforeValidate()
        {
            
        }
        protected virtual void AfterValidate()
        {
            
        }
        protected virtual void BeforeBindToObject()
        {
            
        }
        protected virtual void AfterBindToObject()
        {
            
        }

        public bool ProcessObject()
        {
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;

            if (ShowDialog() != DialogResult.OK)
                return false;
            return true;
        }

    }

    public class ControlMapping
    {
        public Control Control { get; set; }
        public object DataObject { get; set; }
        public string ObjectProperty { get; set; }
        public string ControlProperty { get; set; }
        public bool ConvertNeeded { get; set; }
        public ConvertType ConvertType { get; set; }
        public bool MapNullValue { get; set; }

        public ControlMapping()
        {
            ConvertType = ConvertType.Dynamic;
        }

        internal object TargetObject
        {
            get
            {
                List<string> items = ObjectProperty.Split('.').ToList<string>();
                return FindTargetObject(DataObject, items);
            }
        }

        internal object TargetControl
        {
            get
            {
                List<string> items = ControlProperty.Split('.').ToList<string>();
                return FindTargetObject(Control, items);
            }
        }

        public object GetObjectValue()
        {
            return GetValue(TargetObject, GetObjectMember());
        }

        public MemberInfo GetObjectMember()
        {
            List<string> items = ObjectProperty.Split('.').ToList<string>();
            return FindMember(DataObject, items);
        }

        public object GetControlValue()
        {
            return GetValue(TargetControl, GetControlMember());
        }

        public MemberInfo GetControlMember()
        {
            List<string> items = ControlProperty.Split('.').ToList<string>();
            return FindMember(Control, items);
        }

        private MemberInfo GetMember(object dataObject, string memberName)
        {
            MemberInfo[] info = dataObject.GetType().GetMember(memberName);
            if (info.Length == 0)
                return null;
            return info[0];
        }

        private object GetValue(object dataObject, MemberInfo memberInfo)
        {
            if (memberInfo == null)
                return null;
            if (memberInfo.MemberType == MemberTypes.Method)
                return (memberInfo as MethodInfo).Invoke(dataObject, null);
            else if (memberInfo.MemberType == MemberTypes.Property)
                return (memberInfo as PropertyInfo).GetValue(dataObject, null);
            return null;
        }

        private MemberInfo FindMember(object dataObject, List<string> items)
        {
            MemberInfo memberInfo = GetMember(dataObject, items[0]);
            object result = GetValue(dataObject, memberInfo);
            if (result != null)
            {
                if (items.Count == 1)
                    return memberInfo;
                else
                {
                    items.RemoveAt(0);
                    return FindMember(result, items);
                }
            }
            return memberInfo;
        }

        private object FindTargetObject(object dataObject, List<string> items)
        {
            MemberInfo memberInfo = GetMember(dataObject, items[0]);
            object result = GetValue(dataObject, memberInfo);
            if (result != null)
            {
                if (items.Count == 1)
                    return dataObject;
                else
                {
                    items.RemoveAt(0);
                    return FindTargetObject(result, items);
                }
            }
            return dataObject;
        }

//        private string GetValue(object dataObject, List<string> items)
//        {
//            MemberInfo memberInfo = GetMember(dataObject, items[0]);
//            object result = GetValue(dataObject, memberInfo);
//            if (result != null)
//            {
//                if (items.Count == 1)
//                    return result.ToString();
//                else
//                {
//                    items.RemoveAt(0);
//                    return GetValue(result, items);
//                }
//            }
//            return "بدون مقدار";
//        }

        public override string ToString()
        {
            return Control.Name + "." + ControlProperty + " <-> " + DataObject.GetType().Name + "." + ObjectProperty;
        }
    }

    public enum ConvertType
    {
        Dynamic,
        ByCastMethod
    }
    
    public abstract class ControlValidation
    {
        public Control Control {get; set;}
        public string FieldName {get; set;}

        public virtual void Validate()
        {
//            throw new ValidationException { Control = Control, Message = "Test Exception" };
        }
    }

    public class RequiredControlValidation : ControlValidation
    {
        public string Field { get; set; }

        protected string GetFieldValue()
        {
            string fieldValue;

            if (String.IsNullOrEmpty(Field))
                fieldValue = Control.Text.Trim();
            else
            {
                PropertyInfo sourceInfo = Control.GetType().GetProperty(Field);
                fieldValue = sourceInfo.GetValue(Control, null) + "";
            }
            return fieldValue;
        }

        public override void Validate()
        {
//            if (string.IsNullOrEmpty(GetFieldValue()))
//                throw new ValidationException { Control = Control, Message = "[" + FieldName + "] را وارد کنید." };
        }
    }
    public class SelectedControlValidation : ControlValidation
    {
        public new ListControl Control;
        public override void Validate()
        {
//            if(Control.SelectedIndex < 0)
//                throw new ValidationException { Control = Control, Message = "یک مقدار برای [" + FieldName + "] انتخاب کنید." };
        }
    }
    public class RequiredTypeControlValidation : ControlValidation
    {
        public Type Type { get; set; }
        public override void Validate()
        {
            string text = Control.Text.Trim();
            try
            {
                Convert.ChangeType(text, Type);
            }
            catch (Exception ex)
            {
//                throw new ValidationException { Control = Control, Message = "مقدار [" + FieldName + "] نامعتبر است"};
            }

        }

    }
    public class CheckedListViewValidation : ControlValidation
    {
        public new ListView Control;
        public override void Validate()
        {
//            if(Control.CheckedItems.Count == 0)
//                throw new ValidationException { Control = Control, Message = "حداقل یک آیتم از [" + FieldName + "] را انتخاب کنید." };
        }
    }
    public class FieldRangeValidation : RequiredControlValidation
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public override void Validate()
        {
//            int value = Convert.ToInt32(GetFieldValue());
//            if(!(value >= Min && value <= Max))
//                throw new ValidationException() {Control = Control, Message = string.Format("محدوده مجاز برای [{0}] بین {1} و {2} است.", FieldName, Min, Max)};
        }
    }


}
