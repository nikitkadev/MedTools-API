using Core.Dtos;
using Core.Enums;
using Core.Common;

namespace Core.Interfaces.Repositories;

public interface IInvoiceSummaryRepository
{
    Task<Result<InvoiceSummaryQueryResult>> GetFromStoredProcedureAsync(int schetUid, TargetDbType targetDb);
}
