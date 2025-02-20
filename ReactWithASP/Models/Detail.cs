using System.Drawing;

namespace ReactWithASP.Models
{
    public class Detail
    {
        public int DetailId { get; set; }
        public string DetailName { get; set; } = string.Empty;
        public int ReasonId { get; set; }
        public Reason Reason { get; set; } = null!;
    }
}
