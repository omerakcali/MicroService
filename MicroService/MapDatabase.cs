using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MicroService{
    public class MapDatabase{

        public static void SaveMarker(MapMarker marker){
            using var db = new MapContext();


            db.Add(new MapMarker{
                    x = marker.x,
                    y = marker.y,
                    type1 = marker.type1,
                    type2 = marker.type2,
                    type3 = marker.type3,
                    type4 = marker.type4,
                    type5 = marker.type5,
                    type6 = marker.type6,
                }
            );

            db.SaveChanges();

        }
    }
    
    
    public class MapContext : DbContext
    {
        public DbSet<MapMarker> datas { get; set; }

        public string DbPath { get; }

        public MapContext()
        {
            var path = @"C:\markerdatabase";
            DbPath = System.IO.Path.Join(path, "markers.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
    
    public class MapMarker{
        [Key]
        public int Id { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public bool type1 { get; set; }
        public bool type2 { get; set; }
        public bool type3 { get; set; }
        public bool type4 { get; set; }
        public bool type5 { get; set; }
        public bool type6 { get; set; }
    }
}