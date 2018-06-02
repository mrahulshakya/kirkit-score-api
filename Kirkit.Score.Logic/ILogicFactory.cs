using System;
using System.Collections.Generic;
using Kirkit.Score.Common.Data;
using Kirkit.Score.Data.Validation;

namespace Kirkit.Score.Logic
{
    public interface ILogicFactory
    {
        dynamic GetLogic(string resource);

        Type GetModelType(string resource);
    }
}
