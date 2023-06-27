﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace hoangcam0256.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230627040834_Create_Table_NHC256DonHang")]
    partial class Create_Table_NHC256DonHang
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("hoangcam0256.Models.NHC256DonHang", b =>
                {
                    b.Property<string>("NHC256MaDonHang")
                        .HasColumnType("TEXT");

                    b.Property<string>("NHC256TenKhachHang")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NHC256TenSanPham")
                        .HasColumnType("INTEGER");

                    b.HasKey("NHC256MaDonHang");

                    b.HasIndex("NHC256TenSanPham");

                    b.ToTable("NHC256DonHang");
                });

            modelBuilder.Entity("hoangcam0256.Models.NHC256SanPham", b =>
                {
                    b.Property<int>("NHC256MaSanPham")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("NHC256Address")
                        .HasColumnType("REAL");

                    b.Property<string>("NHC256TenSanPham")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("NHC256MaSanPham");

                    b.ToTable("NHC256SanPham");
                });

            modelBuilder.Entity("hoangcam0256.Models.NHC256DonHang", b =>
                {
                    b.HasOne("hoangcam0256.Models.NHC256SanPham", "NHC256SanPham")
                        .WithMany()
                        .HasForeignKey("NHC256TenSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NHC256SanPham");
                });
#pragma warning restore 612, 618
        }
    }
}
