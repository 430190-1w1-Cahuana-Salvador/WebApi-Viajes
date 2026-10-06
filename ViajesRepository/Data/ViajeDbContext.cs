using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViajesRepository.Domain;

namespace ViajesRepository.Data
{
    public class ViajeDbContext : DbContext
    {
        public ViajeDbContext( DbContextOptions<ViajeDbContext> options)
            :base(options)
        {
            
        }

        public DbSet<Viaje> Viajes { get; set; }
        public DbSet<ViajeDetalle> ViajeDetalles { get; set; }
        public DbSet<Excursion> Excursiones { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Viaje>()
                .HasMany(v => v.ViajeDetalles)
                .WithOne(vd => vd.Viaje)
                .HasForeignKey(vd => vd.ViajeId);

            modelBuilder.Entity<Excursion>()
                .HasMany(e => e.ViajeDetalles)
                .WithOne(vd => vd.Excursion)
                .HasForeignKey(vd => vd.ExcursionId);


        }
    }
}
