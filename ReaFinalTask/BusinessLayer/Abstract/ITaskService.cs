using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ITaskService
    {
        public int AddTask(EntTask task);
        public int UpdateTask(EntTask task);

        public int DeleteTask(EntTask task);

        List<EntTask> ListTasks();

        List<EntTask> GetTaskWithComments();
        EntTask GetTaskById(int id);
    }
}
