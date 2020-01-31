using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public partial class StaffTimeModelContainer
    {
        public override DbSet<TEntity> Set<TEntity>()
        {
            return base.Set<TEntity>();
        }

        public override DbSet Set(Type entityType)
        {
            return base.Set(entityType);
        }

        protected override bool ShouldValidateEntity(DbEntityEntry entityEntry)
        {
            return base.ShouldValidateEntity(entityEntry);
        }

        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            return base.ValidateEntity(entityEntry, items);
        }

        public User CreateUser(string name, string login, string passwd, RoleEnum role)
        {
            var user = new User
            {
                Login = login,
                UserName = name,
                Password = passwd.GetHashCode().ToString(),
                Role = (short) role,

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
                user.Password = newPasswd.GetHashCode().ToString();
            }
            SaveChanges();
            return user;
        }
    }

    /// <summary> роли пользователей  </summary>
    public enum RoleEnum : short
    {
        User,
        Admin
    }
}
