using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.CommentDtp
{
    public class CreatCommentDto
    {
        public string Content { get; set; }
        public int PostId { get; set; }    
        public string UserId { get; set; }   
    }
}
