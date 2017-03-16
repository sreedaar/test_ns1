using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RavenWebPayroll.Common.Components.Interfaces.DataForms
{
    public interface IListingForm : ISinglePageDataForm, IResponder 
    {
        void ShowDetails(Guid ID);

        void ShowListing();
    }
}
