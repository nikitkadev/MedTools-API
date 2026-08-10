using Core.Dtos.RControl.ProvidedServices;

namespace Application.Queries.RContol.ProvidedServices.GetMedicalDevicesQuery;

public sealed record GetMedicalDevicesResult(IReadOnlyCollection<MedicalDeviceDto> MedicalDevices);
