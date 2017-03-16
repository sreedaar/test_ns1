using System;
using System.Collections;
using System.Collections.Generic;
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
using RavenWebPayroll.Common.StaticData;
using RavenWebPayroll.Common.Events;

using Telerik.Web.UI;

namespace RavenWebPayroll.UI.main.views.utilities
{
    public partial class AppSectionControl : System.Web.UI.UserControl
    {
        public event ApplicationSectionSelectedEventHandler ApplicationSectionSelected;

        public void LoadSections(string userName)
        {
            List<ApplicationModule> menuItems = ApplicationMenu.GetApplicationMenuItems(userName);

            MenuItemPanelBar.Items.Clear();

            foreach (ApplicationModule item in menuItems)
            {
                if (item.Parent == ApplicationModules.None)
                {
                    MenuItemPanelBar.Items.Add(new RadPanelItem { Text= item.Value , Value = item.Key.ToString() });
                }
                else
                {
                    RadPanelItem refItem = MenuItemPanelBar.FindItemByValue(item.Parent.ToString());

                    if (refItem != null)
                        refItem.Items.Add(new RadPanelItem { Text = item.Value, Value = item.Key.ToString() });
                }
            }
        }

        /// <summary>
        /// Occurs when a section is selected
        /// </summary>
        /// <param name="sender">The panel bar</param>
        /// <param name="e">PanelBarEventArgs</param>
        protected void MenuItemPanelBar_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            ApplicationSectionEventArgs args = new ApplicationSectionEventArgs();

            ApplicationModules selectedModule = (ApplicationModules)Enum.Parse(typeof(ApplicationModules), e.Item.Value);

            args.CurrentApplicationModule = selectedModule;

            args.DataFormType = ApplicationMenu.GetDataFormType(selectedModule);

            ApplicationSectionSelected(args);
        }
    }

    
}