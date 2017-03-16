using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RavenWebPayroll.Common.Components.DTO;

namespace RavenWebPayroll.Common.Components.Interfaces
{
    public interface ICompanyInformation
    {
        void LoadData(CompanyInformationDTO companyInformationDTO);

        void SubmitChanges(CompanyInformationDTO companyInformationDTO);
    }
}
