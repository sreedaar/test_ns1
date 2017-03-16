using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RavenWebPayroll.Data.Database;

namespace RavenWebPayroll.Data
{
    public class XSettingsDataProvider
    {
        private static RavenPXDataContext dataContext = new RavenPXDataContext();

        public static List<XSetting> GetXSettingsByModuleID(int moduleID)
        {
            dataContext = new RavenPXDataContext();

            List<XSetting> items = (from p in dataContext.XSettings
                                    where p.ModuleID == moduleID
                                    select p).ToList();

            return items;
        }

        public static bool SubmitChanges(List<XSetting> items)
        {
            if (items.Count > 0)
            {
                dataContext = new RavenPXDataContext();

                List<XSetting> insertList = new List<XSetting>();

                foreach (XSetting item in items)
                {
                    XSetting refItem = GetSetting((int)item.AppKey, dataContext);

                    if (refItem != null)
                    {
                        refItem.Value = item.Value;
                    }
                    else //create entry
                    {
                        refItem = new XSetting { ID = Guid.NewGuid(), ModuleID = item.ModuleID , AppKey = item.AppKey, Value = item.Value };

                        insertList.Add(refItem);
                    }
                }

                dataContext.XSettings.InsertAllOnSubmit(insertList);

                dataContext.SubmitChanges();

                //place a validation here
                return true;
            }

            //nothing to save
            return false;
        }

        static XSetting GetSetting(int appKey, RavenPXDataContext _dataContext)
        {
            List<XSetting> items = (from p in _dataContext.XSettings
                                    where p.AppKey == appKey
                                    select p).ToList();

            if (items.Count > 0)
                return items.First();

            return null;
        }

    }
}
