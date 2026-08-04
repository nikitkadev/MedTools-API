namespace Core.Common;

public sealed record PagedResult<T>(
    IReadOnlyCollection<T> Records,
    int TotalCount);

