using ClickApi.Domain.Entity;
using ClickApi.Domain.Intefaces.Repository;
using ClickApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickApi.Infrastructure.Repositories
{
    public class LinkRepository : ILinkRepository
    {
        private readonly AppDbContext _context;

        public LinkRepository(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task AddLink(ShortenedLink link)
        {
            _context.ShortenedLinks.Add(link);
            await _context.SaveChangesAsync();
        }

        public async Task<ShortenedLink> GetLinkByCode(string code)
        {
            return await _context.ShortenedLinks.FirstOrDefaultAsync(l => l.ShortenedUrl.EndsWith(code));
        }

        public async Task RemoveLink(ShortenedLink link)
        {
            _context.ShortenedLinks.Remove(link);
            await _context.SaveChangesAsync();

        }
    }

}
