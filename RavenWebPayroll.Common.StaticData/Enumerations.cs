using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RavenWebPayroll.Common.StaticData
{
    /// <summary>
    /// Enumerations representing the application modules
    /// </summary>
    public enum ApplicationModules
    {
        None = -1,

        Configuration = 0,
        ConfigurationCompanyInformation = 1,
        ConfigurationCompanyBranches = 2
    }

    /// <summary>
    /// Enumerations representing the application operations
    /// </summary>
    public enum AppOperation
    { 
        Back = 1,
        Save = 2,
        New = 3
    }

    /// <summary>
    /// Enumerations representing the company info
    /// </summary>
    public enum CompanyInfo
    { 
        Name = 1,
        Address = 2,
        PhoneNumber = 3,
        TIN = 4,
        ZipCode = 5
    }

   
}
