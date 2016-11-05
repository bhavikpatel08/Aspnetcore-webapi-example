using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AspnetCoreWebAPI.Models;

namespace src.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20161105042447_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AspnetCoreWebAPI.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 40);

                    b.Property<decimal>("Price");

                    b.Property<string>("ProductNumber")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("Variant")
                        .HasAnnotation("MaxLength", 10);

                    b.HasKey("ProductID");

                    b.ToTable("Product");
                });
        }
    }
}
