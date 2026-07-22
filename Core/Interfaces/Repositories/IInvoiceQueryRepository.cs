using Core.Dtos;
using Core.Enums;
using Core.Common;

namespace Core.Interfaces.Repositories;

public interface IInvoiceQueryRepository
{
    Task<Result<InvoicesShortlyQueryResult>> GetShortlyAsync(
        string orgCode,
        int year,
        int month,
        TargetDbType dbType,
        int skip,
        int take,
        string searchString);
}