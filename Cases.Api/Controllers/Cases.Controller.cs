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

namespace Cases.Api.Controllers
{
    [ApiController]
    public class CasesController : ControllerBase
    {
        private readonly ICaseService _caseService;
        private readonly ILogger<CasesController> _logger;

        public CasesController(ICaseService caseRepository, ILogger<CasesController> logger)
        {
            _caseService = caseRepository;
            _logger = logger;
        }

        [HttpPost(ApiEndpoints.Cases.Create)]
        public async Task<IActionResult> Create([FromBody] CreateCaseRequest request)
        {
            var caseItem = request.MapToCase();
            var result = await _caseService.CreateAsync(caseItem);
            _logger.LogInformation($"Created {caseItem.case_name} case in SQL database with the new slug: {caseItem.slug}.");
            return CreatedAtAction(nameof(Get), new { idOrSlug = caseItem.id }, caseItem);
        }

        [HttpGet(ApiEndpoints.Cases.Get)]
        public async Task<IActionResult> Get([FromRoute] string idOrSlug)
        {
            var caseItem = Guid.TryParse(idOrSlug, out Guid id)
                ? await _caseService.GetByIdAsync(id)
                : await _caseService.GetBySlugAsync(idOrSlug);
            if (caseItem is null)
            {
                return NotFound();
            }
            _logger.LogInformation($"Retrieved case with slug: {caseItem.slug} from SQL database.");
            var response = caseItem.MapToResponse();
            return Ok(response);
        }
        [HttpGet(ApiEndpoints.Cases.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var cases = await _caseService.GetAllAsync();
            int caseCount = cases.Count();
            if (caseCount == 1)
            {
                _logger.LogInformation($"Retrieved {caseCount} case from SQL database.");
            }
            else
            {
                _logger.LogInformation($"Retrieved {caseCount} cases from SQL database.");
            }
            var casesResponse = cases.MapToResponse();
            return Ok(casesResponse);
        }

        [HttpPut(ApiEndpoints.Cases.Update)]
        public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody]UpdateCaseRequest request)
        {
            var caseItem = await _caseService.GetByIdAsync(id);
            caseItem = request.MapToCase(id, caseItem);
            var updated = await _caseService.UpdateAsync(caseItem);
            if (updated is null)
            {
                return NotFound();
            }
            var requestJson = JsonSerializer.Serialize(request);
            var requestDict = JsonSerializer.Deserialize<Dictionary<string, object>>(requestJson);
            var filteredRequestDict = requestDict.Where(kv => kv.Value != null && kv.Value.ToString() != string.Empty);
            var updatedValues = string.Join(", ", filteredRequestDict.Select(kv => $"{kv.Key}: {kv.Value}"));
            _logger.LogInformation($"Updated case with slug: {caseItem.slug}.");
            _logger.LogInformation($"Values updated: {updatedValues}.");
            var response = caseItem.MapToResponse();
            return Ok(response);
        }
        [HttpDelete(ApiEndpoints.Cases.Delete)]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var caseItem = await _caseService.GetByIdAsync(id);
            var deleted = await _caseService.DeleteByIdAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            _logger.LogInformation($"Deleted case with slug: {caseItem.slug}.");
            return Ok();
        }
    }
};
