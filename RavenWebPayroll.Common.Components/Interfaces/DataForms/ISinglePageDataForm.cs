using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RavenWebPayroll.Common.Components.DTO;

namespace RavenWebPayroll.Common.Components.Interfaces.DataForms
{
    public interface ISinglePageDataForm : IResponder
    {
        void LoadData();

        bool Display { get; set; }

        bool Save();
    }
}
