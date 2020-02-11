using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public partial class StaffTimeDbContainer
    {

        public User CreateUser(string name, string login, string passwd, StaffRole role)
        {
            var user = new User
            {
                Login = login,
                UserName = name,
                Password = passwd,//.GetHashCode().ToString(),
                Role = role,

            };
            User.Add(user);
            SaveChanges();
            return user;
        }

        public User ChangeUserPassword(int id, string newPasswd)
        {
            var user = User.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.Password = newPasswd;//.GetHashCode().ToString();
            }
            SaveChanges();
            return user;
        }

        /// <summary>
        /// Взять пользователя по паре логин/пароль
        /// </summary>
        /// <param name="login"></param>
        /// <param name="passwd"></param>
        /// <returns></returns>
        public User GetUser(string login, string passwd)
        {
            return User.FirstOrDefault(user => user.Login == login && user.Password == passwd);
        }
    }
}
