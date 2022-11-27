using ApiResource.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiResource.Infra.Data.Maps
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("ID_USER")
                .UseIdentityColumn();
            builder.Property(x => x.Email)
                .HasColumnName("USER");
            builder.Property(x => x.Password)
                .HasColumnName("PASSWORD");
        }
    }
}
