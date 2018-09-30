using System;

namespace Scorers.Models
{
    // TODO - Add documentation
    public class ScoringRule
    {
        public ScoringRule(int multiple, string score)
        {
            Multiple = multiple;
            Score = score;
        }

        public int Multiple { get; set; }

        public string Score { get; set; }
    }
}
