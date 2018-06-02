using Kirkit.Score.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kirkit.Score.Common.Attribute
{
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class CustomDbValidationAttribute : System.Attribute
    {
        public DbValidationType ValidationType { get; }

        public CustomDbValidationAttribute(DbValidationType validationType)
        {
            ValidationType = validationType;
        }
    }
}
