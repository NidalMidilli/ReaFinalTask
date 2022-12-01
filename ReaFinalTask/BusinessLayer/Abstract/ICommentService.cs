using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService
    {
        public int AddComment(Comment comment);

        public int UpdateComment(Comment comment);

        public int DeleteComment(Comment comment);

        List<Comment> ListAllComments();

        Comment GetCommentById(int id);
    }
}
