using Logic = Kirkit.Score.Model.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kirkit.Score.Model.Payload
{
    public class ScoreBoard
    {
        public string Name { get; set; }
        public Logic.Innings  FirstInning { get; set; }
        public Logic.Innings SecondInning { get; set; }
    }
}
