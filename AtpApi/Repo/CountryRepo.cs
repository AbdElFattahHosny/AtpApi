using AtpApi.Interfaces;
using AtpApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AtpApi.Repo
{
    public class CountryRepo : IBaseRepo<Country>
    {
        private readonly AppDbContext context;

        public CountryRepo(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<int> Create(Country t)
        {
            await  context.Countries.AddAsync(t);
            return await context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            context.Countries.Remove(await Get(id));
            return await context.SaveChangesAsync();
        }

        public async Task<Country> Get(int id)
        {
            return await context.Countries.FindAsync(id);
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            return await context.Countries.ToListAsync();
        }

        public async Task<int> Update(int oldid, Country t2)
        {
            var OldCountry = await Get(oldid);
            OldCountry.Name = t2.Name;
            return await context.SaveChangesAsync();
        }
    }
}
