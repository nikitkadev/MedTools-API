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
        
    }
}