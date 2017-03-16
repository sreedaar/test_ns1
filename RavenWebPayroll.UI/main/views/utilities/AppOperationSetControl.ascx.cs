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
using RavenWebPayroll.Common.Components.Interfaces.DataForms;
using RavenWebPayroll.Common.Events;
using RavenWebPayroll.Common.StaticData;

using Telerik.Web.UI;

namespace RavenWebPayroll.UI.main.views.utilities
{

    public partial class AppOperationSetControl : System.Web.UI.UserControl, IOperationControl 
    {

        public event AppOperationSelectedEventHandler AppOperationSelected;

        public void SetUp(OperationSetUp setup)
        {
            ResetView();

            if (setup == OperationSetUp.Save)
            {
                RadToolBarButton saveButton = new RadToolBarButton { Text = AppOperationArgs.Save, Value = AppOperationArgs.SaveArgs };

                OperationToolbar.Items.Add(saveButton);
            }
            else if (setup == OperationSetUp.SaveBack)
            {
                RadToolBarButton backButton = new RadToolBarButton { Text = AppOperationArgs.Back, Value = AppOperationArgs.BackArgs };

                RadToolBarButton separator = new RadToolBarButton { IsSeparator = true };

                OperationToolbar.Items.Add(backButton);

                OperationToolbar.Items.Add(separator);

                RadToolBarButton saveButton = new RadToolBarButton { Text = AppOperationArgs.Save, Value = AppOperationArgs.SaveArgs };

                OperationToolbar.Items.Add(saveButton);
            }
            else if (setup == OperationSetUp.New)
            {
                RadToolBarButton configurationItems = new RadToolBarButton { Text = AppOperation.New, Value = AppOperationArgs.NewEntry };

                if (!IsPostBack)
                { 
                    
                }
            }

        }

        public void ResetView()
        {
            OperationToolbar.Items.Clear();
        }

        protected void OperationToolbar_ButtonClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            AppOperation selectedOperation = (AppOperation)Enum.Parse(typeof(AppOperation), e.Item.Value);

            AppOperationSelected(selectedOperation);
        }

     
    }
}