using Core.Dtos.RControl.ProvidedServices;

namespace Application.Queries.RControl.ProvidedServices.GetMedicalDevicesQuery;

public sealed record GetMedicalDevicesResult(IReadOnlyCollection<MedicalDeviceDto> MedicalDevices);
