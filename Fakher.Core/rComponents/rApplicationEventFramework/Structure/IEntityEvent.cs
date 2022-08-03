using rComponents;

namespace rApplicationEventFramework
{
    public interface IEntityEvent
    {
        EntityEventAction Action { get; set; }
        PersianDate Date { get; set; }
        int Hour { get; set; }
        int Minute { get; set; }
        int EntityId { get; set; }
        string EntityText { get; set; }
        string EntityTypeText { get; set; }
        string RegistrarText { get; set; }
        int BatchNumber { get; set; }
    }
}