using MediatR;

using Core.Common.Dtos;
using Core.Common.Results;
using Core.Interfaces.Providers.MedView.ReferenceDataProviders;

namespace Application.Queries.MedView.Filters.GetDiagnosticMethodFilterOptionsQuery;

public sealed class GetDiagnosticMethodFilterOptionsQueryHandler(
    IMedicalCareReferenceDataProvider medicalCareReferenceDataProvider) : IRequestHandler<GetDiagnosticMethodFilterOptionsQuery, Result<GetDiagnosticMethodFilterOptionsResult>>
{
    public async Task<Result<GetDiagnosticMethodFilterOptionsResult>> Handle(
        GetDiagnosticMethodFilterOptionsQuery request,
        CancellationToken cancellationToken)
    {
        var diagnosticMethods = await medicalCareReferenceDataProvider.GetDiagnosticMethodReferencesAsync(
            cancellationToken: cancellationToken);

        return Result<GetDiagnosticMethodFilterOptionsResult>.Success(
            new GetDiagnosticMethodFilterOptionsResult(
                FilterOptions: [.. diagnosticMethods.Select(x => new FilterOptionDto(
                    Value: x.Id.ToString(),
                    Label: x.Name))]));
    }
}
