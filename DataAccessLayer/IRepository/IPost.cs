using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface IPost
    {
        /// <summary>
        /// Create a Post
        /// </summary>
        /// <param name="post"></param>
        /// <returns>Object of Post</returns>
        Post Create(Post post);

        /// <summary>
        /// Get all Post
        /// </summary>
        /// <returns>List of Posts</returns>
        List<Post> GetAll();

        /// <summary>
        /// Delete Post
        /// </summary>
        void Delete(Post post);

        /// <summary>
        /// Get a single Post
        /// </summary>
        /// <param name="post"></param>
        /// <returns>Object of Post</returns>
        Post? Get(int id);

        /// <summary>
        /// Update Post
        /// </summary>
        /// <param name="post"></param>
        /// <returns>Object of Post</returns>
        Post? Update(Post post);
    }
}
