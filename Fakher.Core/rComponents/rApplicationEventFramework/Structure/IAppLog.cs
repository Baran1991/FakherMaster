using rComponents;

namespace rApplicationEventFramework
{
    public interface IAppLog
    {
        PersianDate Date { get; set; }
        string Time { get; set; }
        string Description { get; set; }
        string Actor { get; set; }
        string IP { get; set; }
        string UserAgent { get; set; }
    }
}