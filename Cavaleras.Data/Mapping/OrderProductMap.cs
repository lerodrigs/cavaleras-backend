using Calaveras.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cavaleras.Data.Mapping
{
    public class OrderProductMap : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.HasOne(x => x.Product)
                .WithMany(x => x.OrderProduct)
                .HasForeignKey(x => x.idproduct);

            builder.HasOne(x => x.Order)
                .WithMany(x => x.OrderProduct)
                .HasForeignKey(x => x.idorder);
        }
    }
}
