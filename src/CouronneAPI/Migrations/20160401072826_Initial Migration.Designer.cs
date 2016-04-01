using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using DataAccess;

namespace CouronneAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160401072826_Initial Migration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
