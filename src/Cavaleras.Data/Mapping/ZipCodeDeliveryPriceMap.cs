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
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.price)
                .IsRequired();

            builder.HasOne(x => x.ZipCodeMin)
                .WithMany(x => x.ZipCodeDeliveryPricesMin)
                .HasForeignKey(x => x.idzipcodemin);
            
            builder.HasOne(x => x.ZipCodeMax)
                .WithMany(x => x.ZipCodeDeliveryPricesMax)
                .HasForeignKey(x => x.idzipcodemax);
        }
    }
}
