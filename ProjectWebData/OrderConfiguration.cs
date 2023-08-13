using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using Domain.Models;

namespace ProjectWebData
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderDTO>
    {
        public void Configure(EntityTypeBuilder<OrderDTO> builder)
        {
            builder.ToTable("Pedidos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Started).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            builder.Property(p => p.Status).HasConversion<string>();
            builder.Property(p => p.FreightType).HasConversion<int>();
            builder.Property(p => p.Note).HasColumnType("VARCHAR(512)");
        }
    }
}
