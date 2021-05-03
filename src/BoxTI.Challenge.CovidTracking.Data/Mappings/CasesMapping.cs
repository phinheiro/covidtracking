using BoxTI.Challenge.CovidTracking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoxTI.Challenge.CovidTracking.Data.Mappings
{
    public class CasesMapping : IEntityTypeConfiguration<Cases>
    {
        public void Configure(EntityTypeBuilder<Cases> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.ActiveCases)
                .IsRequired()
                .HasColumnType("int(11)");

            builder.Property(e => e.Country)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(e => e.LastUpdate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(e => e.NewCases)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.NewDeaths)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.TotalCases)
                .IsRequired()
                .HasColumnType("int(11)");

            builder.Property(e => e.TotalDeaths)
                .IsRequired()
                .HasColumnType("int(11)");

            builder.Property(e => e.TotalRecovered)
                .IsRequired()
                .HasColumnType("int(11)");

            builder.Property(e => e.Active)
                .IsRequired();
        }
    }
}