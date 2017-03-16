using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RavenWebPayroll.Common.Components.Interfaces;
using RavenWebPayroll.Common.Components.DTO;
using RavenWebPayroll.Common.StaticData;
using RavenWebPayroll.Common.Components.Interfaces.DataForms;
using RavenWebPayroll.Data.Database;
using RavenWebPayroll.Data;

namespace RavenWebPayroll.Common.Components.Models
{
    public class CompanyInformationModel : ICompanyInformationModel, IResponder
    {
        #region ICompanyInformationModel Members

        public CompanyInformationDTO CompanyInformation
        {
            get
            {
                List<XSetting> items = XSettingsDataProvider.GetXSettingsByModuleID((int)ApplicationModules.ConfigurationCompanyInformation);
                if (items.Count > 0)
                { 
                    CompanyInformationDTO companyInfoDTO = new CompanyInformationDTO();

                    if (items.Find(p => p.AppKey.Value == (int)CompanyInfo.Name) != null)
                        companyInfoDTO.CompanyName = items.Find(p => p.AppKey == (int)CompanyInfo.Name).Value;

                    if (items.Find(p => p.AppKey == (int)CompanyInfo.Address) != null)
                        companyInfoDTO.Address = items.Find(p => p.AppKey == (int)CompanyInfo.Address).Value;

                    if (items.Find(p => p.AppKey == (int)CompanyInfo.PhoneNumber) != null)
                        companyInfoDTO.PhoneNumber = items.Find(p => p.AppKey == (int)CompanyInfo.PhoneNumber).Value;

                    if (items.Find(p => p.AppKey == (int)CompanyInfo.TIN) != null)
                        companyInfoDTO.TIN = items.Find(p => p.AppKey == (int)CompanyInfo.TIN).Value;

                    if (items.Find(p => (int)p.AppKey == (int)CompanyInfo.ZipCode) != null)
                        companyInfoDTO.ZipCode = items.Find(p => p.AppKey == (int)CompanyInfo.ZipCode).Value;

                    return companyInfoDTO;
                }

                return new CompanyInformationDTO();
            }
            set
            {
                List<XSetting> companyInfo = new List<XSetting>();

                companyInfo.Add(GetXSetting((int)CompanyInfo.Name,value.CompanyName));
                companyInfo.Add(GetXSetting((int)CompanyInfo.Address,value.Address));
                companyInfo.Add(GetXSetting((int)CompanyInfo.PhoneNumber, value.PhoneNumber));
                companyInfo.Add(GetXSetting((int)CompanyInfo.TIN, value.TIN));
                companyInfo.Add(GetXSetting((int)CompanyInfo.ZipCode, value.ZipCode));

                XSettingsDataProvider.SubmitChanges(companyInfo);

                NotifySuccessfulOperation("Company information updated.");
            }

        }

        private XSetting GetXSetting(int appKey, string value)
        {
            return new XSetting
            {
                ModuleID = (int)ApplicationModules.ConfigurationCompanyInformation,
                AppKey = appKey,
                Value = value,
            };
        }

        
        #endregion

        #region IResponder Members

        public event NotifyExceptionOccurenceEventHandler NotifyExceptionOccurence;

        public event NotifySuccessfulOperationEventHandler NotifySuccessfulOperation;

        #endregion
    }
}
