using Microsoft.AspNetCore.Mvc;
using Cases.Application.Repositories;
using Cases.Contracts.Requests;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Cases.Application.Models;
using Cases.Api.Mapping;
using System;
using System.Linq;
using Cases.Api;
using System.Reflection.Metadata.Ecma335;
using Cases.Application.Services;
using System.Collections.Generic;
using System.Threading;

namespace Cases.Api.Controllers
{
    [ApiController]
    public class CasesController : ControllerBase // Controller class inherits ControllerBase class
    {
        // _caseService and _logger objects are instantiated.
        private readonly ICaseService _caseService;
        private readonly ILogger<CasesController> _logger;

        // CasesController constructor is used to inject information about _caseService and _logger.
        public CasesController(ICaseService caseRepository, ILogger<CasesController> logger)
        {
            _caseService = caseRepository;
            _logger = logger;
        }

        [HttpPost(ApiEndpoints.Cases.Create)] // ApiEndpoint for Create method
        // Create task uses HTTP body context to map request information into caseItem
        public async Task<IActionResult> Create([FromBody] CreateCaseRequest request, CancellationToken token)
        {
            // Create tasks uses HTTP body context to map request information into caseItem
            var caseItem = request.MapToCase();
            // Service layer then interacts with repository to establish connection, perform actions and validate requests
            var result = await _caseService.CreateAsync(caseItem, token);
            // Action is logged
            _logger.LogInformation($"Created {caseItem.case_name} case in SQL database with the new slug: {caseItem.slug}.");
            return CreatedAtAction(nameof(Get), new { idOrSlug = caseItem.id }, caseItem);
        }

        [HttpGet(ApiEndpoints.Cases.Get)] // ApiEndpoint for Get method
        // Get task uses idOrSlug parameter to pass the ID to the service layer.
        public async Task<IActionResult> Get([FromRoute] string idOrSlug, CancellationToken token)
        {
            var caseItem = Guid.TryParse(idOrSlug, out Guid id)
                // Service layer then interacts with repository to establish connection, perform actions and validate requests
                ? await _caseService.GetByIdAsync(id, token)
                : await _caseService.GetBySlugAsync(idOrSlug, token);
            // If the case is not found 404 Not found is returned
            if (caseItem is null)
            {
                return NotFound();
            }
            // Action is logged
            _logger.LogInformation($"Retrieved case with slug: {caseItem.slug} from SQL database.");
            // If the case is found the caseItem is mapped to the response contract
            var response = caseItem.MapToResponse();
            return Ok(response);
        }
        [HttpGet(ApiEndpoints.Cases.GetAll)] // ApiEndpoint for GetAll method
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            // Service layer then interacts with repository to establish connection, perform actions and validate requests
            var cases = await _caseService.GetAllAsync(token);
            // Action is logged
            int caseCount = cases.Count();
            if (caseCount == 1)
            {
                _logger.LogInformation($"Retrieved {caseCount} case from SQL database.");
            }
            else
            {
                _logger.LogInformation($"Retrieved {caseCount} cases from SQL database.");
            }
            // All cases are mapped into CasesResponse and are sent back.
            var casesResponse = cases.Select(caseItem => caseItem.MapToResponse());
            return Ok(casesResponse);
        }

        [HttpPut(ApiEndpoints.Cases.Update)] // ApiEndpoint for Update method
        public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody]UpdateCaseRequest request, CancellationToken token)
        {
            // Update method firstly retrieves old caseItem using GetByIdAsync (to be able to compare changes).
            var caseItem = await _caseService.GetByIdAsync(id, token);
            // The new request item and old caseItem are then mapped into UpdatedCase 
            caseItem = request.MapToCase(id, caseItem);
            // Updated case is then updated on the database through service layer 
            var updated = await _caseService.UpdateAsync(caseItem, token);
            if (updated is null)
            {
                return NotFound();
            }
            // Request is serialized and deserialized into specified format for logging update information
            var requestJson = JsonSerializer.Serialize(request);
            var requestDict = JsonSerializer.Deserialize<Dictionary<string, object>>(requestJson);
            var filteredRequestDict = requestDict.Where(kv => kv.Value != null && kv.Value.ToString() != string.Empty);
            var updatedValues = string.Join(", ", filteredRequestDict.Select(kv => $"{kv.Key}: {kv.Value}"));
            // Action is logged
            _logger.LogInformation($"Updated case with slug: {caseItem.slug}.");
            _logger.LogInformation($"Values updated: {updatedValues}.");
            // The updated case is mapped to response and returned
            var response = caseItem.MapToResponse();
            return Ok(response);
        }
        [HttpDelete(ApiEndpoints.Cases.Delete)] //ApiEndpoint for Delete method
        //Delete method takes provided id and deletes the case from the database
        public async Task<IActionResult> Delete([FromRoute]Guid id, CancellationToken token)
        {
            //Using provided id the case is found in the database using GetByIdAsync method
            var caseItem = await _caseService.GetByIdAsync(id, token);
            // The case is deleted from the database
            var deleted = await _caseService.DeleteByIdAsync(id, token);
            if (!deleted)
            {
                return NotFound(); //If case is not deleted 404 Not Found is returned
            }
            // Action is Logged
            _logger.LogInformation($"Deleted case with slug: {caseItem.slug}.");
            return Ok();
        }
    }
};
