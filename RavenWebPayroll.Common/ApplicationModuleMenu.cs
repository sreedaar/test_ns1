using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RavenWebPayroll.Common.StaticData;
using RavenWebPayroll.Common.Components.Interfaces.DataForms;

namespace RavenWebPayroll.Common
{
    public class ApplicationMenu
    {
        public static List<ApplicationModule> GetApplicationMenuItems(string userName)
        {
            List<ApplicationModule> items = new List<ApplicationModule>();

            items.Add(new ApplicationModule { Parent = ApplicationModules.None, Key = ApplicationModules.Configuration, Value = ApplicationModuleName.Configuration });

            items.Add(new ApplicationModule { Parent = ApplicationModules.Configuration, Key = ApplicationModules.ConfigurationCompanyInformation, Value = ApplicationModuleName.ConfigurationCompanyName });

            items.Add(new ApplicationModule { Parent = ApplicationModules.Configuration, Key = ApplicationModules.ConfigurationCompanyBranches, Value = ApplicationModuleName.ConfigurationBranches });


            return items;
        }
            
        public static Type GetDataFormType(ApplicationModules appModule)
        {
            switch (appModule)
            { 
                case ApplicationModules.ConfigurationCompanyInformation:
                    return typeof(ISinglePageDataForm);
                case ApplicationModules.ConfigurationCompanyBranches:
                    return typeof(IListingForm);
                default:
                    return null;
            }
        }
    }

    public class ApplicationModule
    {
        private ApplicationModules applicationModuleKey = ApplicationModules.None;
        private ApplicationModules applicationModuleParent = ApplicationModules.None;
        private string applicationModuleValue = string.Empty;

        public ApplicationModules Key
        {
            get { return applicationModuleKey; }
            set { applicationModuleKey = value; }
        }

        public string Value
        {
            get { return applicationModuleValue; }
            set { applicationModuleValue = value; }
        }

        public ApplicationModules Parent
        {
            get { return applicationModuleParent; }
            set { applicationModuleParent = value; }
        }
    }
}
