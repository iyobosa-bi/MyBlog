using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWorkFolder
{
    public interface IUnitOfWork
    {
        UserRepository userRepository { get; }

        PostRepository postRepository { get; }

        CommentRepository commentRepository { get; }

        LikeRepository likeRepository { get;  }
    }
}
