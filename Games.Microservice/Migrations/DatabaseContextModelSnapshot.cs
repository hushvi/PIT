// <auto-generated />
using System;
using Games.Microservice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Games.Microservice.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Games.Microservice.Models.GameEventsObj", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdditionalPlayerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventTeamName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<string>("PlayerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventId");

                    b.HasIndex("GameId");

                    b.ToTable("GameEvents");
                });

            modelBuilder.Entity("Games.Microservice.Models.GamesObj", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Finished")
                        .HasColumnType("int");

                    b.Property<int>("FirstTeamGoals")
                        .HasColumnType("int");

                    b.Property<int>("FirstTeamId")
                        .HasColumnType("int");

                    b.Property<string>("GameType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Overtime")
                        .HasColumnType("int");

                    b.Property<int>("SecondTeamGoals")
                        .HasColumnType("int");

                    b.Property<int>("SecondTeamId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartingTime")
                        .HasColumnType("datetime2");

                    b.HasKey("GameId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Games.Microservice.Models.GameEventsObj", b =>
                {
                    b.HasOne("Games.Microservice.Models.GamesObj", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });
#pragma warning restore 612, 618
        }
    }
}
