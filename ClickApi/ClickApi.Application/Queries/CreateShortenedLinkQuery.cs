using ClickApi.Domain.Entity;
using MediatR;

namespace ClickApi.Application.Queries
{
    public class CreateShortenedLinkQuery : IRequest<ShortenedLink> 
    {
        public string OriginalUrl { get; set; }
    }
}

