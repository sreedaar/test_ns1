using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RavenWebPayroll.Common.StaticData;

namespace RavenWebPayroll.Common.Components.Interfaces.DataForms
{
    public interface IController
    {
        void ResetView();

        Type GetDataFormType();

        void Save();

        ApplicationModules CurrentApplicationModule { get; set; }

    }
}
