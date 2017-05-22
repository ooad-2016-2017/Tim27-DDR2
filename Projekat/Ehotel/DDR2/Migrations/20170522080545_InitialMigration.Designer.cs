using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using DDR2.EHotelBaza.Models;

namespace DDR2Migrations
{
    [ContextType(typeof(SobaDbContext))]
    partial class InitialMigration
    {
        public override string Id
        {
            get { return "20170522080545_InitialMigration"; }
        }

        public override string ProductVersion
        {
            get { return "7.0.0-beta6-13815"; }
        }

        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("DDR2.EHotelBaza.Models.Soba", b =>
                {
                    b.Property<int>("SobaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Broj");

                    b.Property<double>("Cijena");

                    b.Property<string>("Naziv");

                    b.Property<bool>("Ociscena");

                    b.Property<byte[]>("Slika")
                        .Annotation("Relational:ColumnType", "image");

                    b.Property<bool>("Slobodna");

                    b.Property<int>("Tip");

                    b.Key("SobaId");
                });
        }
    }
}
