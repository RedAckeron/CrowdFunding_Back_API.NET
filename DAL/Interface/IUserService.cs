using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User Login(string email, string password);
        bool RegisterUser(string nickname, string email, string password, DateOnly birthdate);
        bool UpdateUser(int id, string nickName, string email, DateOnly birthdate);
        public User GetOne(int idUser);
        public bool DeleteUser(int id);
    }
}
