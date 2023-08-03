using ClickApi.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickApi.Domain.Intefaces.Repository
{
    public interface ILinkRepository
    {
        Task AddLink(ShortenedLink link); // Добавить ссылку
        Task<ShortenedLink> GetLinkByCode(string code); // Получить ссылку по сокращенному коду
        Task RemoveLink(ShortenedLink link); // Удалить ссылку
    }
}
