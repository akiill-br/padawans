using Frwk.ApiDotNet6.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frwk.ApiDotNet6.Infra.Data.Maps
{
    public class CampaignMap : IEntityTypeConfiguration<Campaign>
    {
        public void Configure(EntityTypeBuilder<Campaign> builder)
        {

            builder.ToTable("CAMPAIGNS");

            builder.HasKey(c =>c.IdCampaign);

            builder.Property(c => c.IdCampaign)
                .HasColumnName("ID_CAMPAIGN")
                .UseIdentityColumn();

            builder.Property(c => c.Name)
                .HasColumnName("NAME");

            builder.Property(c => c.Status)
                .HasColumnName("STATUS");

            builder.Property(c => c.StorageType)
                .HasColumnName("STORAGE_TYPE");

            builder.Property(c => c.FinalDate)
                .HasColumnName("FINAL_DATE");

            builder.Property(c => c.IdCampaignType)
                .HasColumnName("ID_CAMPAIGN_TYPE");

            builder.Property(c => c.IdIf)
                .HasColumnName("Id_If");

            builder.Property(c => c.IdChannel)
                .HasColumnName("ID_CHANNEL");

            builder.Property(c => c.IdComponent)
                .HasColumnName("ID_COMPONENT");

            builder.Property(c => c.ExecutionType)
                .HasColumnName("EXECUTION_TYPE");

            builder.Property(c => c.LastUpdate)
                .HasColumnName("LAST_UPDATE");

            builder.Property(c => c.Messages)
                .HasColumnName("MESSAGES");

        }
    }
}
