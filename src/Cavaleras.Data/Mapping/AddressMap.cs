using Calaveras.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cavaleras.Data.Mapping
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.id);

            builder.Property(x => x.id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.idclient)
                .IsRequired();

            builder.Property(x => x.street)
                .IsRequired();

            builder.Property(x => x.number)
                .IsRequired();

            builder.Property(x => x.apto)
               .IsRequired(false);

            builder.Property(x => x.state)
                .IsRequired();

            builder.Property(x => x.city)
                .IsRequired();

            builder.Property(x => x.selected)
                .IsRequired()
                .HasDefaultValue<bool>(false);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Addresses)
                .HasForeignKey(x => x.idclient);
        }
    }
}
