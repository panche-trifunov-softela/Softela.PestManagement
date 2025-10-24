// Diagram: InspectionPointHistory
namespace Softela.PestManagement.Domain.Entities
{
    public class InspectionPointHistory : BaseEntity
    {
        public int InspectionPointId { get; set; }
        public int ZoneId { get; set; }
        public DateTime HistoryDate { get; set; }
        public int HistoryActionId { get; set; }
        public int? WoEventId { get; set; }
        public int? ActivityLevel { get; set; }
        public decimal? ScanLatitude { get; set; }
        public decimal? ScanLongitude { get; set; }
        public bool StationScaned { get; set; }
        public DateTime? MonitoredDate { get; set; }
        public DateTime? InstallDate { get; set; }
        public DateTime? RemoveDate { get; set; }
    }
}
