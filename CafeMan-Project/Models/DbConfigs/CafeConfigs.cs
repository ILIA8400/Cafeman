using CafeMan_Project.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace CafeMan_Project.Models.Configs
{
    public class CafeConfigs : IEntityTypeConfiguration<Cafe>
    {
        public void Configure(EntityTypeBuilder<Cafe> builder)
        {
            builder.Property(c=>c.Details).HasMaxLength(100);
            builder.Property(c => c.PriceRange).HasMaxLength(50);
            builder.HasOne(c => c.Users).WithMany(u => u.Cafes).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
