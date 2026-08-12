using Core.Dtos.RControl.MedicalCases;

namespace Application.Queries.RControl.MedicalCases.GetReferralsQuery;

public sealed record GetReferralsResult(IReadOnlyCollection<ReferralDto> Referrals);
