namespace ReactWithASP.Models
{
    public class Case
    {
        public int caseId { get; set; }
        public int agentId { get; set; }
        public string caseDate { get; set; }
        public int categoryId { get; set; }
        public int reasonId { get; set; }
        public int detailId { get; set; }
        public string caseComments { get; set; }
        public string caseStatus { get; set; }
        public string caseNotes { get; set; }
        public int clientId { get; set; }

        public Category? Category { get; set; }
        public Reason? Reason { get; set; }
        public Detail? Detail { get; set; }
        public Client? Client { get; set; }
    }
}
