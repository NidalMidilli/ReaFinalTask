using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRepository<T>
    {
        int Add(T ent);
        int Update(T ent);
        int Delete(T ent);
        T GetById(int id);
        List<T> ListAll();
    }
}
