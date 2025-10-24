// Diagram: Missing
namespace Softela.PestManagement.Domain.Entities
{
    public class Release : BaseEntity
    {
        public string ReleaseName { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public bool IsActive { get; set; }
    }
}
