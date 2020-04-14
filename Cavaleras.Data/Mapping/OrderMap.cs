using Calaveras.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cavaleras.Data.Mapping
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.id);

            builder.Property(x => x.id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.date_order)
                .IsRequired();

            builder.Property(x => x.date_order_process)
                .IsRequired(false);

            builder.Property(x => x.date_order_complete)
                .IsRequired(false);

            builder.Property(x => x.descritption)
                .IsRequired(false)
                .HasMaxLength(500);

            builder.Property(x => x.payment_later)
                .IsRequired(false);

            builder.Property(x => x.total_price)
                .IsRequired();

            builder.Property(x => x.signature)
                .IsRequired(false)
                .HasMaxLength(9999);

            builder.HasOne(x => x.Client)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.idclient)
                .IsRequired();

            builder.HasOne(x => x.Store)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.idstore)
                .IsRequired();

            builder.HasOne(x => x.OrderStatus)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.idstatus)
                .IsRequired();

            builder.HasOne(x => x.DeliveryMan)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.iddeliveryman)
                .IsRequired();

            builder.HasOne(x => x.ZipCodeDeliveryPrice)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.idzipcodeliveryprice)
                .IsRequired();

            builder.HasMany(x => x.OrderProduct)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.idorder);
        }
    }
}
