using MediatR;

namespace ClickApi.Application.Queries
{
    public class RedirectLinkQuery : IRequest<string>
    {
        public string Code { get; }

        public RedirectLinkQuery(string code)
        {
            Code = code;
        }
    }
}
