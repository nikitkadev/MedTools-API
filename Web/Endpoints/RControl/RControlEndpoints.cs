using Web.Registration.Endpoints;
using Web.Endpoints.RControl.Sources;

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
        
    }
}