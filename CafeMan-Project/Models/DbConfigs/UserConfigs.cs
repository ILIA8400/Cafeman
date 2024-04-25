using CafeMan_Project.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeMan_Project.Models.Configs
{
    public class UserConfigs : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(c => c.Comments).WithOne().OnDelete(DeleteBehavior.NoAction);
        }
    }
}
