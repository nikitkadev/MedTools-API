using Core.Common.Enums;
using Core.Dtos.MedView;

namespace Web.Dtos.Requests.MedView;

public sealed class GetCompletedCasesRequest
{
    public CompletedCasesSearchFilters Filters { get; set; } = new();
    public PaginationState Pagination { get; set; } = new();
    public TargetDbType TargetDb { get; set; }
}

public sealed class PaginationState
{
    public int Page { get; set; }
    public int PageSize { get; set; }
}
