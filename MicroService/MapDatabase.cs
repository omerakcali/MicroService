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

        public static List<MapMarker> GetMarkers(float lat, float lon)
        {
            using (var db = new MapContext())
            {
                var query = db.datas.ToList().Where(x => measure(x.x, x.y, lat, lon) < 500)
                .OrderByDescending(x => measure(x.x, x.y, lat, lon));
                return query.ToList();
            }
        }

        static double measure(float lat1, float lon1, float lat2, float lon2){ // generally used geo measurement function
            var R = 6378.137; // Radius of earth in KM
            var dLat = lat2 * Math.PI / 180 - lat1 * Math.PI / 180;
            var dLon = lon2 * Math.PI / 180 - lon1 * Math.PI / 180;
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(lat1 * Math.PI / 180) * Math.Cos(lat2 * Math.PI / 180) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = R * c;
            return d; // kilometerss
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