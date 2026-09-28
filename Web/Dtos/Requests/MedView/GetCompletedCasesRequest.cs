using Core.Dtos.MedView;

namespace Web.Dtos.Requests.MedView;

public sealed class GetCompletedCasesRequest
{
    public CompletedCasesSearchFilters Filters { get; set; } = new();
}
