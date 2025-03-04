using Microsoft.AspNetCore.Mvc;
using Cases.Application.Repositories;
using Cases.Contracts.Requests;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Cases.Application.Models;
//using Cases.Api.Mapping;
using System;
using System.Linq;
using Cases.Api;
using System.Reflection.Metadata.Ecma335;

namespace Cases.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class CasesController : ControllerBase
    {
        private readonly ICaseRepository _caseRepository;

        public CasesController(ICaseRepository caseRepository)
        {
            _caseRepository = caseRepository;
        }

        [HttpPost("cases")]
        public async Task<IActionResult> Create([FromBody] CreateCaseRequest request) => Ok(request);
    }
};
