using Microsoft.Azure.WebJobs.Description;
using System;

namespace Kirkit.Score.Api.DI
{
    [Binding]
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class InjectAttribute : Attribute
    {
    }
}
