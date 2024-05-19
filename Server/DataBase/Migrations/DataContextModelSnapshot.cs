﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Server.DataBase;

#nullable disable

namespace Server.DataBase.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Server.DataBase.Entities.BookmarkEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NameUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RecipeEntityId")
                        .HasColumnType("integer");

                    b.Property<int>("UserEntityId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RecipeEntityId");

                    b.HasIndex("UserEntityId");

                    b.ToTable("Bookmarks");
                });

            modelBuilder.Entity("Server.DataBase.Entities.CommentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Guid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Published")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<int>("RecipeEntityId")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("UserEntityId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RecipeEntityId");

                    b.HasIndex("UserEntityId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Server.DataBase.Entities.ImageEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateUpload")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserEntityId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserEntityId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Server.DataBase.Entities.RecipeEnergyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CaloriesFrom")
                        .HasColumnType("integer");

                    b.Property<int>("CaloriesTo")
                        .HasColumnType("integer");

                    b.Property<int>("CarbohydratesFrom")
                        .HasColumnType("integer");

                    b.Property<int>("CarbohydratesTo")
                        .HasColumnType("integer");

                    b.Property<int>("FatsFrom")
                        .HasColumnType("integer");

                    b.Property<int>("FatsTo")
                        .HasColumnType("integer");

                    b.Property<int>("ProteinsFrom")
                        .HasColumnType("integer");

                    b.Property<int>("ProteinsTo")
                        .HasColumnType("integer");

                    b.Property<int>("RecipeEntityId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RecipeEntityId")
                        .IsUnique();

                    b.ToTable("RecipeEnergy");
                });

            modelBuilder.Entity("Server.DataBase.Entities.RecipeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<TimeSpan>("CookingTimeInMinutes")
                        .HasColumnType("interval");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MainImageName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<int>("UserEntityId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserEntityId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("Server.DataBase.Entities.RecipeIngredientEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("RecipeEntityId")
                        .HasColumnType("integer");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RecipeEntityId");

                    b.ToTable("RecipeIngredients");
                });

            modelBuilder.Entity("Server.DataBase.Entities.RecipeStepEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RecipeEntityId")
                        .HasColumnType("integer");

                    b.Property<int>("StepNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RecipeEntityId");

                    b.ToTable("RecipeSteps");
                });

            modelBuilder.Entity("Server.DataBase.Entities.RevokedTokenEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("RevokedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("RevokedTokens");
                });

            modelBuilder.Entity("Server.DataBase.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .HasColumnType("text");

                    b.Property<string>("ProfilePhoto")
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Server.DataBase.Entities.BookmarkEntity", b =>
                {
                    b.HasOne("Server.DataBase.Entities.RecipeEntity", null)
                        .WithMany("Bookmarks")
                        .HasForeignKey("RecipeEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server.DataBase.Entities.UserEntity", null)
                        .WithMany("Bookmarks")
                        .HasForeignKey("UserEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Server.DataBase.Entities.CommentEntity", b =>
                {
                    b.HasOne("Server.DataBase.Entities.RecipeEntity", "RecipeEntity")
                        .WithMany("Comments")
                        .HasForeignKey("RecipeEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server.DataBase.Entities.UserEntity", null)
                        .WithMany("Comments")
                        .HasForeignKey("UserEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RecipeEntity");
                });

            modelBuilder.Entity("Server.DataBase.Entities.ImageEntity", b =>
                {
                    b.HasOne("Server.DataBase.Entities.UserEntity", null)
                        .WithMany("Files")
                        .HasForeignKey("UserEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Server.DataBase.Entities.RecipeEnergyEntity", b =>
                {
                    b.HasOne("Server.DataBase.Entities.RecipeEntity", "RecipeEntity")
                        .WithOne("Energy")
                        .HasForeignKey("Server.DataBase.Entities.RecipeEnergyEntity", "RecipeEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RecipeEntity");
                });

            modelBuilder.Entity("Server.DataBase.Entities.RecipeEntity", b =>
                {
                    b.HasOne("Server.DataBase.Entities.UserEntity", null)
                        .WithMany("Recipes")
                        .HasForeignKey("UserEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Server.DataBase.Entities.RecipeIngredientEntity", b =>
                {
                    b.HasOne("Server.DataBase.Entities.RecipeEntity", "RecipeEntity")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RecipeEntity");
                });

            modelBuilder.Entity("Server.DataBase.Entities.RecipeStepEntity", b =>
                {
                    b.HasOne("Server.DataBase.Entities.RecipeEntity", "RecipeEntity")
                        .WithMany("Steps")
                        .HasForeignKey("RecipeEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RecipeEntity");
                });

            modelBuilder.Entity("Server.DataBase.Entities.RecipeEntity", b =>
                {
                    b.Navigation("Bookmarks");

                    b.Navigation("Comments");

                    b.Navigation("Energy")
                        .IsRequired();

                    b.Navigation("Ingredients");

                    b.Navigation("Steps");
                });

            modelBuilder.Entity("Server.DataBase.Entities.UserEntity", b =>
                {
                    b.Navigation("Bookmarks");

                    b.Navigation("Comments");

                    b.Navigation("Files");

                    b.Navigation("Recipes");
                });
#pragma warning restore 612, 618
        }
    }
}
