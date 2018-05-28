namespace Kirkit.Score.Common.Enum
{
    public enum WicketType
    {
        Unknown = 0,
        Bowled = 1,
        Caught = 2,
        LBW = 3,
        RunOut = 4,
        Stumped = 5,
        HitWicket = 6,
        HandledBall = 7,
        Obstruction = 8,
        DoubleHit = 9,
        TimedOut = 10
    }

    /* 
     
     VALUES ('Bowled', GETDATE(), GETDATE(), 1),
       ('Caught', GETDATE(), GETDATE(), 1),
       ('Leg Before Wicket', GETDATE(), GETDATE(), 1),
       ('Run Out', GETDATE(), GETDATE(), 1),
       ('Stumped', GETDATE(), GETDATE(), 1),
       ('Hit Wicket', GETDATE(), GETDATE(), 1),
       ('Handled the ball', GETDATE(), GETDATE(), 1),
       ('Obstructing the field', GETDATE(), GETDATE(), 1),
       ('Hit the ball  twice', GETDATE(), GETDATE(), 1);
     */
}
