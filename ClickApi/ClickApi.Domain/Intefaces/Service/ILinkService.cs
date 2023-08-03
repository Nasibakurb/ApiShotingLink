using ClickApi.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickApi.Domain.Intefaces.Service
{
    public interface ILinkService
    {
        Task<ShortenedLink> CreateShortenedLink(string originalUrl); // Создать сокращенную ссылку
        Task<string> RedirectLink(string code); // Перенаправить по сокращенному коду
    }
}
