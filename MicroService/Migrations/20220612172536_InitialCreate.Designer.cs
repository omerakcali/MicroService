// <auto-generated />
using MicroService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MicroService.Migrations
{
    [DbContext(typeof(MapContext))]
    [Migration("20220612172536_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("MicroService.MapMarker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("type1")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("type2")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("type3")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("type4")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("type5")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("type6")
                        .HasColumnType("INTEGER");

                    b.Property<float>("x")
                        .HasColumnType("REAL");

                    b.Property<float>("y")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("datas");
                });
#pragma warning restore 612, 618
        }
    }
}
