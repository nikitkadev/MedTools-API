namespace Core.Common.Results;

public sealed record PagedResult<T>(
    IReadOnlyCollection<T> Records,
    int TotalCount);

