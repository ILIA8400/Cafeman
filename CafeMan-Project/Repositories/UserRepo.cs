using CafeMan_Project.Models.Dal;
using CafeMan_Project.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CafeMan_Project.Repositories
{
    public class UserRepo : IUserRepository<User>
    {
        private readonly CafemanDbContext ctx;

        public UserRepo(CafemanDbContext ctx)
        {
            this.ctx = ctx;
        }


        public Task<List<User>> GetAll()
        {
            return ctx.Users.ToListAsync();
        }

        public Task<User?> GetById(string id)
        {
            return ctx.Users.SingleOrDefaultAsync(c => c.Id == id);
        }

 
    }
}
