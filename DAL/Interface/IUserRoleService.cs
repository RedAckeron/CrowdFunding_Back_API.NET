using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IUserRoleService
    {
        public IEnumerable<Role> GetRolesByUser(int userId);
        public bool UserRoleAddOwner(int id);
        public bool UserRoleRemoveOwner(int id);
        bool RegisterRoleUser(string email, int idRole);
    }
}
