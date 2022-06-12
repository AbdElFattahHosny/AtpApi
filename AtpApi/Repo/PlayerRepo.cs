using AtpApi.Interfaces;
using AtpApi.Models;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AtpApi.Repo
{
    public class PlayerRepo : IBaseRepo<Player>
    {
        private readonly AppDbContext context;
        

        public PlayerRepo(AppDbContext _context)
        {
            context = _context;
           
        }
        public Task<int> Create(Player t)
        {
            context.Players.AddAsync(t);
            return context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            context.Players.Remove(await Get(id));
            return await context.SaveChangesAsync();
        }

        public async Task<Player> Get(int id)
        {
            return await context.Players.Include(c=>c.country).FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<IEnumerable<Player>> GetAll()
        {
            return await context.Players.Include(c => c.country).ToListAsync();
        }

        public async Task<int> Update(int oldid, Player t2)
        {
            var oldplayer = await Get(oldid);
            oldplayer.Age = t2.Age;
            oldplayer.CoachName = t2.CoachName;
            oldplayer.CountryId = t2.CountryId;
            oldplayer.Height = t2.Height;
            oldplayer.Weight = t2.Weight;
            oldplayer.TurnedPro = t2.TurnedPro;
            oldplayer.NoOfTitles = t2.NoOfTitles;
            oldplayer.Name = t2.Name;
           return await context.SaveChangesAsync();
            
        }
    }
}
