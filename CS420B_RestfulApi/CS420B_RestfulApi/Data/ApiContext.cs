using Microsoft.EntityFrameworkCore;
using CS420B_RestfulApi.Models.Table;

namespace CS420B_RestfulApi.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }
    }
}
