using Log.Accenture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Log.Accenture.Infra.Data.Mappings
{
    public class LogSystemMap : IEntityTypeConfiguration<LogSystem>
    {
        public void Configure(EntityTypeBuilder<LogSystem> builder)
        {
            
            builder.Property(u => u.Description)
                .IsRequired(false)
                .HasColumnType("varchar(255)");
        }
    }
}
