using ApiDotNet6.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet6.Infra.Data.Maps
{
    public class TableAMap : IEntityTypeConfiguration<TableA>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TableA> builder)
        {
            builder.ToTable("tablea");

            builder.HasKey(c => c.IdAgency);

            builder.Property(c => c.IdAgency)
                .HasColumnName("id_agency")
                .UseIdentityColumn();

            builder.Property(c => c.AgencyCode)
                .HasColumnName("agency_code");

            builder.Property(c => c.IdData)
                .HasColumnName("id_data");

            builder.Property(c => c.IdIf)
                .HasColumnName("id_if");

            builder.Property(c => c.IdAgencyParent)
                .HasColumnName("id_agency_parent");

            builder.Property(c => c.StatusQueue)
                .HasColumnName("status_queue");

            builder.Property(c => c.NsuAttention)
                .HasColumnName("nsu_attention");

            builder.Property(c => c.BusinessDate)
                .HasColumnName("business_date");

            builder.Property(c => c.Status)
                .HasColumnName("status");

            builder.Property(c => c.IdSegment)
                .HasColumnName("id_segment");

            builder.Property(c => c.Name)
                .HasColumnName("name");

            builder.Property(c => c.PreviousBalance)
                .HasColumnName("previous_balance");

            builder.Property(c => c.CurrentBalance)
                .HasColumnName("current_balance");

            builder.Property(c => c.WorkedBalance)
                .HasColumnName("worked_balance");

            builder.Property(c => c.Emails)
                .HasColumnName("emails");

            builder.Property(c => c.AttendenceDisable)
                .HasColumnName("attendance_disabled");

            builder.Property(c => c.QueueData)
                .HasColumnName("queue_data");

            builder.Property(c => c.EmailsTreasure)
                .HasColumnName("emails_treasure");

            builder.Property(c => c.EmailTreasure)
                .HasColumnName("email_treasure");

            builder.Property(c => c.TimezoneDifference)
                .HasColumnName("timezone_difference");
        }
    }
}

