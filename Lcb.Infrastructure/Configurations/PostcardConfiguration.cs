using Lcb.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lcb.Infrastructure.Configurations;

public class PostcardConfiguration : IEntityTypeConfiguration<Postcard>
{
    public void Configure(EntityTypeBuilder<Postcard> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasMany(x => x.Images)
            .WithOne(x => x.Postcard)
            .HasForeignKey(x => x.PostcardId);
    }
}