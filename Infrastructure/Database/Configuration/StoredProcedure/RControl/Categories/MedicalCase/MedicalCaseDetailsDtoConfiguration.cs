using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Core.Dtos.RControl.Categories.MedicalCase;

namespace Infrastructure.Database.Configuration.StoredProcedure.RControl.Categories.MedicalCase;

public class MedicalCaseDetailsDtoConfiguration : IEntityTypeConfiguration<MedicalCaseDetailsDto>
{
    public void Configure(EntityTypeBuilder<MedicalCaseDetailsDto> builder)
    {
        builder.HasNoKey();

        builder.Property(prop => prop.MedicalProfile).HasColumnName("profil");
        builder.Property(prop => prop.PhysicianSpecialty).HasColumnName("prvs");
        builder.Property(prop => prop.TreatmentStartDate).HasColumnName("date_1");
        builder.Property(prop => prop.TreatmentEndDate).HasColumnName("date_2");
        builder.Property(prop => prop.PrimaryDiagnosis).HasColumnName("ds1");
        builder.Property(prop => prop.PaidUnits).HasColumnName("ed_col").IsRequired(false);
        builder.Property(prop => prop.Department).HasColumnName("lpu_1").IsRequired(false);
        builder.Property(prop => prop.DepartmentCode).HasColumnName("podr").IsRequired(false);
        builder.Property(prop => prop.IsPediatric).HasColumnName("det");
        builder.Property(prop => prop.VisitPurpose).HasColumnName("p_cel").IsRequired(false);
        builder.Property(prop => prop.BedProfile).HasColumnName("profil_k").IsRequired(false);
        builder.Property(prop => prop.MedicalRecordNumber).HasColumnName("history");
        builder.Property(prop => prop.IsAdmissionTransfer).HasColumnName("p_per").IsRequired(false);
        builder.Property(prop => prop.IsRehabilitation).HasColumnName("reab").IsRequired(false);
        builder.Property(prop => prop.HospitalizationDuration).HasColumnName("kd").IsRequired(false);
        builder.Property(prop => prop.FacilityLevel).HasColumnName("lpu_level").IsRequired(false);
        builder.Property(prop => prop.InitialDiagnosis).HasColumnName("ds0").IsRequired(false);
        builder.Property(prop => prop.IsOncologySuspicion).HasColumnName("ds_onk").IsRequired(false);
        builder.Property(prop => prop.PhysicianCode).HasColumnName("iddokt");
        builder.Property(prop => prop.Weight).HasColumnName("wei").IsRequired(false);
        builder.Property(prop => prop.DiseaseCharacter).HasColumnName("c_zab").IsRequired(false);
        builder.Property(prop => prop.InternalComment).HasColumnName("comentsl").IsRequired(false);
    }
}
