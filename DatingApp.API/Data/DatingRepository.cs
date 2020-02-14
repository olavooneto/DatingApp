using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DatingApp.API.Data
{
    public class DatingRepository : IDatingRepository
    {
        private DataContext _context;

        public DatingRepository(DataContext context)
        {
            this._context = context;
        }

        public void Add<T>(T entity) where T : class => _context.Add(entity);


        public void Delete<T>(T entity) where T : class => _context.Remove(entity);

        public async Task<Photo> GetMainPhotoForUser(int userId)=> await this._context.Photos.Where(x=>x.UserId == userId).FirstOrDefaultAsync(x=>x.IsMain);

        public async  Task<Photo> GetPhoto(int id)=> await _context.Photos.FirstOrDefaultAsync(x=>x.Id == id);

        public async Task<User> GetUser(int id) => await _context.Users.Include(x => x.Photos).FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<User>> GetUsers() => await _context.Users.Include(x => x.Photos).ToListAsync();

        public async Task<bool> SaveAll() => await _context.SaveChangesAsync() > 0;
    }
}