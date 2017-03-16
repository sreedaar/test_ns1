using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RavenWebPayroll.Common.Components.Interfaces;
using RavenWebPayroll.Common.Components.Models;
using RavenWebPayroll.Common.Components.DTO;

namespace RavenWebPayroll.Common.Components.Controllers
{
    public class CompanyInformationController
    {
        ICompanyInformation companyInfoView;
        ICompanyInformationModel companyInfoModel;

        public CompanyInformationController(ICompanyInformation _companyInfoView, ICompanyInformationModel _companyInfoModel)
        {
            companyInfoModel = _companyInfoModel;
            companyInfoView = _companyInfoView;

            companyInfoView.LoadData(_companyInfoModel.CompanyInformation);
        }

        public CompanyInformationDTO CompanyInformation
        {
            get { return companyInfoModel != null ? companyInfoModel.CompanyInformation : new CompanyInformationDTO(); }
            set
            {
                if (companyInfoModel != null)
                {
                    companyInfoModel.CompanyInformation = value;
                }
                else
                {
                    companyInfoModel = new CompanyInformationModel();

                    companyInfoModel.CompanyInformation = value;
                }
            }
        }

        
    }
}
