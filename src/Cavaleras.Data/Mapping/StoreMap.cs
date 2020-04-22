using Calaveras.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cavaleras.Data.Mapping
{
    public class StoreMap : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {

            builder.HasKey(x => x.id);
            builder.Property(x => x.id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.address)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.number)
                .IsRequired();

            builder.Property(x => x.description)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.info)
                .IsRequired(false)
                .HasMaxLength(200);
        }
    }
}
