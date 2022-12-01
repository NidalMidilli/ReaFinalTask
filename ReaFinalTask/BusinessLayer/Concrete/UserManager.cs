using BusinessLayer.Abstract;
using DataAccess.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUserDAL userdal;

        public UserManager(IUserDAL userdal)
        {
            this.userdal = userdal;       
        }
        public int AddUser(User user)
        {
            return userdal.Add(user);

        }

        public int DeleteUser(User user)
        {
            return userdal.Delete(user);
        }

        public User GetById(int id)
        {
            return userdal.GetById(id);
        }

        public List<User> ListAllUsers()
        {
            return userdal.ListAll();
        }

        public int UpdateUser(User user)
        {
            return userdal.Update(user);
        }
    }
}
