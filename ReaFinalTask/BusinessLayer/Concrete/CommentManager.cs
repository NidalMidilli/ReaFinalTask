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
    public class CommentManager : ICommentService
    {
        ICommentDAL commentDAL;
        public CommentManager(ICommentDAL commentDAL)
        {
            this.commentDAL = commentDAL;
        }
        public int AddComment(Comment comment)
        {
            return commentDAL.Add(comment);
        }

        public int DeleteComment(Comment comment)
        {
            return commentDAL.Delete(comment);
        }

        public Comment GetCommentById(int id)
        {
            return commentDAL.GetById(id);
        }

        public List<Comment> ListAllComments()
        {
            return commentDAL.ListAll();
        }

        public int UpdateComment(Comment comment)
        {
            return commentDAL.Update(comment);
        }
    }
}
