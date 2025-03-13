
using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLogicLayer.IServices
{
    public interface IPostService
    {
        /// <summary>
        /// Create a Post
        /// </summary>
        /// <param name="post"></param>
        /// <param name="message"></param>
        /// <returns>Object of Post</returns>
        Post? CreatePost(Post post, out string message);

        /// <summary>
        /// Get all posts
        /// </summary>
        /// <returns>List of Post</returns>
        List<Post> GetAllPost();

        /// <summary>
        /// Get a sungle Post
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Object of Post</returns>
        Post? GetPost(int id);

        /// <summary>
        /// Update Post
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        Post? UpdatePost(Post post, out string message);

        /// <summary>
        /// Delete Post
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Boolean true or false</returns>
        bool DeletePost(int id, out string message);
    }
}
