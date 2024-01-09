using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Application.DTOs
{
    public class ReviewDTO
    {
        public string Description { set; get; }
        public int Rating { set; get; }
        public Guid OrderId { set; get; }
    }
}
