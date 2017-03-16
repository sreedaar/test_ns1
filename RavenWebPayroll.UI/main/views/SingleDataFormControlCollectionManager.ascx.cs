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

using RavenWebPayroll.Common;
using RavenWebPayroll.Common.Components;
using RavenWebPayroll.Common.Components.Interfaces.DataForms;
using RavenWebPayroll.Common.StaticData;

namespace RavenWebPayroll.UI.main.views
{
    public partial class SingleDataFormControlCollectionManager : System.Web.UI.UserControl, IResponder, IController 
    {
        /// <summary>
        /// Gets or sets the current application module
        /// </summary>
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
                LoadData();
            }
        }

        /// <summary>
        /// Gets the current ISinglePageDataForm instance
        /// </summary>
        /// <returns></returns>
        public ISinglePageDataForm ISinglePageDataFormInstance
        {
            get
            {
                switch (CurrentApplicationModule)
                { 
                    case ApplicationModules.ConfigurationCompanyInformation:
                        return CompanyInfoFormInstance;
                    default:
                        {
                            return null;
                        }
                }

            }
        }
                

        /// <summary>
        /// Loads the data of the current ISingleDataForm object
        /// </summary>
        public void LoadData()
        {
            try
            {
                ResetView();

                ISinglePageDataForm _currentDataForm = ISinglePageDataFormInstance;

                if (_currentDataForm != null)
                {
                    _currentDataForm.NotifySuccessfulOperation +=new NotifySuccessfulOperationEventHandler(NotifySuccess);
                    _currentDataForm.LoadData();
                    _currentDataForm.Display = true;
                }
            }
            catch (Exception ex)
            {
                NotifyExceptionOccurence(new ExceptionNotification(ex.Message));
            }
        }

        #region IResponder Members

        public event NotifyExceptionOccurenceEventHandler NotifyExceptionOccurence;

        #endregion

        public void NotifySuccess(string message)
        {
            NotifySuccessfulOperation(message);
        }
        
        #region IController Members

        public void ResetView()
        {
            CompanyInfoFormInstance.Display = false;
        }

        public Type GetDataFormType()
        {
            return typeof(ISinglePageDataForm);
        }

        #endregion

        #region IController Members


        public void Save()
        {
            ISinglePageDataForm _currentDataForm = ISinglePageDataFormInstance;

            if (_currentDataForm != null)
            {
                _currentDataForm.NotifySuccessfulOperation += new NotifySuccessfulOperationEventHandler(NotifySuccess);
                _currentDataForm.Save();
            }
        }

        #endregion

        #region IResponder Members


        public event NotifySuccessfulOperationEventHandler NotifySuccessfulOperation;

        #endregion
    }
}