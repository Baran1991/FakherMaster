using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.WinControls.UI.Localization;

namespace rComponents
{
    public class FarsiRadGridLocalizationProvider : RadGridLocalizationProvider
    {
        public override string GetLocalizedString(string id)
        {
            switch (id)
            {
                case RadGridStringId.FilterFunctionBetween:
                    return "بین";
                case RadGridStringId.FilterFunctionContains:
                    return "شامل باشد";
                case RadGridStringId.FilterFunctionDoesNotContain:
                    return "شامل نباشد";
                case RadGridStringId.FilterFunctionEndsWith:
                    return "پایان با";
                case RadGridStringId.FilterFunctionEqualTo:
                    return "برابر";
                case RadGridStringId.FilterFunctionGreaterThan:
                    return "بزرگتر از";
                case RadGridStringId.FilterFunctionGreaterThanOrEqualTo:
                    return "بزگتر یا مساوی";
                case RadGridStringId.FilterFunctionIsEmpty:
                    return "خالی باشد";
                case RadGridStringId.FilterFunctionIsNull:
                    return "تهی باشد";
                case RadGridStringId.FilterFunctionLessThan:
                    return "کمتر از";
                case RadGridStringId.FilterFunctionLessThanOrEqualTo:
                    return "کمتر یا مساوی";
                case RadGridStringId.FilterFunctionNoFilter:
                    return "حذف فیلتر";
                case RadGridStringId.FilterFunctionNotBetween:
                    return "مابین نباشد";
                case RadGridStringId.FilterFunctionNotEqualTo:
                    return "برابر نباشد";
                case RadGridStringId.FilterFunctionNotIsEmpty:
                    return "خالی نباشد";
                case RadGridStringId.FilterFunctionNotIsNull:
                    return "تهی نباشد";
                case RadGridStringId.FilterFunctionStartsWith:
                    return "آغاز می شود با";
                case RadGridStringId.FilterFunctionCustom:
                    return "سفارشی...";
                case RadGridStringId.CustomFilterMenuItem:
                    return "منو فیلتر";
                case RadGridStringId.CustomFilterDialogCaption:
                    return "دیالوگ";
                case RadGridStringId.CustomFilterDialogLabel:
                    return "خطوط را مشاهده کنید :";
                case RadGridStringId.CustomFilterDialogRbAnd:
                    return "و";
                case RadGridStringId.CustomFilterDialogRbOr:
                    return "یا";
                case RadGridStringId.CustomFilterDialogBtnOk:
                    return "تایید";
                case RadGridStringId.CustomFilterDialogBtnCancel:
                    return "انصراف";
                case RadGridStringId.DeleteRowMenuItem:
                    return "حذف";
                case RadGridStringId.SortAscendingMenuItem:
                    return "مرتب سازی صعودی";
                case RadGridStringId.SortDescendingMenuItem:
                    return "مرتب سازی نزولی";
                case RadGridStringId.ClearSortingMenuItem:
                    return "حذف مرتب سازی";
                case RadGridStringId.ConditionalFormattingMenuItem:
                    return "منوی تنظیمات خاص فرمت بندی";
                case RadGridStringId.GroupByThisColumnMenuItem:
                    return "منوی گروه بندی بر اساس این ستون";
                case RadGridStringId.UngroupThisColumn:
                    return "حذف گروه بندی بر اساس این ستون";
                case RadGridStringId.ColumnChooserMenuItem:
                    return "انتخاب کننده";
                case RadGridStringId.HideMenuItem:
                    return "پنهان کردن";
                case RadGridStringId.UnpinMenuItem:
                    return "حذف سنجاق";
                case RadGridStringId.PinMenuItem:
                    return "سنجاق کردن";
                case RadGridStringId.BestFitMenuItem:
                    return "بهترین جانمایی";
                case RadGridStringId.PasteMenuItem:
                    return "چسباندن";
                case RadGridStringId.EditMenuItem:
                    return "ویرایش";
                case RadGridStringId.CopyMenuItem:
                    return "کپی";
                case RadGridStringId.AddNewRowString:
                    return "برای افزودن یک ردیف جدید، اینجا را کلیک کنید";
                case RadGridStringId.ConditionalFormattingCaption:
                    return "تنظیمات خاص فرمت بندی";
                case RadGridStringId.ConditionalFormattingLblColumn:
                    return "ستون:";
                case RadGridStringId.ConditionalFormattingLblName:
                    return "نام:";
                case RadGridStringId.ConditionalFormattingLblType:
                    return "نوع:";
                case RadGridStringId.ConditionalFormattingLblValue1:
                    return "مقدار 1:";
                case RadGridStringId.ConditionalFormattingLblValue2:
                    return "مقدار 2:";
                case RadGridStringId.ConditionalFormattingGrpConditions:
                    return "شرایط";
                case RadGridStringId.ConditionalFormattingGrpProperties:
                    return "تنظیمات";
                case RadGridStringId.ConditionalFormattingChkApplyToRow:
                    return "درخواست برای ردیف";
                case RadGridStringId.ConditionalFormattingBtnAdd:
                    return "جدید";
                case RadGridStringId.ConditionalFormattingBtnRemove:
                    return "حذف";
                case RadGridStringId.ConditionalFormattingBtnOK:
                    return "تایید";
                case RadGridStringId.ConditionalFormattingBtnCancel:
                    return "انصراف";
                case RadGridStringId.ConditionalFormattingBtnApply:
                    return "اعمال تغییرات";
                case RadGridStringId.ColumnChooserFormCaption:
                    return "انتخاب ستون...";
                case RadGridStringId.GroupingPanelHeader :
                    return "گروه بندی";
                case RadGridStringId.GroupingPanelDefaultMessage :
                    return "برای گروه بندی، یک ستون را به اینجا بکشید";
                case RadGridStringId.PinAtLeftMenuItem :
                    return "سنجاق در چپ";
                case RadGridStringId.PinAtRightMenuItem:
                    return "سنجاق در راست";
                case RadGridStringId.FilterOperatorContains:
                    return "فیلتر شامل";
                case RadGridStringId.FilterOperatorNotEqualTo:
                    return "فیلتر برابر با";
                case RadGridStringId.FilterOperatorNoFilter:
                    return "بدون فیلتر";
                case RadGridStringId.ColumnChooserFormMessage:
                    return
                        @"Eine Spalte um zu verstecken,\n     
                   stellen Sie sie vom RadGridView in diesem Fenster";
                default:
                    return base.GetLocalizedString(id);
            }
        }
    }
}
