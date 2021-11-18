﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.ArtGallery", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ArtGalleries");
                });

            modelBuilder.Entity("Domain.Entities.Artwork", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ArtGalleryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BoughtByCustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Created")
                        .HasColumnType("int");

                    b.Property<string>("Creator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ReservationCustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ArtGalleryId");

                    b.HasIndex("BoughtByCustomerId");

                    b.HasIndex("ReservationCustomerId");

                    b.ToTable("Artworks");
                });

            modelBuilder.Entity("Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsVip")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Domain.Entities.Artwork", b =>
                {
                    b.HasOne("Domain.Entities.ArtGallery", null)
                        .WithMany()
                        .HasForeignKey("ArtGalleryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Customer", null)
                        .WithMany()
                        .HasForeignKey("BoughtByCustomerId");

                    b.HasOne("Domain.Entities.Customer", null)
                        .WithMany()
                        .HasForeignKey("ReservationCustomerId");

                    b.OwnsOne("Domain.ValueObjects.Money", "Price", b1 =>
                        {
                            b1.Property<Guid>("ArtworkId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Amount");

                            b1.HasKey("ArtworkId");

                            b1.ToTable("Artworks");

                            b1.WithOwner()
                                .HasForeignKey("ArtworkId");

                            b1.OwnsOne("Domain.ValueObjects.Currency", "Currency", b2 =>
                                {
                                    b2.Property<Guid>("MoneyArtworkId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("IsoCode")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)")
                                        .HasColumnName("Currency");

                                    b2.HasKey("MoneyArtworkId");

                                    b2.ToTable("Artworks");

                                    b2.WithOwner()
                                        .HasForeignKey("MoneyArtworkId");
                                });

                            b1.Navigation("Currency")
                                .IsRequired();
                        });

                    b.Navigation("Price")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
