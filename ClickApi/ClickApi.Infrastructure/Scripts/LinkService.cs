using ClickApi.Domain.Entity;
using ClickApi.Domain.Intefaces.Repository;
using ClickApi.Domain.Intefaces.Service;
using System.Web.Http.Results;

namespace ClickApi.Infrastructure.Scripts
{
    public class LinkService : ILinkService
    {
        private const string BaseUrl = "https://hcsbk.kz/ru/";
        private readonly ILinkRepository _repository;

        public LinkService(ILinkRepository linkRepository)
        {
            _repository = linkRepository;
        }

        public async Task<ShortenedLink> CreateShortenedLink(string originalUrl)
        {
            var code = GenerateRandomCode();
            var createdDate = DateTime.Now;
            var expirationDate = createdDate.AddDays(7);

            var shortenedLink = new ShortenedLink
            {
                OriginalUrl = originalUrl,
                ShortenedUrl = BaseUrl + code,
                CreatedDate = createdDate,
                ExpirationDate = expirationDate
            };

            await _repository.AddLink(shortenedLink);

            return shortenedLink;
        }

        public async Task<string> RedirectLink(string code)
        {
            var link = await _repository.GetLinkByCode(code);
            if (link != null)
            {
                if (link.ExpirationDate >= DateTime.Now)
                {
                    return link.OriginalUrl;
                }
                else
                {
                    await _repository.RemoveLink(link);
                    throw new InvalidOperationException("Link not found");
                }
            }
            throw new InvalidOperationException("Error");
        }






        private string GenerateRandomCode()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }


}
