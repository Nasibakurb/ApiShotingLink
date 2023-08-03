using ClickApi.Application.Queries;
using ClickApi.Domain.Intefaces.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickApi.Application.Handler
{
    public class RedirectLinkQueryHandler : IRequestHandler<RedirectLinkQuery, string>
    {
        private readonly ILinkService _linkService;

        public RedirectLinkQueryHandler(ILinkService linkService)
        {
            _linkService = linkService;
        }

        public async Task<string> Handle(RedirectLinkQuery request, CancellationToken cancellationToken)
        {
            var redirectUrl = await _linkService.RedirectLink(request.Code);
            return redirectUrl;
        }
    }
}
