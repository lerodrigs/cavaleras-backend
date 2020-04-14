using Calaveras.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cavaleras.Data.Mapping
{
    public class ZipCodeDeliveryPriceMap : IEntityTypeConfiguration<ZipCodeDeliveryPrice>
    {
        public void Configure(EntityTypeBuilder<ZipCodeDeliveryPrice> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.description)
                .IsRequired(true)
                .HasMaxLength(100);

            builder.HasOne(x => x.ZipCodeMin)
                .WithMany(x => x.ZipCodeDeliveryPrices)
                .HasForeignKey(x => x.idzipcodemin)
                .HasPrincipalKey(x => x.id)
                .IsRequired();

            builder.HasOne(x => x.ZipCodeMax)
                .WithMany(x => x.ZipCodeDeliveryPrices)
                .HasForeignKey(x => x.idzipcodemax)
                .HasPrincipalKey(x => x.id)
                .IsRequired();
        }
    }
}
