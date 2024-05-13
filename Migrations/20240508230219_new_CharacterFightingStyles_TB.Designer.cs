﻿// <auto-generated />
using System;
using AvatarTLAB.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AvatarTLAB.Backend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240508230219_new_CharacterFightingStyles_TB")]
    partial class new_CharacterFightingStyles_TB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AvatarTLAB.Backend.Models.Alias", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CharacterId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("Aliases");
                });

            modelBuilder.Entity("AvatarTLAB.Backend.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<int>("ElementId")
                        .HasColumnType("int");

                    b.Property<string>("EyesColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FirstEpisodeId")
                        .HasColumnType("int");

                    b.Property<string>("HairColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LastEpisodeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NationId")
                        .HasColumnType("int");

                    b.Property<string>("Pronouns")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SkinColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ElementId");

                    b.HasIndex("FirstEpisodeId");

                    b.HasIndex("LastEpisodeId");

                    b.HasIndex("NationId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("AvatarTLAB.Backend.Models.CharacterFightingStyle", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("FightingStyleId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "FightingStyleId");

                    b.HasIndex("FightingStyleId");

                    b.ToTable("CharacterFightingStyle");
                });

            modelBuilder.Entity("AvatarTLAB.Backend.Models.Element", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Elements");
                });

            modelBuilder.Entity("AvatarTLAB.Backend.Models.Episode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EpisodeNumber")
                        .HasColumnType("int");

                    b.Property<DateOnly>("ReleaseDate")
                        .HasColumnType("date");

                    b.Property<int>("SeasonNumber")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Episodes");
                });

            modelBuilder.Entity("AvatarTLAB.Backend.Models.FightingStyle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ElementId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ElementId");

                    b.ToTable("FightingStyles");
                });

            modelBuilder.Entity("AvatarTLAB.Backend.Models.Nation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Capital")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LeaderId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Nations");
                });

            modelBuilder.Entity("AvatarTLAB.Backend.Models.Alias", b =>
                {
                    b.HasOne("AvatarTLAB.Backend.Models.Character", null)
                        .WithMany("Aliases")
                        .HasForeignKey("CharacterId");
                });

            modelBuilder.Entity("AvatarTLAB.Backend.Models.Character", b =>
                {
                    b.HasOne("AvatarTLAB.Backend.Models.Element", "Element")
                        .WithMany()
                        .HasForeignKey("ElementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AvatarTLAB.Backend.Models.Episode", "FirstEpisode")
                        .WithMany()
                        .HasForeignKey("FirstEpisodeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AvatarTLAB.Backend.Models.Episode", "LastEpisode")
                        .WithMany()
                        .HasForeignKey("LastEpisodeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AvatarTLAB.Backend.Models.Nation", "Nation")
                        .WithMany()
                        .HasForeignKey("NationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Element");

                    b.Navigation("FirstEpisode");

                    b.Navigation("LastEpisode");

                    b.Navigation("Nation");
                });

            modelBuilder.Entity("AvatarTLAB.Backend.Models.CharacterFightingStyle", b =>
                {
                    b.HasOne("AvatarTLAB.Backend.Models.Character", "Character")
                        .WithMany("CharacterFightingStyles")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AvatarTLAB.Backend.Models.FightingStyle", "FightingStyle")
                        .WithMany("CharacterFightingStyles")
                        .HasForeignKey("FightingStyleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("FightingStyle");
                });

            modelBuilder.Entity("AvatarTLAB.Backend.Models.FightingStyle", b =>
                {
                    b.HasOne("AvatarTLAB.Backend.Models.Element", "Element")
                        .WithMany()
                        .HasForeignKey("ElementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Element");
                });

            modelBuilder.Entity("AvatarTLAB.Backend.Models.Character", b =>
                {
                    b.Navigation("Aliases");

                    b.Navigation("CharacterFightingStyles");
                });

            modelBuilder.Entity("AvatarTLAB.Backend.Models.FightingStyle", b =>
                {
                    b.Navigation("CharacterFightingStyles");
                });
#pragma warning restore 612, 618
        }
    }
}