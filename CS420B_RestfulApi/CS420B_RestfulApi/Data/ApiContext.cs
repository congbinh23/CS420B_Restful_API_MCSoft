using Microsoft.EntityFrameworkCore;
using CS420B_RestfulApi.Models;

namespace CS420B_RestfulApi.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<HotelBooking> Bookings { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }
    }
}
