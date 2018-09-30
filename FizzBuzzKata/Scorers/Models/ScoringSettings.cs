using System;
using System.Collections.Generic;
using System.Linq;

namespace Scorers.Models
{
    // TODO - Add documentation
    public class ScoringSettings
    {
        public static ScoringSettings DefaultScoringSettings => 
            new ScoringSettings
            {
                ScoringRules = new ScoringRule[]
                {
                    new ScoringRule(3, "fizz"),
                    new ScoringRule(5, "buzz"),
                    new ScoringRule(7, "pop")
                }
            };

        public ICollection<ScoringRule> ScoringRules { get; set; }

        public IEnumerable<int> ScoringMultiples => ScoringRules?.Select(x => x.Multiple);

        public ScoringSettings AddRule(int multiple, string score)
        {
            if (ScoringRules == null)
            {
                ScoringRules = new List<ScoringRule>() { new ScoringRule(multiple, score) };
            }
            else
            {
                ScoringRules.Add(new ScoringRule(multiple, score));
            }

            return this;
        }
    }
}
