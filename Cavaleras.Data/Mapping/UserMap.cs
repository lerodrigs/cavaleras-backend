using Calaveras.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cavaleras.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>

    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User"); 

            builder.Property(u => u.address)
                .IsRequired()
                .HasMaxLength(180);

            builder.Property(u => u.number)
                .IsRequired()
                .HasMaxLength(5);

            builder.Property(u => u.cpf)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(u => u.cellphone)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(u => u.zipcode)
                .IsRequired(false)
                .HasMaxLength(10);

            builder.Property(u => u.signature)
                .IsRequired(false)
                .HasMaxLength(9999);

        }
    }
}
