using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWebData
{
    public class ProductConfiguration : IEntityTypeConfiguration<ItemDTO>
    {
        public void Configure(EntityTypeBuilder<ItemDTO> builder)
        {
            builder.ToTable("Produtos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.BarCode).HasColumnType("VARCHAR(14)").IsRequired();
            builder.Property(p => p.Description).HasColumnType("VARCHAR(60)");
            builder.Property(p => p.Value).IsRequired();
            builder.Property(p => p.ProductType).HasConversion<string>();
        }
    }
}
