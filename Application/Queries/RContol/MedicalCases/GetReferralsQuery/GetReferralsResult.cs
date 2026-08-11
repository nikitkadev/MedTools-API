using Core.Dtos.RControl.MedicalCases;

namespace Application.Queries.RContol.MedicalCases.GetReferralsQuery;

public sealed record GetReferralsResult(IReadOnlyCollection<ReferralDto> Referrals);
