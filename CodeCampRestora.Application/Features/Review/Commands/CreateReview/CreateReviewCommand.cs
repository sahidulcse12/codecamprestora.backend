using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Application.Features.Review.Commands.CreateReview
{
    public class CreateReviewCommand : ICommand<IResult<ReviewDTO>>
    {
        public Guid ReviewId { get; set; }
        public Guid BranchId { set; get; }
        public required string Description { set; get; }
        public  required int Rating { set; get; }
        public Guid OrderId { set; get; }
    }
}
