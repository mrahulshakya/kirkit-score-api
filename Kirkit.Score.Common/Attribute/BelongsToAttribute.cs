using System;
using System.Collections.Generic;
using System.Text;

namespace Kirkit.Score.Common.Attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class BelongsToAttribute : System.Attribute
    {
        public  Type TableToSearch { get; }
        public string FieldToCheckFromTable { get; }
        public string FieldToCheckFromEntity { get; set; }
        public string FieldToCompare { get; }

            public BelongsToAttribute(Type tableToSearch,
            string fieldToCompare,
            string fieldToCheckFromTable,
            string filedToCheckFromEntity)
        {
            this.TableToSearch = tableToSearch;
            this.FieldToCheckFromEntity = filedToCheckFromEntity;
            this.FieldToCheckFromTable = fieldToCheckFromTable;
            this.FieldToCompare = fieldToCompare;
        }
    }
}
