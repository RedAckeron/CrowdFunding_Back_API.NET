using DAL.Interface;
using DAL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox;
using ToolBox.Mapper;
using ToolBox.Models;

namespace DAL.Repositories
{
    public class UserRoleRepo : Connection, IUserRoleService
    {
        public UserRoleRepo(IConfiguration config) : base(config)
        {        
        }

        public IEnumerable<Role> GetRolesByUser(int userId)
        {
            Command cmd = new Command("Role_User", true);
            cmd.AddParameter("userId", userId);

            return ExecuteReader<Role>(cmd);    
        }

        public bool RegisterRoleUser(string email, int idRole)
        {
            Command cmd = new Command("UserRoleRegister", true);

            cmd.AddParameter("email", email);
            cmd.AddParameter("idRole", idRole);

            return ExecuteNonQuery(cmd) == 1;
        }
        /// <summary>
        /// Ajoute le role Owner a l user 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UserRoleAddOwner(int id)
        {
            Command cmd = new Command("insert into User_Role (idRole,IdUser)values (3,@idUser);");
            cmd.AddParameter("idUser", id);
            return ExecuteNonQuery(cmd) == 1;
        }
        /// <summary>
        /// Retirer le role de owner
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UserRoleRemoveOwner(int id)
        {
            Command cmd = new Command("delete from User_Role where IdUser=@idUser and IdRole=3;");
            cmd.AddParameter("idUser", id);
            return ExecuteNonQuery(cmd) == 1;
        }
    }
}