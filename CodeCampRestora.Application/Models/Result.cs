using Microsoft.AspNetCore.Http;

namespace CodeCampRestora.Application.Models;

public interface IResult
{
    public int StatusCode { get; }
    public Error[] Errors { get; }
    public bool IsSuccess { get; }
}

public class Result : IResult
{
    public int StatusCode { get; }
    public Error[] Errors { get; }

    protected Result(int statusCode, Error[] errors)
    {
        StatusCode = statusCode;
        Errors = errors;
    }

    public bool IsSuccess => StatusCode >= 200 && StatusCode <= 300;
    public static Result Success(int statusCode) => new(statusCode, Array.Empty<Error>());
    public static Result Success() => Success(StatusCodes.Status200OK);
    public static Result Failure(int statusCode, params Error[] errors) => new(statusCode, errors);
    public static Result Failure() => Failure(StatusCodes.Status400BadRequest, Array.Empty<Error>());
    public static Result Failure(params Error[] errors) => Failure(StatusCodes.Status400BadRequest, errors);
}

public interface IResult<T> : IResult
{
    T Data { get; }
}

public interface IResult<T, D>: IResult
{
    string B {get;}
}

public class Result<T> : Result, IResult<T>
{
    public T Data { get; }

    protected Result(int statusCode, T data, Error[] errors) : base(statusCode, errors)
    {
        Data = data;
    }

    public static Result<T> Success(T data) => new(StatusCodes.Status200OK, data, Array.Empty<Error>());
    public static Result<T> Success(int statusCode, T data) => new(statusCode, data, Array.Empty<Error>());
    public static Result<T> Success(int statusCode, T data, params Error[] errors) => new(statusCode, data, errors);
    public new static Result<T> Failure(params Error[] errors) => new(StatusCodes.Status400BadRequest, default!, errors);
    public new static Result<T> Failure(int statusCode, params Error[] errors) => new(statusCode, default!, errors);
}

public interface IAuthResult : IResult
{
    string AccessToken { get; }
    string RefreshToken { get; }
    DateTime ExpiresIn { get; }
    string UserId { get; }
    string RestaurantId { get; }
}

public class AuthResult : Result, IAuthResult
{
    public string AccessToken { get; }
    public string RefreshToken { get; }
    public DateTime ExpiresIn { get; }
    public string UserId { get; }
    public string RestaurantId { get; }
    public IEnumerable<string> Roles { get; }

    private AuthResult(int statusCode, Error[] errors, string accessToken, string refreshToken, DateTime expiresIn,
         string userId, string restaurantId, IEnumerable<string> roles) : base(statusCode, errors)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
        ExpiresIn = expiresIn;
        UserId = userId;
        RestaurantId = restaurantId;
        Roles = roles;
    }

    private AuthResult(int statusCode, Error[] errors) : this(statusCode, errors, string.Empty,
         string.Empty, DateTime.UtcNow, string.Empty, string.Empty, new List<string>())
    {

    }

    public static AuthResult Success(string accessToken, string refreshToken, DateTime
        expiresIn, string userId, string restaurantId, IEnumerable<string> roles) =>
        new(StatusCodes.Status200OK, Array.Empty<Error>(), accessToken, refreshToken, expiresIn, userId, restaurantId, roles);

    public new static AuthResult Failure(params Error[] errors) => new(StatusCodes.Status400BadRequest, errors);
    public new static AuthResult Failure(int statusCode, params Error[] errors) => new(statusCode, errors);
}