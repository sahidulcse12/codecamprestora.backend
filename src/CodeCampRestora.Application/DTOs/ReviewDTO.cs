﻿using CodeCampRestora.Domain.Entities;

namespace CodeCampRestora.Application.DTOs;

public class ReviewDTO
{

    public string? Description { set; get; }
    public double Rating { set; get; }
    public bool IsReviewHidden { get; set; }
    public IList<ReviewCommentDTO>? ReviewComments { get; set; }
}
