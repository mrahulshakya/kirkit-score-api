using System;

namespace Kirkit.Score.Model.Logic
{
    public class Rule : LogicBase
    {
        public int RuleId { get; set; }
        public string Name { get; set; }
        public int TotalOvers { get; set; }
        public int FkMaxOverRule { get; set; }
        public bool SuperOver { get; set; }
        public bool FreeHit { get; set; }
        public int FkPowerPlayRule { get; set; }
     }
}
