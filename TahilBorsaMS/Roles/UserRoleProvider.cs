using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using TahilBorsaMS.Models.Entity;
using TahilBorsaMS.Controllers;

namespace TahilBorsaMS.Roles
{


    public class UserRoleProvider : RoleProvider
    {

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        //Burada kullanıcı tablosundan kallanıcı adlarını çekip  yetkili rol adlarıyla eşleştiriyoruz
        public override string[] GetRolesForUser(string username)
        {
        DbGrainExchangeEntities5 db = new DbGrainExchangeEntities5();
            var value = db.tblUser.FirstOrDefault(x=> x.Username == username);
            return new string[] { value.tblRol.Name };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}