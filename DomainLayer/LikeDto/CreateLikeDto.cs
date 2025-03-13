using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class CreateLikeDto
    {
        public int PostId { get; set; }
        public string UserId { get; set; }
    }
}
