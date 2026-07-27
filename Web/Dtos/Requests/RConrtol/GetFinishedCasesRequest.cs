using Application.Common.Requests;

namespace Web.Dtos.Requests.RConrtol;

public class GetFinishedCasesRequest
{
    public PaginationRequest Pagination { get; set; } = new();
    public DbTypeRequest DbType { get; set; } = new();
    public SearchRequest Search { get; set; } = new();

    public int SchetUid { get; set; }
}
