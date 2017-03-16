using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using RavenWebPayroll.Common.Components;
using RavenWebPayroll.Common.Components.Interfaces;
using RavenWebPayroll.Common.Components.Interfaces.DataForms;
using RavenWebPayroll.Common.StaticData;

namespace RavenWebPayroll.UI.main.views
{
    public partial class ListingDataFormControlCollectionManager : System.Web.UI.UserControl, IResponder, IController 
    {
   
        #region IResponder Members

        public event NotifyExceptionOccurenceEventHandler NotifyExceptionOccurence;

        public event NotifySuccessfulOperationEventHandler NotifySuccessfulOperation;

        #endregion

        #region IController Members

        public void ResetView()
        {
            BranchesFormInstance.Visible = false;
        }

        public Type GetDataFormType()
        {
            return typeof(IListingForm);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public ApplicationModules CurrentApplicationModule
        {
            get
            {
                if (ViewState[ViewStateIndices.CurrentModuleIndex] != null)
                    return (ApplicationModules)Enum.Parse(typeof(ApplicationModules), ViewState[ViewStateIndices.CurrentModuleIndex].ToString());
                else //should not happen
                    return ApplicationModules.None;
            }
            set
            {
                ViewState[ViewStateIndices.CurrentModuleIndex] = value.ToString();
            }
        }

        /// <summary>
        /// Gets the current IListingForm instance
        /// </summary>
        /// <returns></returns>
        public IListingForm IListingFormInstance
        {
            get
            {
                switch (CurrentApplicationModule)
                {
                    case ApplicationModules.ConfigurationCompanyBranches:
                        return BranchesFormInstance;
                    
                    default:
                        {
                            return null;
                        }
                }

            }
        }

        public void LoadData()
        {
            ResetView();

            IListingForm _currentDataForm = IListingFormInstance;

            if (_currentDataForm != null)
            {
                _currentDataForm.LoadData();
                _currentDataForm.Display = true;
                _currentDataForm.ShowListing();
            }
        }


        #endregion
    }
}