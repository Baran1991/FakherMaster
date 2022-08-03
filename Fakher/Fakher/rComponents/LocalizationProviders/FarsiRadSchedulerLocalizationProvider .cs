using Telerik.WinControls.UI.Localization;

namespace rComponents
{
    public class FarsiRadSchedulerLocalizationProvider : RadSchedulerLocalizationProvider 
    {
        public override string GetLocalizedString(string id)
        {
            switch (id)
            {
                case RadSchedulerStringId.AppointmentDialogBackground:
                    return "Background translation here:";
                case RadSchedulerStringId.AppointmentDialogCancel:
                    return "Cancel translation here";
                //more translated strings
                default:
                    return base.GetLocalizedString(id);
            }
        }
    }
}