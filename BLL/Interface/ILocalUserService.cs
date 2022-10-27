using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface ILocalUserService
    {
        IEnumerable<User> GetAll();
        User Login(string email, string password);
        bool UserSwapStatus(int id);
        bool RegisterUser(string nickname, string email, string password, DateOnly birthdate, int idRole);
        bool UpdateUser(int idUser, string nickname, string email, DateOnly birthdate);
        public User GetOne(int idUser);
    }
}
