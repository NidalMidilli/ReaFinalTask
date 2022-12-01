using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserService
    {
        public int AddUser(User user);
        public int UpdateUser(User user);

        public int DeleteUser(User user);

        List<User> ListAllUsers();

        User GetById(int id);
    }
}
