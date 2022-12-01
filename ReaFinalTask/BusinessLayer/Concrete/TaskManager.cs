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
    public class TaskManager : ITaskService
    {
        ITaskDAL taskdal;

        public TaskManager(ITaskDAL taskdal)
        {
            this.taskdal = taskdal;
        }

        public int AddTask(EntTask task)
        {
            return taskdal.Add(task);
        }

        public int DeleteTask(EntTask task)
        {
            return taskdal.Delete(task);
        }

        public EntTask GetTaskById(int id)
        {
            return taskdal.GetById(id);
        }

        public List<EntTask> GetTaskWithComments()
        {
            return taskdal.GetTaskWithComment();
        }

        public List<EntTask> ListTasks()
        {
            return taskdal.ListAll();
        }

        public int UpdateTask(EntTask task)
        {
            return taskdal.Update(task);
        }

   
    }
}
