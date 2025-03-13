using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface IComment
    {
        /// <summary>
        /// Create a comment
        /// </summary>
        /// <param name="comment"></param>
        /// <returns>Object of Comment</returns>
        Comment Create(Comment comment);

        /// <summary>
        /// Get all Comments
        /// </summary>
        /// <returns>List of Comment</returns>
        List<Comment> GetAll();

        /// <summary>
        /// Get a Comment
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Object of Comment</returns>
        Comment? Get(int id);

        /// <summary>
        /// Update Comment
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        Comment? Update(Comment comment);

        /// <summary>
        /// Delete comment
        /// </summary>
        /// <param name="comment"></param>
        void Delete(Comment comment);
    }
}
