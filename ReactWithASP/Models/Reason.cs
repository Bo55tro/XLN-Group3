namespace ReactWithASP.Models
{
    public class Reason
    {
        public int reasonId { get; set; }
        public string reasonName { get; set; }
        public int categoryId { get; set; }
        public Category Category { get; set; }
    }
}
