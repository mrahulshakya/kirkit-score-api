namespace Kirkit.Score.Model.Logic
{
    public class BallType : LogicBase
    {
        public int BallTypeId { get; set; }
        public string Detail { get; set; }
        public bool IsLegal { get; set; }
        public bool ExtraRun { get; set; }
    }
}