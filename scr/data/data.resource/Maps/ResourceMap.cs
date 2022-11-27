using ApiResource.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiResource.Infra.Data.Maps
{
    public class ResourceMap : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.ToTable("RESOURCES");

            builder.HasKey(c => c.ID_RESOURCES);

            builder.Property(c => c.ID_RESOURCES)
                .HasColumnName("ID_RESOURCE")
                .UseIdentityColumn();

            builder.Property(c => c.ID_CAMPAIGN)
                .HasColumnName("ID_CAMPAIGN");

            builder.Property(c => c.FULL_PATH)
                .HasColumnName("FULL_PATH");

            builder.Property(c => c.FILENAME)
                .HasColumnName("FILENAME");

            builder.Property(c => c.MESSAGE)
                .HasColumnName("MESSAGE");

            builder.Property(c => c.RELATIVE_PATH)
                .HasColumnName("RELATIVE_PATH");

            builder.Property(c => c.ID_RES_TYPE)
                .HasColumnName("ID_RES_TYPE");
            
            builder.Property(c => c.PRIORITY)
                .HasColumnName("PRIORITY");

            builder.Property(c => c.ID_IMG)
                .HasColumnName("ID_IMG");

            builder.Property(c => c.URL)
                .HasColumnName("URL");

            builder.Property(c => c.TIME_SECONDS)
                .HasColumnName("TIME_SECONDS");

            builder.Property(c => c.ID_TRANSACTION)
                .HasColumnName("ID_TRANSACTION");

            builder.Property(c => c.ID_CAMPAIGN_PARENT)
                .HasColumnName("ID_CAMPAIGN_PARENT");

            builder.Property(c => c.CRC)
                .HasColumnName("CRC");

        }
    }
}
