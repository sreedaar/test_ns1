using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RavenWebPayroll.Common.Components.DTO;

namespace RavenWebPayroll.Common.Components.Interfaces
{
    public interface IBranches
    {
        void LoadData();

        void SubmitChanges(BranchDTO branchDTO);

        void LoadEntry(Guid ID);

        void DeleteEntry(Guid ID);

        void IsExisting(string branchName);
    }
}
