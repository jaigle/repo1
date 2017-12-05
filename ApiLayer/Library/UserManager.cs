using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Test.Entities;

namespace ApiLayer.Library
{
    public class UserManager : BaseManager
    {
        public UserManager()
        {

        }

        public ResultModel GetUsers(string token)
        {
            ResultModel resultModel = CheckToken(token);
            if (resultModel.Result)
            {
                resultModel.Payload = Tools.Base64Encode(JsonConvert.SerializeObject(BuiltList()));

            }
            return resultModel;
        }

        public ResultModel GetUsersByRol(string token,string rol )
        {
            ResultModel resultModel = CheckToken(token);
            var users = BuiltList();

            var usersByRol = users.Where(i => i.Rol == rol).ToList();
                            
            if (resultModel.Result)
            {
                resultModel.Payload = Tools.Base64Encode(JsonConvert.SerializeObject(usersByRol));

            }
            return resultModel;
        }//ud es un templao asere!!!

        private List<SystemUser> BuiltList()
        {
            List<SystemUser> users = new List<SystemUser>
        {
            new SystemUser() {DepartmentID = 1, Rol = "ADMIN", UserName = "Jaigle Cocojjjjjj"},
            new SystemUser() {DepartmentID = 2, Rol = "USER", UserName = "Hassan "},
            new SystemUser() {DepartmentID = 56, Rol = "AUDITOR", UserName = "Raudel Perez j"},
            new SystemUser() {DepartmentID = 4, Rol = "ADMIN", UserName = "Fidel Castro"},
        };

            return users;
        }
    }

    public class SystemUser
    {
        public SystemUser()
        {

        }
        public string UserName { get; set; }
        public string Rol { get; set; }
        public int DepartmentID { get; set; }
    }
}