using Modules.Security.Domain.Errors;

namespace Modules.Security.Domain.Shared;

public class TResult<TResponse> : IResult
{
    protected TResult(bool isSuccess, Error error, TResponse value) //: base(isSuccess, error)
    {
        Value = value;
    }

    public TResponse Value { get; }

    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public static TResult<TResponse> Success(TResponse entity) => new TResult<TResponse>(true, Error.None, entity);

    public static TResult<TResponse> Failure(Error error, TResponse? entity) => new TResult<TResponse>(false, error, entity!);
}
