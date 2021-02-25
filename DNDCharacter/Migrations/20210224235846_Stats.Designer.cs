﻿// <auto-generated />
using DNDCharacter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DNDCharacter.Migrations
{
    [DbContext(typeof(DNDCharacterContext))]
    [Migration("20210224235846_Stats")]
    partial class Stats
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DNDCharacter.Models.Campaign", b =>
                {
                    b.Property<int>("CampaignId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Rulebook");

                    b.Property<string>("Setting");

                    b.HasKey("CampaignId");

                    b.ToTable("Campaigns");
                });

            modelBuilder.Entity("DNDCharacter.Models.CampaignCharacter", b =>
                {
                    b.Property<int>("CampaignCharacterId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CampaignId");

                    b.Property<bool>("CharacterDeath");

                    b.Property<int>("CharacterId");

                    b.Property<int>("StatId");

                    b.HasKey("CampaignCharacterId");

                    b.HasIndex("CampaignId");

                    b.HasIndex("CharacterId");

                    b.ToTable("CampaignCharacter");
                });

            modelBuilder.Entity("DNDCharacter.Models.Character", b =>
                {
                    b.Property<int>("CharacterId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CharacterName");

                    b.Property<string>("Description");

                    b.Property<string>("Player");

                    b.Property<string>("RPClass");

                    b.HasKey("CharacterId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("DNDCharacter.Models.CampaignCharacter", b =>
                {
                    b.HasOne("DNDCharacter.Models.Campaign", "Campaign")
                        .WithMany("Characters")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DNDCharacter.Models.Character", "Character")
                        .WithMany("Campaigns")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
