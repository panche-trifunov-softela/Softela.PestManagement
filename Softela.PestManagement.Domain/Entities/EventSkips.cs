// Diagram: EventSkips
namespace Softela.PestManagement.Domain.Entities
{
    public class EventSkips
    {
        public short SkipMonths { get; set; }
        public byte Jan { get; set; }
        public byte Feb { get; set; }
        public byte Mar { get; set; }
        public byte Apr { get; set; }
        public byte May { get; set; }
        public byte Jun { get; set; }
        public byte Jul { get; set; }
        public byte Aug { get; set; }
        public byte Sep { get; set; }
        public byte Oct { get; set; }
        public byte Nov { get; set; }
        public byte December { get; set; }
        public byte SCount { get; set; }
        public byte NonSkips { get; set; }
    }
}
