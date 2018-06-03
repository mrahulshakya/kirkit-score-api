using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kirkit.Score.Model.Logic.CustomVaildation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FutureDateAttribute  : ValidationAttribute
    {
        private readonly int maxmonthsInFuture;

        public FutureDateAttribute(int maxmonthsInFuture)
        {
            this.maxmonthsInFuture = maxmonthsInFuture;
        }

        public override bool IsValid(object value)
        {
            var date = (DateTime)value;

            if(date < DateTime.Now && date > DateTime.Now.AddMonths(maxmonthsInFuture))
            {
                return false;
            }

            return true;
        }
    }

}
