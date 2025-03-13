using BusinessLogicLayer.IServices;
using DataAccessLayer.UnitOfWorkFolder;
using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class LikeService : ILikeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LikeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Like? CreateLike(Like like, out string message)
        {
            // Ensure the like object is not null
            if (like == null)
            {
                message = "Like data is invalid.";
                return null;
            }

            // Validate UserId
            if (string.IsNullOrWhiteSpace(like.UserId))
            {
                message = "User ID cannot be empty or whitespace.";
                return null;
            }

            // Validate PostId
            if (like.PostId <= 0)
            {
                message = "Invalid Post ID.";
                return null;
            }

            // Check if the like already exists for the user and post
            var existingLike = _unitOfWork.likeRepository
                .GetAll()
                .FirstOrDefault(l => l.UserId == like.UserId && l.PostId == like.PostId);

            if (existingLike != null)
            {
                message = "User has already liked this post.";
                return null;
            }

            message = "Like created successfully.";
            return _unitOfWork.likeRepository.Create(like);
        }

        public bool DeleteLike(int id, out string message)
        {
            // Validate ID
            if (id <= 0)
            {
                message = "Invalid like ID.";
                return false;
            }

            Like? like = _unitOfWork.likeRepository.Get(id);

            // Check if like exists
            if (like == null)
            {
                message = "Like not found.";
                return false;
            }

            _unitOfWork.likeRepository.Delete(like);
            message = "Like successfully deleted.";
            return true;
        }

        public List<Like> GetAllLike()
        {
            return _unitOfWork.likeRepository.GetAll();
        }

        public Like? GetLike(int id)
        {
            // Validate ID
            if (id <= 0)
            {
                return null;
            }

            return _unitOfWork.likeRepository.Get(id);
        }
    }
}
