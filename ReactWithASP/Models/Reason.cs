namespace ReactWithASP.Models
{
    public class Reason
    {
        public int ReasonId { get; set; }
        public string ReasonName { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
