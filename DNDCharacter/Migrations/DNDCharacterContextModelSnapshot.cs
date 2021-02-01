﻿// <auto-generated />
using DNDCharacter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DNDCharacter.Migrations
{
    [DbContext(typeof(DNDCharacterContext))]
    partial class DNDCharacterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Setting");

                    b.HasKey("CampaignId");

                    b.ToTable("Campaigns");
                });

            modelBuilder.Entity("DNDCharacter.Models.CampaignCharacter", b =>
                {
                    b.Property<int>("CampaignCharacterId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CampaignId");

                    b.Property<int>("CharacterId");

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
