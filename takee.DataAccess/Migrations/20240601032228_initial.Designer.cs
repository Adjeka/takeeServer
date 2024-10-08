﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using takee.DataAccess;

#nullable disable

namespace takee.DataAccess.Migrations
{
    [DbContext(typeof(TakeeDbContext))]
    [Migration("20240601032228_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("takee.DataAccess.Entities.AnimalEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BreedId")
                        .HasColumnType("uuid");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid>("CuratorId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("DistinguishingMark")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<byte[]>("Photo")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<Guid>("TypeOfAnimalsId")
                        .HasColumnType("uuid");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.ComplexProperty<Dictionary<string, object>>("Gender", "takee.DataAccess.Entities.AnimalEntity.Gender#Gender", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Gender");
                        });

                    b.HasKey("Id");

                    b.HasIndex("BreedId");

                    b.HasIndex("CuratorId");

                    b.HasIndex("TypeOfAnimalsId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("takee.DataAccess.Entities.BreedEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Breeds");
                });

            modelBuilder.Entity("takee.DataAccess.Entities.CuratorEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.ComplexProperty<Dictionary<string, object>>("Email", "takee.DataAccess.Entities.CuratorEntity.Email#Email", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Mail")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Email");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("PhoneNumber", "takee.DataAccess.Entities.CuratorEntity.PhoneNumber#PhoneNumber", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("PhoneNumber");
                        });

                    b.HasKey("Id");

                    b.ToTable("Curators");
                });

            modelBuilder.Entity("takee.DataAccess.Entities.FavouriteEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AnimalId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("UserId");

                    b.ToTable("Favourites");
                });

            modelBuilder.Entity("takee.DataAccess.Entities.RecordForWalkEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AnimalId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateOfRecord")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasDefaultValue(new DateTime(2024, 6, 1, 8, 22, 27, 824, DateTimeKind.Local).AddTicks(7505));

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("UserId");

                    b.ToTable("RecordsForWalk");
                });

            modelBuilder.Entity("takee.DataAccess.Entities.TypeOfAnimalsEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("TypesOfAnimals");
                });

            modelBuilder.Entity("takee.DataAccess.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid>("UserRoleId")
                        .HasColumnType("uuid");

                    b.ComplexProperty<Dictionary<string, object>>("Email", "takee.DataAccess.Entities.UserEntity.Email#Email", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Mail")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Email");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("PhoneNumber", "takee.DataAccess.Entities.UserEntity.PhoneNumber#PhoneNumber", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("PhoneNumber");
                        });

                    b.HasKey("Id");

                    b.HasIndex("UserRoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("takee.DataAccess.Entities.UserRoleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("takee.DataAccess.Entities.AnimalEntity", b =>
                {
                    b.HasOne("takee.DataAccess.Entities.BreedEntity", "Breed")
                        .WithMany("Animals")
                        .HasForeignKey("BreedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("takee.DataAccess.Entities.CuratorEntity", "Curator")
                        .WithMany("Animals")
                        .HasForeignKey("CuratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("takee.DataAccess.Entities.TypeOfAnimalsEntity", "TypeOfAnimals")
                        .WithMany("Animals")
                        .HasForeignKey("TypeOfAnimalsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Breed");

                    b.Navigation("Curator");

                    b.Navigation("TypeOfAnimals");
                });

            modelBuilder.Entity("takee.DataAccess.Entities.FavouriteEntity", b =>
                {
                    b.HasOne("takee.DataAccess.Entities.AnimalEntity", "Animal")
                        .WithMany("Favorites")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("takee.DataAccess.Entities.UserEntity", "User")
                        .WithMany("Favorites")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("User");
                });

            modelBuilder.Entity("takee.DataAccess.Entities.RecordForWalkEntity", b =>
                {
                    b.HasOne("takee.DataAccess.Entities.AnimalEntity", "Animal")
                        .WithMany("RecordsForWalk")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("takee.DataAccess.Entities.UserEntity", "User")
                        .WithMany("RecordsForWalk")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("User");
                });

            modelBuilder.Entity("takee.DataAccess.Entities.UserEntity", b =>
                {
                    b.HasOne("takee.DataAccess.Entities.UserRoleEntity", "UserRole")
                        .WithMany("Users")
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("takee.DataAccess.Entities.AnimalEntity", b =>
                {
                    b.Navigation("Favorites");

                    b.Navigation("RecordsForWalk");
                });

            modelBuilder.Entity("takee.DataAccess.Entities.BreedEntity", b =>
                {
                    b.Navigation("Animals");
                });

            modelBuilder.Entity("takee.DataAccess.Entities.CuratorEntity", b =>
                {
                    b.Navigation("Animals");
                });

            modelBuilder.Entity("takee.DataAccess.Entities.TypeOfAnimalsEntity", b =>
                {
                    b.Navigation("Animals");
                });

            modelBuilder.Entity("takee.DataAccess.Entities.UserEntity", b =>
                {
                    b.Navigation("Favorites");

                    b.Navigation("RecordsForWalk");
                });

            modelBuilder.Entity("takee.DataAccess.Entities.UserRoleEntity", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
