using System.Collections.Generic;

namespace ModernizeLegacyCode.Models
{
    public class ResultDto
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string AccountNumber { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string BaseName { get; set; }
        public List<Card> Cards { get; set; }
        public List<CardGroup> Groups { get; set; }
        public bool Passed { get; set; }
        public string ValidationError { get; set; }
    }
}