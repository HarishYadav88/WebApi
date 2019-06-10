using Microsoft.EntityFrameworkCore;
using WebApi.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApi.DataAccessLayer.Configurations
{
    internal class GroupEntityConfiguration : IEntityTypeConfiguration<GroupEntity>
    {
        public void Configure(EntityTypeBuilder<GroupEntity> builder)
        {
            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Id);
        }
    }
}
