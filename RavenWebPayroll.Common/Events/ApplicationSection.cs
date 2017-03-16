using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RavenWebPayroll.Common;
using RavenWebPayroll.Common.StaticData;

namespace RavenWebPayroll.Common.Events
{

    public delegate void ApplicationSectionSelectedEventHandler(ApplicationSectionEventArgs e);
    
    public class ApplicationSectionEventArgs
    {
        private ApplicationModules applicationModules = ApplicationModules.None;

        private Type dataFormType = null;
        /// <summary>
        /// Gets or sets the current selected module 
        /// </summary>
        public ApplicationModules CurrentApplicationModule
        {
            get { return applicationModules; }
            set { applicationModules = value; }
        }

        /// <summary>
        /// Gets or sets the data form type
        /// </summary>
        public Type DataFormType
        {
            get { return dataFormType; }
            set { dataFormType = value; }
        }
    }

}
