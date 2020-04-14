using Calaveras.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cavaleras.Data.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.price)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(x => x.avaliable)
                .IsRequired()
                .HasDefaultValue<bool>(false);

            builder.HasMany(x => x.OrderProduct)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.idproduct);
        }
    }
}
