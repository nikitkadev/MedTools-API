using Application.Common.Requests;

namespace Web.Dtos.Requests.RConrtol;

public class GetInvoicesShortlyRequest
{
    public PaginationRequest Pagination { get; set; } = new();
    public DbTypeRequest DbType { get; set; } = new();
    public SearchRequest Search { get; set; } = new();

    public string OrgCode { get; set; } = string.Empty;
    public int Year { get; set; }
    public int Month { get; set; }
}
