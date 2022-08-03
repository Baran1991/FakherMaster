using rComponents;

namespace Fakher.Core.DomainModel
{
    public static class InternalPostMaster
    {
        public static Message FromExamRequest(ExamRequest request)
        {
            Message message = new Message();

            string text = "";
            text += "تاریخ آزمون درخواستی: " + request.ExamDate.ToShortDateString() + "\r\n";
            text += "دوره/رشته: " + request.Major + "\r\n";
            text += "درس/سطح: " + request.Lesson + "\r\n";
            text += "گروه/کلاس: " + request.Section + "\r\n";
            text += "نام آزمون: " + request.Name + "\r\n";
            text += "از ساعت: " + request.StartTime + "\r\n";
            text += "تا ساعت: " + request.EndTime + "\r\n";
            text += "تعداد شرکت کننده: " + request.ParticipateCount + "\r\n";
            text += "وضعیت: " + request.StatusText + "\r\n";
            text += "\r\n";
            message.Body = text;

            message.Subject = "درخواست آزمون";
            message.Sender = request.Teacher;
            message.SendDate = PersianDate.Today;
            message.SendTime = Time.Now.ToShortTimeString();

            return message;
        }
    }
}