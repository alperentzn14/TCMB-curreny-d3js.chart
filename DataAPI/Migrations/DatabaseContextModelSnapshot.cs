// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Provision.Data;

namespace Provision.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ProvisionWebApi.Entities.Currency", b =>
                {
                    b.Property<long>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CurrencyCode")
                        .HasColumnType("text");

                    b.Property<decimal>("EffectiveBuyingAmount")
                        .HasColumnType("numeric");

                    b.Property<decimal>("EffectiveSellingAmount")
                        .HasColumnType("numeric");

                    b.Property<decimal>("ForexBuyingAmount")
                        .HasColumnType("numeric");

                    b.Property<decimal>("ForexSellingAmount")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Unit")
                        .HasColumnType("integer");

                    b.HasKey("RecordId");

                    b.ToTable("Currencies");
                });
#pragma warning restore 612, 618
        }
    }
}
