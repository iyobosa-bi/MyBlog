using DataAccessLayer.Data;
using DataAccessLayer.IRepository;
using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class CommentRepository : IComment
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CommentRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        //functiont to create a comment
        public Comment Create(Comment comment)
        {
            _applicationDbContext.Add(comment);
            _applicationDbContext.SaveChanges();

            return comment;
        }

        //function to delete a comment
        public void Delete(Comment comment)
        {
            _applicationDbContext.Remove(comment);
            _applicationDbContext.SaveChanges();
        }

        //function to get a single comment
        public Comment? Get(int id)
        {
            Comment? comment = _applicationDbContext.Comments.Find(id);

            return comment;
        }

        //function to get all comments
        public List<Comment> GetAll()
        {
            return _applicationDbContext.Comments.ToList();
        }

        //function to update a comment
        public Comment? Update(Comment comment)
        {
            Comment? existingComment = _applicationDbContext.Comments.Find(comment.Id);

            existingComment.Content = comment.Content;

            _applicationDbContext.Comments.Update(existingComment);
            _applicationDbContext.SaveChanges();

            return existingComment;
 
        }
    }
}
