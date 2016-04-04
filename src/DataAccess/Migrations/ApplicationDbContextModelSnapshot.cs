using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using DataAccess;

namespace DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccess.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("PlayDate");

                    b.Property<int>("Player1");

                    b.Property<int>("Player2");

                    b.Property<int?>("PlayerId");

                    b.Property<int>("Winner");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("DataAccess.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("UserName");

                    b.Property<int>("Wins");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("DataAccess.Entities.Game", b =>
                {
                    b.HasOne("DataAccess.Entities.Player")
                        .WithMany()
                        .HasForeignKey("PlayerId");
                });
        }
    }
}
