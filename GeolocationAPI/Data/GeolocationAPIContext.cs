using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GeolocationAPI.Models
{
    public class GeolocationAPIContext : DbContext
    {
        public GeolocationAPIContext (DbContextOptions<GeolocationAPIContext> options)
            : base(options)
        {
        }

        public DbSet<GeolocationAPI.Models.GeolocationData> GeolocationData { get; set; }
    }
}
