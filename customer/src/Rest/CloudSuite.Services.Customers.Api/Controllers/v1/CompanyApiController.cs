using CloudSuite.Application.Handlers.Companies;
using CloudSuite.Application.Handlers.Companies.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CloudSuite.Services.Customers.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyApiController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public CompanyApiController(ILogger<CompanyApiController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;

        }



        [AllowAnonymous]
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateCompanyCommand commandCreate)
        {
            var result = await _mediator.Send(commandCreate);
            if (result.Errors.Any()) 
            {
                return BadRequest(result.Errors);
            }

            else
            {
                return Ok(result);
            }
        }


        [HttpGet]
        [Route("exists/company/{cnpj}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CnpjExists([FromBody] string cnpj)
        {
            var result = await _mediator.Send(new CheckCompanyExistsByCnpjAndFantasyNameAndSocialNameRequest(cnpj));
            if (result.Errors.Any()) 
            {
                return BadRequest(result.Errors);
            }

            else
            {
                return Ok(result);
            }
        }
    }
}
