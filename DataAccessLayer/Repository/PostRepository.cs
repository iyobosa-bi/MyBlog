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
    public class PostRepository : IPost
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PostRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        //function to create a post
        public Post Create(Post post)
        {
            _applicationDbContext.Add(post);
            _applicationDbContext.SaveChanges();

            return post;
        }

        //funciton to delete a post
        public void Delete(Post post)
        {
            _applicationDbContext.Remove(post);
            _applicationDbContext.SaveChanges();
        }

        //function to get a single post
        public Post? Get(int id)
        {
            Post? post = _applicationDbContext.Posts.Find(id);

            return post;
        }

        //function to get all posts
        public List<Post> GetAll()
        {
            return _applicationDbContext.Posts.ToList();
        }

        //function to update a post
        public Post? Update(Post post)
        {
            Post? existingPost = _applicationDbContext.Posts.Find(post.Id);

            existingPost.Title = post.Title;
            existingPost.Content = post.Content;

            _applicationDbContext.Posts.Update(existingPost);
            _applicationDbContext.SaveChanges();

            return existingPost;
        }
    }
}
