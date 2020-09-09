using Interview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.Interface
{
   public interface ISubUser
    {
        public List<InSubUserDetails> GetSubUser();
        public Result AddSubUser(subUserDetails inSubUser);
        public Result UpdateSubUser(subUserDetails inSubUser);
        public Result DeleteInSubUser(string id);
    }
}
