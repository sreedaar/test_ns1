using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using RavenWebPayroll.Common.Components.DTO;

namespace RavenWebPayroll.Common.Components.Interfaces
{
    public interface IBranchModel
    {
        bool SubmitChanges(BranchDTO branchDTO);

        DataTable GetBranches();

        BranchDTO GetBranch(Guid ID);

        bool IsExisting(string branchName);

        bool Delete(Guid ID);
    }
}
