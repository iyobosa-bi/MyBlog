using AutoMapper;
using DomainLayer.CommentDto;
using DomainLayer.CommentDtp;
using DomainLayer.DTO;
using DomainLayer.LikeDto;
using DomainLayer.Model;
using DomainLayer.PostDto;
using DomainLayer.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Configuration
{
    public class MapperInitialiser: Profile
    {
        public MapperInitialiser()
        {
            //mappers for users
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();

            //mappers for posts
            CreateMap<Post, CreatePostDto>().ReverseMap();
            CreateMap<Post, UpdatePostDto>().ReverseMap();
            CreateMap<Post, PostDto>().ReverseMap();

            //Mappers for comments
            CreateMap<Comment, CreatCommentDto>().ReverseMap();
            CreateMap<Comment, UpdateCommentDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();

            // Mappers for likes
            CreateMap<Like, CreateLikeDto>().ReverseMap();
            //CreateMap<Like, UpdateLikeDto>().ReverseMap();
            CreateMap<Like, LikeDto>().ReverseMap();
        }
    }
}
