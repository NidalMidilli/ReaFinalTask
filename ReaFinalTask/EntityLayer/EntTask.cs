using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntTask
    {
        [Key]
        public int taskId { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public string owner { get; set; }
        public int commentId { get; set; }
        
        public virtual status status { get; set; }
        public virtual Comment Comment { get; set; }

    }
    public enum status
    {
        Created = 0,
        InProgress = 1,
        Done = 2
    }
}
