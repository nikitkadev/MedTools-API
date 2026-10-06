namespace Infrastructure.Database.DbEntities.References;

public sealed class ComplexityCoefficientDbEntity
{
    public int Uid { get; set; }

    public string ComplexityCoefficientId { get; set; } = string.Empty;
    public string? ComplexityCoefficientName { get; set; }
}