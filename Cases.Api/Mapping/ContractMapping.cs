using System;
using System.Collections.Generic;
using System.Linq;
using Cases.Application.Models;
using Cases.Contracts.Requests;
using Cases.Contracts.Responses;

namespace Cases.Api.Mapping;
public static class ContractMapping
{
	public static Case MapToCase(this CreateCaseRequest request)
	{
        return new Case
        {
            id = Guid.NewGuid(),
            case_name = request.case_name,
            created_date = DateTime.UtcNow,
            client_name = request.client_name,
            case_type = request.case_type,
            case_state = request.case_state,
            assigned_attorney = request.assigned_attorney,
            court_date = request.court_date,
            case_description = request.case_description,
            documents = request.documents,
            notes = request.notes

        };
    }

    public static CaseResponse MapToResponse(this Case caseItem)
    {
        return new CaseResponse
        {
            id = caseItem.id,
            case_name = caseItem.case_name,
            created_date = caseItem.created_date,
            updated_date = caseItem.updated_date,
            slug = caseItem.slug,
            client_name = caseItem.client_name,
            case_type = caseItem.case_type,
            case_state = caseItem.case_state,
            assigned_attorney = caseItem.assigned_attorney,
            court_date = caseItem.court_date,
            case_description = caseItem.case_description,
            documents = caseItem.documents,
            notes = caseItem.notes
        };
    }

    public static CasesResponse MapToResponse(this IEnumerable<Case> cases)
    {
        return new CasesResponse
        {
            Items = cases.Select(MapToResponse)
        };
    }

    public static Case MapToCase(this UpdateCaseRequest request, Guid id, Case existingCase)
    {
        var updatedCase = new Case
        {
            id = id,
            case_name = request.case_name,
            created_date = existingCase.created_date,
            updated_date = DateTime.UtcNow,
            client_name = request.client_name,
            case_type = request.case_type,
            case_state = request.case_state,
            assigned_attorney = request.assigned_attorney,
            court_date = request.court_date,
            case_description = request.case_description,
            documents = request.documents,
            notes = request.notes

        };
        updatedCase.SetSlug(existingCase.slug);
        return updatedCase;
    }
}
