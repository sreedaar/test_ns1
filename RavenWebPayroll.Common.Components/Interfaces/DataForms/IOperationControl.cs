using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RavenWebPayroll.Common;

namespace RavenWebPayroll.Common.Components.Interfaces.DataForms
{
    public interface IOperationControl
    {
        void SetUp(OperationSetUp setUp);
    }

    public enum OperationSetUp
    { 
        None = 0,
        Save = 1,
        SaveBack = 2,
        New = 3
    }
}
