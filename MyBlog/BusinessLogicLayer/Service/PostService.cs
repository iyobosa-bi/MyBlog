using BusinessLogicLayer.IServices;
using DataAccessLayer.UnitOfWorkFolder;
using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Post? CreatePost(Post post, out string message)
        {
            // Ensure post object is not null
            if (post == null)
            {
                message = "Invalid post data.";
                return null;
            }

            // Validate Content
            if (string.IsNullOrWhiteSpace(post.Content))
            {
                message = "Content cannot be empty.";
                return null;
            }

            // Validate Title
            if (string.IsNullOrWhiteSpace(post.Title))
            {
                message = "Title cannot be empty.";
                return null;
            }

            // Validate UserId
            if (string.IsNullOrWhiteSpace(post.UserId))
            {
                message = "User ID cannot be empty.";
                return null;
            }

            // Check if post with the same title already exists (optional)
            var existingPost = _unitOfWork.postRepository
                .GetAll()
                .FirstOrDefault(p => p.Title == post.Title && p.UserId == post.UserId);

            if (existingPost != null)
            {
                message = "A post with this title already exists.";
                return null;
            }

            message = "Post created successfully.";
            return _unitOfWork.postRepository.Create(post);
        }

        public bool DeletePost(int id, out string message)
        {
            // Validate ID
            if (id <= 0)
            {
                message = "Invalid post ID.";
                return false;
            }

            Post? post = _unitOfWork.postRepository.Get(id);

            // Check if post exists
            if (post == null)
            {
                message = "Post not found.";
                return false;
            }

            _unitOfWork.postRepository.Delete(post);
            message = "Post deleted successfully.";
            return true;
        }

        public List<Post> GetAllPost()
        {
            return _unitOfWork.postRepository.GetAll();
        }

        public Post? GetPost(int id)
        {
            // Validate ID
            if (id <= 0)
            {
                return null;
            }

            return _unitOfWork.postRepository.Get(id);
        }

        public Post? UpdatePost(Post post, out string message)
        {
            // Ensure post object is not null
            if (post == null)
            {
                message = "Invalid post data.";
                return null;
            }

            // Validate Content
            if (string.IsNullOrWhiteSpace(post.Content))
            {
                message = "Content cannot be empty.";
                return null;
            }

            // Validate Title
            if (string.IsNullOrWhiteSpace(post.Title))
            {
                message = "Title cannot be empty.";
                return null;
            }

            Post? updatedPost = _unitOfWork.postRepository.Update(post);

            // Check if post exists before updating
            if (updatedPost is null)
            {
                message = "Post does not exist.";
                return null;
            }

            message = "Post updated successfully.";
            return updatedPost;
        }
    }
}
