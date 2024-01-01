using Microsoft.AspNetCore.Http;

namespace CodeCampRestora.Application.Models;

public interface IResult
{
    public int StatusCode { get; }
    public IReadOnlyList<Error> Errors { get; }
    public bool IsSuccess { get; }
}

public class Result : IResult
{
    public int StatusCode { get; }
    public IReadOnlyList<Error> Errors { get; }

    protected Result(int statusCode, List<Error> errors)
    {
        StatusCode = statusCode;
        Errors = errors;
    }

    public bool IsSuccess => StatusCode >= 200 && StatusCode <= 300;
    public static Result Success(int statusCode) => new(statusCode, new());
    public static Result Success() => Success(StatusCodes.Status200OK);
    public static Result Failure(int statusCode, List<Error> errors) => new(statusCode, errors);
    public static Result Failure() => Failure(StatusCodes.Status400BadRequest, new());
    public static Result Failure(List<Error> errors) => Failure(StatusCodes.Status400BadRequest, errors);
    public static Result Failure(int statusCode) => Failure(statusCode, new());
}