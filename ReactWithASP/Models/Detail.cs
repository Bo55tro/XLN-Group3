namespace ReactWithASP.Models
{
    public class Detail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ReasonId { get; set; }

        public Reason? Reason { get; set; }
    }
}
