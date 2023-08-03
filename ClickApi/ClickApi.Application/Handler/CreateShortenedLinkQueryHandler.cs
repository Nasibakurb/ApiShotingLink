using ClickApi.Application.Queries;
using ClickApi.Domain.Entity;
using ClickApi.Domain.Intefaces.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickApi.Application.Handler
{
    public class CreateShortenedLinkQueryHandler : IRequestHandler<CreateShortenedLinkQuery, ShortenedLink>
    {
        private readonly ILinkService _linkService;

        public CreateShortenedLinkQueryHandler(ILinkService linkService)
        {
            _linkService = linkService;
        }

        public async Task<ShortenedLink> Handle(CreateShortenedLinkQuery request, CancellationToken cancellationToken)
        {
            return await _linkService.CreateShortenedLink(request.OriginalUrl);
        }
   
    }   
}
