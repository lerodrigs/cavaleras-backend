using Calaveras.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cavaleras.Data.Mapping
{
    public class DeliveryManMap : IEntityTypeConfiguration<DeliveryMan>
    {
        public void Configure(EntityTypeBuilder<DeliveryMan> builder)
        {
            builder.Property(x => x.id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.name)
                .IsRequired()
                .HasMaxLength(160);

            builder.Property(x => x.avaliable)
                .IsRequired();
        }
    }
}
