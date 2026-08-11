using Core.Dtos.RControl.Categories.MedicalCase;

namespace Application.Queries.RContol.MedicalCases.GetReferralsQuery;

public sealed record GetReferralsResult(IReadOnlyCollection<ReferralDto> Referrals);
