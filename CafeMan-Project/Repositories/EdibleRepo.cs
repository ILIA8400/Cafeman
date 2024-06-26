﻿using CafeMan_Project.Models.Dal;
using CafeMan_Project.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CafeMan_Project.Repositories
{
    public class EdibleRepo : IRepository<Edibles>
    {
        private readonly CafemanDbContext ctx;

        public EdibleRepo(CafemanDbContext ctx)
        {
            this.ctx = ctx;
        }

        public async void Delete(int entityId)
        {
            var edible = await ctx.Edibles.SingleOrDefaultAsync(c => c.EdiblesId == entityId);

            if (edible != null)
                ctx.Remove(edible);
        }

        public Task<List<Edibles>> GetAll()
        {
            return ctx.Edibles.ToListAsync();
        }

        public Task<Edibles?> GetById(int id)
        {
            return ctx.Edibles.SingleOrDefaultAsync(c => c.EdiblesId == id);
        }

        public async void Insert(Edibles entity)
        {
            await ctx.AddAsync(entity);
        }

        public async void Save()
        {
            await ctx.SaveChangesAsync();
        }

        public void Update(Edibles entity)
        {
            ctx.Update(entity);
        }
    }
}
