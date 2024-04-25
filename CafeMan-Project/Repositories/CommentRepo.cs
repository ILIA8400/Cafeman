using CafeMan_Project.Models.Dal;
using CafeMan_Project.Models.Entities;

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
            var comment = ctx.Comments.SingleOrDefault(c => c.CommentId == entityId);

            if (comment != null)
                ctx.Remove(comment);
        }

        public ICollection<Comment> GetAll()
        {
            return ctx.Comments.ToList();
        }

        public Comment? GetById(int id)
        {
            return ctx.Comments.SingleOrDefault(c => c.CommentId == id);
        }

        public void Insert(Comment entity)
        {
            ctx.Add(entity);
        }

        public void Save()
        {
            ctx.SaveChanges();
        }

        public void Update(Comment entity)
        {
            ctx.Update(entity);
        }
    }
}
