namespace Kirkit.Score.Common.Enum
{
    public enum DbValidationType
    {
       Unknown = 0,
       Unique = 1,
       OnlyTwoActiveForeignKeysAllowed = 2,
       OnlyOneAciveKeyAllowed = 3,
       CountAllowed = 4,
       BelongTo
    }
}
