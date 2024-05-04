using CafeMan_Project.Models.Dal;
using CafeMan_Project.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CafeMan_Project.Repositories
{
    public class CommentRepo : IRepository<Comment>
    {
        private readonly CafemanDbContext ctx;

        public CommentRepo(CafemanDbContext ctx)
        {
            this.ctx = ctx;
        }

        public void Delete(int entityId)
        {
            var comment = ctx.Comments.SingleOrDefaultAsync(c => c.CommentId == entityId);

            if (comment != null)
                ctx.Remove(comment);
        }

        public Task<List<Comment>> GetAll()
        {
            return ctx.Comments.ToListAsync();
        }

        public Task<Comment?> GetById(int id)
        {
            return ctx.Comments.SingleOrDefaultAsync(c => c.CommentId == id);
        }

        public void Insert(Comment entity)
        {
            ctx.AddAsync(entity);
        }

        public void Save()
        {
            ctx.SaveChangesAsync();
        }

        public void Update(Comment entity)
        {
            ctx.Update(entity);
        }
    }
}
