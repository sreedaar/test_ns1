using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RavenWebPayroll.Common.Components.DTO;

namespace RavenWebPayroll.Common.Components.Interfaces
{
    public interface ICompanyInformationModel
    {
        CompanyInformationDTO CompanyInformation { get; set; }

    }
}
