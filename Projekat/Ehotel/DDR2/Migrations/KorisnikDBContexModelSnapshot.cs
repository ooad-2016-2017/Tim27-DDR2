using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using DDR2.EHotelBaza.Models;

namespace DDR2Migrations
{
    [ContextType(typeof(KorisnikDBContext))]
    partial class KorisnikDBContexModelSnapshot : ModelSnapshot
    {
        public override void BuildModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("DDR2.EHotelBaza.Models.Korisnik", b =>
                {
                    b.Property<int>("KorisnikId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("adresa");

                    b.Property<DateTime>("dat_rodjenja");

                    b.Property<string>("drzava");

                    b.Property<string>("email");

                    b.Property<string>("fourSqaureId");

                    b.Property<string>("grad");

                    b.Property<string>("ime");

                    b.Property<string>("password");

                    b.Property<string>("prezime");

                    b.Property<string>("telefon");

                    b.Property<string>("username");

                    b.Key("KorisnikId");
                });
        }
    }
}
