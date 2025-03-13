using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface ILike
    {
        /// <summary>
        /// Create a Like
        /// </summary>
        /// <param name="like"></param>
        /// <returns>Object of Like</returns>
        Like Create(Like like);

        /// <summary>
        /// Get all Likes
        /// </summary>
        /// <returns>List of Like</returns>
        List<Like> GetAll();

        /// <summary>
        /// Get a single Like
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Object of Like</returns>
        Like? Get(int id);

        /// <summary>
        /// Update Like
        /// </summary>
        /// <param name="like"></param>
        /// <returns>Object of Like</returns>
        //Like? Update(Like like);

        /// <summary>
        /// Delete Like
        /// </summary>
        /// <param name="like"></param>
        void Delete(Like like);
        
    }
}
