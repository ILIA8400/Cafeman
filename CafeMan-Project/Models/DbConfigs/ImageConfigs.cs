using CafeMan_Project.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeMan_Project.Models.DbConfigs
{
    public class ImageConfigs : IEntityTypeConfiguration<CafeImage>
    {
        public void Configure(EntityTypeBuilder<CafeImage> builder)
        {
            builder.Property(c=>c.ImageName).HasMaxLength(20);
            builder.Property(c=>c.Description).HasMaxLength(50);
        }
    }
}
