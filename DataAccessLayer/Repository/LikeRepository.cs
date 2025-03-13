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
    public class LikeRepository : ILike
    {

        private readonly ApplicationDbContext _applicationDbContext;

        public LikeRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Like Create(Like like)
        {
            _applicationDbContext.Add(like);
            _applicationDbContext.SaveChanges();

            return like;
        }

        public void Delete(Like like)
        {
            _applicationDbContext.Remove(like);
            _applicationDbContext.SaveChanges();
        }

        public Like? Get(int id)
        {
            Like? like = _applicationDbContext.Likes.Find(id);

            return like;
        }

        public List<Like> GetAll()
        {
            return _applicationDbContext.Likes.ToList();
        }

        //public Like? Update(Like like)
        //{
        //    Like? existingLike = _applicationDbContext.Likes.Find(like.Id);

        //    existingLike.
        //}
    }
}
