using Core.Dtos;
using Core.Enums;
using Core.Common;

namespace Core.Interfaces.Repositories.MainField;

public interface IInvoiceQueryRepository
{
    Task<Result<InvoicesShortlyQueryResult>> GetShortlyAsync(
        string orgCode,
        int year,
        int month,
        TargetDbType dbType,
        int page,
        int pageSize,
        string searchString);
}