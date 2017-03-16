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

using RavenWebPayroll.Common.Events;
using RavenWebPayroll.Common;
using RavenWebPayroll.Common.Components.Interfaces.DataForms;
using RavenWebPayroll.Common.StaticData;

namespace RavenWebPayroll.UI.main
{
    public partial class Default : System.Web.UI.Page
    {

        /// <summary>
        /// PreRender event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ResetView();
                AppSectionControl.LoadSections(HttpContext.Current.User.Identity.Name);
            }
        }

        public void AppSectionControl_OnApplicationSectionSelected(ApplicationSectionEventArgs e)
        {
            ResetView();

            if (e.DataFormType == typeof(ISinglePageDataForm))
            {
                SingleDataFormControlCollectionManagerInstance.CurrentApplicationModule = e.CurrentApplicationModule;
                AppOperationSetControlInstance.SetUp(OperationSetUp.Save);
                SingleDataFormControlCollectionManagerInstance.Visible = true;
                AppOperationSetControlInstance.Visible = true;
                CurrentController = SingleDataFormControlCollectionManagerInstance.ToString();
            }
            else if (e.DataFormType == typeof(IListingForm))
            {
                ListingDataFormControlCollectionManagerInstance.CurrentApplicationModule = e.CurrentApplicationModule;
                AppOperationSetControlInstance.SetUp(OperationSetUp.New);
                ListingDataFormControlCollectionManagerInstance.Visible = true;
                AppOperationSetControlInstance.Visible = true;
                CurrentController = ListingDataFormControlCollectionManagerInstance.ToString();
                ListingDataFormControlCollectionManagerInstance.LoadData();
            }
            
        }

        public void SingleDataFormControlCollectionManagerInstance_OnNotifyExceptionOccurence(ExceptionNotification ex)
        {
            NotifierControl.Text = ex.Message;
            NotifierControl.Show();
        }

        public void NotifySuccess(string message)
        {
            NotifierControl.Text = message;
            NotifierControl.Show();
        }

        /// <summary>
        /// Gets or sets the current application controller
        /// </summary>
        public string CurrentController
        {
            get
            {
                return ViewState[ViewStateIndices.CurrentControllerIndex].ToString();
            }
            set
            {
                ViewState[ViewStateIndices.CurrentControllerIndex] = value.ToString();
            }
        }

        /// <summary>
        /// Gets the current IController instance
        /// </summary>
        /// <returns></returns>
        public IController IControllerInstance
        {
            get
            {
                if (CurrentController == SingleDataFormControlCollectionManagerInstance.ToString())
                {
                    SingleDataFormControlCollectionManagerInstance.NotifySuccessfulOperation += new NotifySuccessfulOperationEventHandler(NotifySuccess);
                    return SingleDataFormControlCollectionManagerInstance;
                }
                else if (CurrentController == ListingDataFormControlCollectionManagerInstance.ToString())
                { 
                    ListingDataFormControlCollectionManagerInstance.NotifySuccessfulOperation += new NotifySuccessfulOperationEventHandler(NotifySuccess);
                    return ListingDataFormControlCollectionManagerInstance;
                }
                return null;
            }
        }

        public void AppOperationSetControlInstance_OnAppOperationSelected(AppOperation e)
        {
            if (e == AppOperation.Save)
            {
                if (IControllerInstance != null)
                    IControllerInstance.Save();
            }
        }

        void ResetView()
        {
            SingleDataFormControlCollectionManagerInstance.Visible = false;
            AppOperationSetControlInstance.Visible = false;
            ListingDataFormControlCollectionManagerInstance.Visible = false;

            SingleDataFormControlCollectionManagerInstance.ResetView();
            ListingDataFormControlCollectionManagerInstance.ResetView();
        }

    }
}
