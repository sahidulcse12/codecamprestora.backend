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
        public string Description { set; get; } = string.Empty;
        public int Rating { set; get; }
        public Guid OrderId { set; get; }
    }
}
