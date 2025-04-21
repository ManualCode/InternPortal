namespace InternPortal.Shared.Contracts.Internship.Responses
{
    public sealed record InternshipResponse(
    Guid Id,
    string Name,
    List<Guid> Interns,
    DateTime CreateAt,
    DateTime UpdateAt);

    public sealed record PagedInternshipResponse(

       int TotalCount,
       List<InternshipResponse> Internships);
}
