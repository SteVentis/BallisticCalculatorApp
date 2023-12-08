using Modules.Security.Domain.Errors;

namespace Modules.Security.Domain.Shared;

public class TResult<TResponse> : Result
{
    protected TResult(bool isSuccess, Error error, TResponse value) : base(isSuccess, error)
    {
        Value = value;
    }

    public TResponse Value { get; }

    public static TResult<TResponse> Success(TResponse entity) => new TResult<TResponse>(true, Error.None, entity);

    public static TResult<TResponse> Failure(Error error, TResponse? entity) => new TResult<TResponse>(false, error, entity!);
}
