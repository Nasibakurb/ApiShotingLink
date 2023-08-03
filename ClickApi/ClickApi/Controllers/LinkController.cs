using ClickApi.Application.Queries;
using ClickApi.Domain.Intefaces.Service;
using ClickApi.Infrastructure.Scripts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClickApi.Controllers
{
    [ApiController]
    [Route("api/shotingLink")]
    public class LinkController : Controller
    {
        private readonly IMediator _mediator;

        public LinkController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateShortenedLink([FromBody] string originalUrl)
        {
            var query = new CreateShortenedLinkQuery { OriginalUrl = originalUrl };
            var shortenedLink = await _mediator.Send(query);
            return Ok(shortenedLink);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> Redirect(string code)
        {
            try
            {
                var redirectUrl = await _mediator.Send(new RedirectLinkQuery(code));

                if (redirectUrl != null)
                {
                    return RedirectPermanent(redirectUrl);
                }

                return NotFound();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }


    }
}
