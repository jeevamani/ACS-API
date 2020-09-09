using Interview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Interview.Interface
{
  public  interface IUser
    {
        public Result Login(string username, string password, bool? Role, string baseulr);
        public List<InUsers> GetUsers();
        public Result AddUser(userDetails inUsers);
        public Result UpdateUser(userDetails inUsers);
        public Result DeleteUser(string Id);
        public List<AdminUserDetails> GetAdminUsers(string role);
        public Result AddAdminUser(AdminUserDetails adminUsers);
        public Result UpdateAdminUser(AdminUsers adminUsers);

        public Result DeleteAdminUser(string Id);
        public List<configDDL> GetConfigurationDDl();
        public List<InDepartment> GetDepartments();
        public List<InDesignation> GetInDesignations();
        public List<InUserRole> GetUserRoles();
        public Result SaveFileUpload(string key);
        public List<InFileUpload> EditFileUpload(string Id);

        public Result DeleteUpload(string Id);

    }
}
