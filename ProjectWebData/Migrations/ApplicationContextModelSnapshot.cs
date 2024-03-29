﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectWebData.DbContexts;

#nullable disable

namespace ProjectWebData.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.ClientDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("CHAR(8)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(80)");

                    b.Property<int?>("Option")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("CHAR(11)");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("VARCHAR(14)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("VARCHAR(80)");

                    b.HasKey("Id");

                    b.HasIndex("PhoneNumber")
                        .HasDatabaseName("idx_cliente_telefone");

                    b.ToTable("Clientes", (string)null);
                });

            modelBuilder.Entity("Domain.Models.ItemDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BarCode")
                        .IsRequired()
                        .HasColumnType("VARCHAR(14)");

                    b.Property<string>("Description")
                        .HasColumnType("VARCHAR(60)");

                    b.Property<int?>("OrderDTOId")
                        .HasColumnType("int");

                    b.Property<string>("ProductType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderDTOId");

                    b.ToTable("Produtos", (string)null);
                });

            modelBuilder.Entity("Domain.Models.OrderDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Finished")
                        .HasColumnType("datetime2");

                    b.Property<int>("FreightType")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("VARCHAR(512)");

                    b.Property<DateTime>("Started")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Pedidos", (string)null);
                });

            modelBuilder.Entity("Domain.Models.OrderItemDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("PedidoItens", (string)null);
                });

            modelBuilder.Entity("Domain.Models.ItemDTO", b =>
                {
                    b.HasOne("Domain.Models.OrderDTO", null)
                        .WithMany("Itens")
                        .HasForeignKey("OrderDTOId");
                });

            modelBuilder.Entity("Domain.Models.OrderDTO", b =>
                {
                    b.HasOne("Domain.Models.ClientDTO", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Domain.Models.OrderItemDTO", b =>
                {
                    b.HasOne("Domain.Models.OrderDTO", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.ItemDTO", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.Models.OrderDTO", b =>
                {
                    b.Navigation("Itens");
                });
#pragma warning restore 612, 618
        }
    }
}
