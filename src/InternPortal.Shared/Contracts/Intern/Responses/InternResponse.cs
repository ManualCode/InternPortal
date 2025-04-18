﻿

using InternPortal.Shared.Contracts.Internship.Responses;
using InternPortal.Shared.Contracts.Project.Responses;

namespace InternPortal.Shared.Contracts.Intern.Responses
{
    public sealed record InternResponse(
    Guid Id,
    string FullName,
    DateTime BirthDate,
    string Email,
    string PhoneNumber,
    InternshipResponse Internship,
    ProjectResponse Project,
    DateTime CreateAt,
    DateTime UpdateAt);
}
