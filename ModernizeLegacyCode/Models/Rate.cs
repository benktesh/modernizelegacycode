using System.Collections.Generic;

namespace ModernizeLegacyCode.Models
{
    public class Rate
    {
        public EnumRateType IntroRateType { get; set; }
        public EnumRateType StandardRateType { get; set; }
        public List<string> IntroMargin { get; set; }
        public List<string> StandardMargin { get; set; }
        public List<string> IntroRates { get; set; }
        public List<string> StandardRates { get; set; }
    }
}