using CafeMan_Project.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeMan_Project.Models.Configs
{
    public class EdiblesConfigs : IEntityTypeConfiguration<Edibles>
    {
        public void Configure(EntityTypeBuilder<Edibles> builder)
        {
            builder.Property(c=>c.Description).HasMaxLength(50);
        }
    }
}
