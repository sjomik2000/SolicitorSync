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

namespace Cases.Api.Controllers
{
    [ApiController]
    public class CasesController : ControllerBase
    {
        private readonly ICaseRepository _caseRepository;

        public CasesController(ICaseRepository caseRepository)
        {
            _caseRepository = caseRepository;
        }

        [HttpPost(ApiEndpoints.Cases.Create)]
        public async Task<IActionResult> Create([FromBody] CreateCaseRequest request)
        {
            var caseItem = request.MapToCase();
            var result = await _caseRepository.CreateAsync(caseItem);
            return CreatedAtAction(nameof(Get), new { idOrSlug = caseItem.id }, caseItem);
        }

        [HttpGet(ApiEndpoints.Cases.Get)]
        public async Task<IActionResult> Get([FromRoute] string idOrSlug)
        {
            var caseItem = Guid.TryParse(idOrSlug, out Guid id)
                ? await _caseRepository.GetByIdAsync(id)
                : await _caseRepository.GetBySlugAsync(idOrSlug);
            if (caseItem is null)
            {
                return NotFound();
            }
            var response = caseItem.MapToResponse();
            return Ok(response);
        }
        [HttpGet(ApiEndpoints.Cases.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var cases = await _caseRepository.GetAllAsync();
            var casesResponse = cases.MapToResponse();

            return Ok(casesResponse);
        }

        [HttpPut(ApiEndpoints.Cases.Update)]
        public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody]UpdateCaseRequest request)
        {
            var caseItem = await _caseRepository.GetByIdAsync(id);
            caseItem = request.MapToCase(id, caseItem);
            var updated = await _caseRepository.UpdateAsync(caseItem);
            if (!updated)
            {
                return NotFound();
            }
            var response = caseItem.MapToResponse();
            return Ok(response);
        }
        [HttpDelete(ApiEndpoints.Cases.Delete)]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var deleted = await _caseRepository.DeleteByIdAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return Ok();
        }
    }
};
