using App.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace App.DB
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Measurement> Measurements { get; set; } = null!;
        public DbSet<MeasurementValue> MeasurementValues { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
