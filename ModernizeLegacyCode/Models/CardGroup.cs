using System.Collections.Generic;

namespace ModernizeLegacyCode.Models
{
    public class CardGroup
    {
        public string GroupId { get; set; }
        public string Type { get; set; }
        public List<string> CardTypes { get; set; }
        public List<string> CardIds { get; set; }
    }
}