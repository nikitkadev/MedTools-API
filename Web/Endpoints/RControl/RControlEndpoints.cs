using MediatR;

using Core.Enums;

using Application.Queries.RContol.Categories.NazNapr.GetNazNaprDataCommand;
using Application.Queries.RContol.Categories.DefectsSanks.GetSanksDataCommand;
using Application.Queries.RContol.Categories.DefectsSanks.GetDefectsDataCommand;

using Web.Registration.Endpoints;
using Web.Endpoints.RControl.Lookups;
using Web.Endpoints.RControl.Invoices;
using Web.Endpoints.RControl.Oncology;
using Web.Endpoints.RControl.MedicalCases;
using Web.Endpoints.RControl.CompletedCases;
using Web.Endpoints.RControl.ProvidedServices;
using Web.Endpoints.RControl.ClinicalGroups;

namespace Web.Endpoints.RControl;

public class RControlEndpoints : IEndpoint
{
    public void Register(IEndpointRouteBuilder endpointsBuilder)
    {
        var group = endpointsBuilder.MapGroup("/rcontrol").WithTags("RControlData");

        group.MapLookups();
        group.MapInvoiceEndpoints();
        group.MapMedicationEndpoints();
        group.MapMedicalCaseEndpoints();
        group.MapOncologyCaseEndpoints();
        group.MapCompletedCaseEndpoints();
        group.MapOncologyServiceEndpoints();
        group.MapProvidedServiceEndpoints();
        group.MapClinicalGroupEndpoints();

        group.MapGet("/categories/naz-napr", GetNazNaprCategoryData);
        group.MapGet("/categories/defects-sanks/sanks", GetSanksDataAsync);
        group.MapGet("/categories/defects-sanks/defects", GetDefectsDataAsync);
        
    }
    
    private static async Task<IResult> GetNazNaprCategoryData(
        int sluchUid,
        string targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
           request: new GetNazNaprDataCommand(
               SluchUid: sluchUid,
               TargetDb: Enum.Parse<TargetDbType>(targetDb)),
           cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

    private static async Task<IResult> GetSanksDataAsync(
        int sluchUid,
        string targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
           request: new GetSanksDataCommand(
               SluchUid: sluchUid,
               TargetDb: Enum.Parse<TargetDbType>(targetDb)),
           cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }

    private static async Task<IResult> GetDefectsDataAsync(
        int sluchUid,
        string targetDb,
        int page,
        int pageSize,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
           request: new GetDefectsDataCommand(
               SluchUid: sluchUid,
               TargetDb: Enum.Parse<TargetDbType>(targetDb),
               Page: page,
               PageSize: pageSize),
           cancellationToken: cancellationToken);

        if (result.IsFailure)
        {
            return Results.BadRequest(result);
        }

        return Results.Ok(result);
    }
}