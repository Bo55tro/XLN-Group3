using System;
using System.ComponentModel.DataAnnotations;


namespace ReactWithASP.Models
{
    public class Case
    {
        public int caseId { get; set; }
        public int agentId { get; set; }

        [Required]
        [DataType(DataType.Date)] // Only date is stored
        public DateTime caseDate { get; set; }

        public int CategoryId { get; set; }
        public int ReasonId { get; set; }
        public int DetailId { get; set; }
        public string caseComments { get; set; }
        public string? caseKeyWords { get; set; }
        public string caseStatus { get; set; }
        public string caseNotes { get; set; }
        public int ClientId { get; set; }

        public Category? Category { get; set; }
        public Reason? Reason { get; set; }
        public Detail? Detail { get; set; }
        public Client? Client { get; set; }
    }
}
