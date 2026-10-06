namespace Infrastructure.Database.DbEntities.References;

public sealed class MedicalOrganizationDbEntity
{
    public int Uid { get; set; }

    public string? MedicalOrganizationCode { get; set; } 
    public string? MedicalOrganizationShortname { get; set; }
}
