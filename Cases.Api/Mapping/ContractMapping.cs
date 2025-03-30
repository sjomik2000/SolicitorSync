using System;
using System.Collections.Generic;
using System.Linq;
using Cases.Application.Models;
using Cases.Contracts.Requests;
using Cases.Contracts.Responses;

namespace Cases.Api.Mapping;
// This file uses Cases.Contracts response and request templates to map API requests and
// response into the functional formats.
public static class ContractMapping
{
	public static Case MapToCase(this CreateCaseRequest request)
	{
        // During Create Case request a new GUID and created_date are generated,
        // all other information is imported into the Case model
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
        // During CaseResponse all information from the Case are passed back to the response
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
        //CasesResponse mapping is used for GetAll method to send back all cases
        return new CasesResponse
        {
            Items = cases.Select(MapToResponse)
        };
    }

    public static Case MapToCase(this UpdateCaseRequest request, Guid id, Case existingCase)
    {
        //UpdateCaseRequest only updates the provided values from the requests, updated_date is generated,
        // old non updated values and updated values are used to replace the case.
        var updatedCase = new Case
        {
            id = id,
            case_name = request.case_name ?? existingCase.case_name,
            created_date = existingCase.created_date,
            updated_date = DateTime.UtcNow,
            client_name = request.client_name ?? existingCase.client_name,
            case_type = request.case_type ?? existingCase.case_type,
            case_state = request.case_state ?? existingCase.case_state,
            assigned_attorney = request.assigned_attorney ?? existingCase.assigned_attorney,
            court_date = request.court_date ?? existingCase.court_date,
            case_description = request.case_description ?? existingCase.case_description,
            documents = request.documents ?? existingCase.documents,
            notes = request.notes ?? existingCase.notes

        };
        updatedCase.SetSlug(existingCase.slug);
        return updatedCase;
    }
}
