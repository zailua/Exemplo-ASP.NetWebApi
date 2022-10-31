﻿// <auto-generated />
using Fliperama.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fliperama.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221031175320_new")]
    partial class @new
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Fliperama.Model.Jogo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("GameGen")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("game_gen");

                    b.Property<string>("Img")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("game_img");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("game_name");

                    b.Property<double>("Valor")
                        .HasColumnType("double")
                        .HasColumnName("game_value");

                    b.HasKey("Id");

                    b.ToTable("game");
                });

            modelBuilder.Entity("Fliperama.Model.Sala", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("room_name");

                    b.Property<int>("jogo_fk")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("jogo_fk");

                    b.ToTable("room");
                });

            modelBuilder.Entity("Fliperama.Model.Sala", b =>
                {
                    b.HasOne("Fliperama.Model.Jogo", "Jogo")
                        .WithMany("Salas")
                        .HasForeignKey("jogo_fk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Jogo");
                });

            modelBuilder.Entity("Fliperama.Model.Jogo", b =>
                {
                    b.Navigation("Salas");
                });
#pragma warning restore 612, 618
        }
    }
}