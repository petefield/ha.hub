using System.Collections.Generic;
using System.Text.Json;
using ha.data.models;
using Microsoft.EntityFrameworkCore;

namespace ha.data
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(
                @"Server=tcp:ha-thefields.database.windows.net,1433;Initial Catalog=ha;Persist Security Info=False;User ID=hauser;Password=EZS7XzL4$WX?aE%H;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DbDevice>()
                .Property(b => b.Config)
                .HasConversion(
                    v => JsonSerializer.Serialize(v,null),
                    v => JsonSerializer.Deserialize<Dictionary<string, string>>(v,null));
        }

        public DatabaseContext()
        { }

        internal DbSet<DbDevice> Devices { get; set; }
        internal DbSet<DBCommand> DeviceStates { get; set; }
        internal DbSet<DbScene> Scenes { get; set; }
    }
}
 