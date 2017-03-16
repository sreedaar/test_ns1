using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

using RavenWebPayroll.Common.Components.Interfaces.DataForms;
using RavenWebPayroll.Common.Components.Interfaces;
using RavenWebPayroll.Common.Components.DTO;

using RavenWebPayroll.Data.Database;
using RavenWebPayroll.Data;

namespace RavenWebPayroll.Common.Models
{
    public class BranchModel : IBranchModel , IResponder
    {
        #region IBranchModel Members

        public bool SubmitChanges(BranchDTO branchDTO)
        {
            if (branchDTO != null)
            {
                if (branchDTO.ID != Guid.Empty)
                {
                    Branch item = new Branch();

                    item.ID = branchDTO.ID;

                    item.LocationName = branchDTO.LocationName;

                    item.Address = branchDTO.Address;

                    item.PhoneNumber = branchDTO.PhoneNumber;

                    item.ZipCode = branchDTO.ZipCode;

                    return LocationsDataProvider.SubmitChanges(item);
                }
                else
                {
                    Branch item = new Branch();

                    item.LocationName = branchDTO.LocationName;

                    item.Address = branchDTO.Address;

                    item.PhoneNumber = branchDTO.PhoneNumber;

                    item.ZipCode = branchDTO.ZipCode;

                    return LocationsDataProvider.SubmitChanges(item);

                }
            }

            return false;
        }

        public DataTable GetBranches()
        {
            DataTable items = new DataTable();

            Type type = new Branch().GetType();

            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
                items.Columns.Add(property.Name, property.PropertyType);
            
            List<Branch> locals = LocationsDataProvider.GetBranches();

            foreach (Branch item in locals)
            {
                DataRow itemRow = items.NewRow();

                for (int i = 0; i < properties.Length; i++)
                    itemRow[item.GetType().GetProperties()[i].Name] = item.GetType().GetProperties()[i].GetValue(item, null);

                items.Rows.Add(itemRow);
            }

            if (items.Rows.Count > 0)
                return items;

            return null;
        }

        public BranchDTO GetBranch(Guid ID)
        {
            throw new NotImplementedException();
        }

        public bool IsExisting(string branchName)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid ID)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IResponder Members

        public event NotifyExceptionOccurenceEventHandler NotifyExceptionOccurence;

        public event NotifySuccessfulOperationEventHandler NotifySuccessfulOperation;

        #endregion
    }
}
