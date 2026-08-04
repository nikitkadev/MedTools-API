namespace Core.Common;

public sealed record PagedResult<T>(
    T Records,
    int Count);

