using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPTreatmentMicroservice.Models
{
    public class TreatmentDBContext : DbContext
    {
        public TreatmentDBContext(DbContextOptions<TreatmentDBContext> options):base(options)
        {

        }
        public DbSet<TreatmentPlan> TreatmentPlans { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        
        }
    }
}
