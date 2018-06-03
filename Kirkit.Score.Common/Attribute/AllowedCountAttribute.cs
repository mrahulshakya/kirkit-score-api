using Kirkit.Score.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kirkit.Score.Common.Attribute
{
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class AllowedCountAttribute : System.Attribute
    {
        public int MaxCount { get; }
   
        public AllowedCountAttribute(int maxCount)
        {
            MaxCount = maxCount;
        }
    }

}
