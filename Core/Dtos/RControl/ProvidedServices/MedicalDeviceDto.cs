namespace Core.Dtos.RControl.ProvidedServices;

public sealed record MedicalDeviceDto(
    int MedicalDeviceUid,
    DateTime ImplantationDate,
    int MedicalDeviceTypeCode,
    string SerialNumber);
