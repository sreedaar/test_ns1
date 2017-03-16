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

using RavenWebPayroll.Common.Components.Interfaces;
using RavenWebPayroll.Common.Components.Interfaces.DataForms;
using RavenWebPayroll.Common.Components.DTO;

namespace RavenWebPayroll.UI.main.views.configuration
{
    public partial class BranchesForm : System.Web.UI.UserControl, IBranches, IListingForm
    {
        #region IBranches Members

        public void LoadData()
        {
            BranchesGrid.DataBind();
        }

        public void SubmitChanges(BranchDTO branchDTO)
        {
            throw new NotImplementedException();
        }

        public void LoadEntry(Guid ID)
        {
            
        }

        public void DeleteEntry(Guid ID)
        {
            throw new NotImplementedException();
        }

        public void IsExisting(string branchName)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IListingForm Members

        public void ShowDetails(Guid ID)
        {
            BranchesGrid.Visible = false;
            BranchDetailWindow.VisibleOnPageLoad = true;

            if (ID == Guid.Empty)
                LocationNameTextbox.Text = string.Empty;
            else
                LoadEntry(ID);
        }

        public void ShowListing()
        {
            BranchesGrid.Visible = true;
            BranchDetailWindow.VisibleOnPageLoad = false;
        }

        #endregion

        #region IResponder Members

        public event NotifyExceptionOccurenceEventHandler NotifyExceptionOccurence;

        public event NotifySuccessfulOperationEventHandler NotifySuccessfulOperation;

        #endregion

        #region ISinglePageDataForm Members


        public bool Display
        {
            get
            {
                return this.Visible;
            }
            set
            {
                this.Visible = value;
            }
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}