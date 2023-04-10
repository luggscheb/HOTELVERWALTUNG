using Hotel;
using Microsoft.EntityFrameworkCore;
namespace HotelAPI.Models.DB
{
    public class Hotel_Context : DbContext
    {
        public DbSet<BillRoom> Billsroom { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Customer> Customers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=localhost;database=hotelverwaltung_vogt;user=root;password=root";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

    }
}
