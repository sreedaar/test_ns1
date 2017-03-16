using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RavenWebPayroll.Data.Database;

namespace RavenWebPayroll.Data
{
    public class LocationsDataProvider
    {
        private static RavenPXDataContext dataContext = new RavenPXDataContext();

        public static List<Branch> GetBranches()
        {
            dataContext = new RavenPXDataContext();

            List<Branch> items = (from p in dataContext.Branches
                                         orderby p.ID descending
                                         select p).ToList();
            if (items.Count > 0)
                return items;

            return new List<Branch>();
        }

        public static Branch GetBranch(Guid ID)
        {
            dataContext = new RavenPXDataContext();

            List<Branch> items = (from p in dataContext.Branches
                                  orderby p.ID descending
                                  select p).ToList();

            if (items.Count > 0)
                return items.First();

            return null;
        }

        public static Branch GetBranch(Guid ID, RavenPXDataContext _dataContext)
        {
            List<Branch> items = (from p in _dataContext.Branches
                                  orderby p.ID descending
                                  select p).ToList();

            if (items.Count > 0)
                return items.First();

            return null;
        }

        public static Branch GetBranch(Branch item)
        {
            dataContext = new RavenPXDataContext();

            List<Branch> items = (from p in dataContext.Branches
                                  orderby p.ID descending
                                  where p.ID == item.ID 
                                  && p.LocationName == item.LocationName 
                                  && p.Address == item.Address 
                                  && p.PhoneNumber == item.PhoneNumber
                                  && p.ZipCode == item.ZipCode 
                                  select p).ToList();

            if (items.Count > 0)
                return items.First();

            return null;
        }

        public static bool Delete(Guid ID)
        {
            dataContext = new RavenPXDataContext();

            Branch item = GetBranch(ID, dataContext);

            if (item != null)
            {
                dataContext.Branches.DeleteOnSubmit(item);

                dataContext.SubmitChanges();

                if (GetBranch(ID, dataContext) == null)
                    return true;
            }

            return false;
        }

        public static bool SubmitChanges(Branch item)
        {

            if (item != null)
            {
                dataContext = new RavenPXDataContext();

                if (item.ID != Guid.Empty)
                {
                    Branch oldBranch = GetBranch(item.ID, dataContext);

                    if (oldBranch != null)
                    {
                        oldBranch.LocationName = item.LocationName;

                        oldBranch.Address = item.Address;

                        oldBranch.PhoneNumber = item.PhoneNumber;

                        oldBranch.ZipCode = item.ZipCode;

                        dataContext.SubmitChanges();

                        if (GetBranch(oldBranch) != null)
                            return true;

                    }
                    else
                    { 
                        //should not happen
                    }

                }
                else
                {
                    Branch newBranch = new Branch();

                    newBranch.ID = Guid.NewGuid();

                    newBranch.LocationName = item.LocationName;

                    newBranch.Address = item.Address;

                    newBranch.PhoneNumber = item.PhoneNumber;

                    newBranch.ZipCode = item.ZipCode;

                    dataContext.Branches.InsertOnSubmit(newBranch);

                    dataContext.SubmitChanges();

                    if (GetBranch(newBranch) != null)
                        return true;
                }
            }

            return false;
            
        }
    }
}
