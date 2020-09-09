using Interview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.Interface
{
   public interface IBranch
    {
        public List<InBranchDetails> GetBranch();
        public Result AddBranch(InBranchDetails inBranch);
        public Result UpdateBranch(InBranchDetails inBranch);
        public Result DeleteBranch(string id);
        public List<InState> GetState();
    }
}
