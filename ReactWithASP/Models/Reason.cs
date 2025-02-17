namespace ReactWithASP.Models
{
    public class Reason
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }

        public Category? Category { get; set; }
        public ICollection<Detail>? Details { get; set; }
    }
}
