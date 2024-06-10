using System;
using System.Collections.Generic;

namespace congestion_tax_calculator_dataModel.Models
{
    public partial class CityOtherRule
    {
        public int IdOtherRules { get; set; }
        public int RuleCode { get; set; }
        public string RuleDescription { get; set; }
        public int? CityFk { get; set; }
        public int? Amount { get; set; }

        public virtual City CityFkNavigation { get; set; }
    }
}
