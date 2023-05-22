﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Top2000_2.Data;

#nullable disable

namespace Top2000_2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230123074804_spNewInList")]
    partial class spNewInList
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Top2000_2.Models.Artiest", b =>
                {
                    b.Property<int>("Artiestid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Artiestid"));

                    b.Property<string>("naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Artiestid");

                    b.ToTable("Artiest");
                });

            modelBuilder.Entity("Top2000_2.Models.Song", b =>
                {
                    b.Property<int>("songid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("songid"));

                    b.Property<int>("artiestid")
                        .HasColumnType("int");

                    b.Property<int>("jaar")
                        .HasColumnType("int");

                    b.Property<string>("titel")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.HasKey("songid");

                    b.HasIndex("artiestid");

                    b.ToTable("Song");
                });

            modelBuilder.Entity("Top2000_2.Models.Top2000", b =>
                {
                    b.Property<int>("jaar")
                        .HasColumnType("int");

                    b.Property<int>("songid")
                        .HasColumnType("int");

                    b.Property<int>("positie")
                        .HasColumnType("int");

                    b.HasKey("jaar", "songid");

                    b.HasIndex("songid");

                    b.ToTable("Lijst");
                });

            modelBuilder.Entity("Top2000_2.Models.VmDaling", b =>
                {
                    b.Property<string>("Gedaald")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Vorigjaar")
                        .HasColumnType("int");

                    b.Property<int?>("jaar")
                        .HasColumnType("int");

                    b.Property<string>("naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("positie")
                        .HasColumnType("int");

                    b.Property<string>("titel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable((string)null);

                    b.ToView("spDalingTOVvorigjaar", (string)null);
                });

            modelBuilder.Entity("Top2000_2.Models.VmFilterOpNaam", b =>
                {
                    b.Property<int?>("jaar")
                        .HasColumnType("int");

                    b.Property<string>("naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("positie")
                        .HasColumnType("int");

                    b.Property<string>("titel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable((string)null);

                    b.ToView("spFilterOpNaam", (string)null);
                });

            modelBuilder.Entity("Top2000_2.Models.VmLijst", b =>
                {
                    b.Property<int?>("jaar")
                        .HasColumnType("int");

                    b.Property<string>("naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("positie")
                        .HasColumnType("int");

                    b.Property<string>("titel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable((string)null);

                    b.ToView("spLijst", (string)null);
                });

            modelBuilder.Entity("Top2000_2.Models.VmStijging", b =>
                {
                    b.Property<int?>("Vorigjaar")
                        .HasColumnType("int");

                    b.Property<string>("naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("positie")
                        .HasColumnType("int");

                    b.Property<string>("titel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("uitgiftejaar")
                        .HasColumnType("int");

                    b.Property<string>("verschil")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable((string)null);

                    b.ToView("spStijgingVanSongs", (string)null);
                });

            modelBuilder.Entity("Top2000_2.Models.Song", b =>
                {
                    b.HasOne("Top2000_2.Models.Artiest", "artiest")
                        .WithMany()
                        .HasForeignKey("artiestid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("artiest");
                });

            modelBuilder.Entity("Top2000_2.Models.Top2000", b =>
                {
                    b.HasOne("Top2000_2.Models.Song", "song")
                        .WithMany()
                        .HasForeignKey("songid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("song");
                });
#pragma warning restore 612, 618
        }
    }
}
