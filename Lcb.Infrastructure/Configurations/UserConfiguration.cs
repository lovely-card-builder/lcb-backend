using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.DAL.Models;

namespace Template.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasKey(c => c.Id);
        builder
            .HasMany(x => x.Postcards)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);
    }
}