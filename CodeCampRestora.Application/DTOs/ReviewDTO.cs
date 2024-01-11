using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Application.DTOs
{
    public class ReviewDTO
    {
        public Guid ReviewId { get; set; }
        public required string Description { set; get; }
        public required int Rating { set; get; }
        public Guid OrderId { set; get; }
        public Guid BranchId {  set; get; }
        public bool HideReview { get; set; }
        
    }
}
