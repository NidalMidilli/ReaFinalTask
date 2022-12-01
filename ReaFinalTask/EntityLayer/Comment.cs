using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Comment
    {
        [Key]
        public int commentId { get; set; }

        public string commentText { get; set; }

        public virtual ICollection<EntTask> Tasks { get; set; }
    }
}
