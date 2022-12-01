using DataAccess.Concrete;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ITaskDAL : IRepository<EntTask>
    {

        public List<EntTask> GetTaskWithComment();

    }
}
