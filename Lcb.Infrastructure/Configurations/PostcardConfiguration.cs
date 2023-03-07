using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.DAL.Models;

namespace Template.Infrastructure.Configurations;

public class PostcardConfiguration : IEntityTypeConfiguration<Postcard>
{
    public void Configure(EntityTypeBuilder<Postcard> builder)
    {
        builder.HasKey(p => p.Id);
    }
}