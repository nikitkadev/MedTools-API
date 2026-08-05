using MediatR;

namespace Web.Endpoints.RControl.MedicalCases;

public static class RControlMedicalCaseEndpoints
{
    public static void MapMedicalCaseEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("/medical-cases").WithTags("RControl Medical Cases");

        group.MapGet("", GetMedicalCasesAsync);
    }

    private static async Task<IResult> GetMedicalCasesAsync(
        int completedCaseUid,
        string targetDb,
        ISender sender,
        CancellationToken cancellationToken)
    {
        return Results.Ok();
    }
}