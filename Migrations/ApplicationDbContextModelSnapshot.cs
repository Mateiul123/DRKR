﻿// <auto-generated />
using System;
using DRKR.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DRKR.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DRKR.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DRKR.Models.Media", b =>
                {
                    b.Property<int>("MediaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MediaId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int?>("DurationInSeconds")
                        .HasColumnType("int");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("MediaId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Medias");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Media");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("DRKR.Models.Rating", b =>
                {
                    b.Property<int>("RatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RatingId"));

                    b.Property<int>("MediaId")
                        .HasColumnType("int");

                    b.Property<int?>("MediaId1")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId1")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("RatingId");

                    b.HasIndex("MediaId");

                    b.HasIndex("MediaId1");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("DRKR.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("DRKR.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MediaTag", b =>
                {
                    b.Property<int>("MediaItemsMediaId")
                        .HasColumnType("int");

                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.HasKey("MediaItemsMediaId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("MediaTag");
                });

            modelBuilder.Entity("DRKR.Models.Audio", b =>
                {
                    b.HasBaseType("DRKR.Models.Media");

                    b.Property<string>("AudioUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Audio");
                });

            modelBuilder.Entity("DRKR.Models.Text", b =>
                {
                    b.HasBaseType("DRKR.Models.Media");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Text");
                });

            modelBuilder.Entity("DRKR.Models.Video", b =>
                {
                    b.HasBaseType("DRKR.Models.Media");

                    b.Property<string>("VideoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Video");
                });

            modelBuilder.Entity("DRKR.Models.Media", b =>
                {
                    b.HasOne("DRKR.Models.Category", "Category")
                        .WithMany("MediaItems")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DRKR.Models.User", "User")
                        .WithMany("MediaItems")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DRKR.Models.Rating", b =>
                {
                    b.HasOne("DRKR.Models.Media", "Media")
                        .WithMany()
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DRKR.Models.Media", null)
                        .WithMany("Ratings")
                        .HasForeignKey("MediaId1");

                    b.HasOne("DRKR.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DRKR.Models.User", null)
                        .WithMany("Ratings")
                        .HasForeignKey("UserId1");

                    b.Navigation("Media");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MediaTag", b =>
                {
                    b.HasOne("DRKR.Models.Media", null)
                        .WithMany()
                        .HasForeignKey("MediaItemsMediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DRKR.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DRKR.Models.Category", b =>
                {
                    b.Navigation("MediaItems");
                });

            modelBuilder.Entity("DRKR.Models.Media", b =>
                {
                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("DRKR.Models.User", b =>
                {
                    b.Navigation("MediaItems");

                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
