namespace ReactWithASP.Models
{
    public class Detail
    {
        public int detailId { get; set; }
        public string detailName { get; set; }
        public int reasonId { get; set; }
        public Reason Reason { get; set; }
    }
}
