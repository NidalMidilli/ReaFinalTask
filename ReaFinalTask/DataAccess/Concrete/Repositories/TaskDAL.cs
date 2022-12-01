using DataAccess.Abstract;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Repositories
{
    public class TaskDAL:Repository<EntTask>,ITaskDAL
    {
        Context con = new Context();

        public List<EntTask> GetTaskWithComment()
        {
            return con.Tasks.Include(x => x.Comment).ToList();
        }
    }
}
