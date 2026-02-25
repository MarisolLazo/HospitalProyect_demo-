using HospitalProyect.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalProyect.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<StaffModel> Staff { get; set; }
        public DbSet<StaffCategoryModel> specialtyCategoryModel { get; set; }
        public DbSet<SpecialtyModel> specialtyModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StaffModel>()
                .HasOne(s => s.Specialty)
                .WithMany(sp => sp.StaffMembers)
                .HasForeignKey(s => s.SpecialtyId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
