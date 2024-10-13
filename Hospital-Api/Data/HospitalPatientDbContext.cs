using Hospital_Api.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Api.Data
{
    public class HospitalPatientDbContext : IdentityDbContext
    {
        public HospitalPatientDbContext(DbContextOptions<HospitalPatientDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<MedicalRecordHistory> MedicalRecordHistory { get; set; }
        public DbSet<Staff> Staff { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var readerRoleId = "e81ba48a-d4c4-47ba-ad67-a4c0008fb26f";
            var writerRoleId = "788b27ff-dd6c-44ba-b7e4-3c2f9d77b31a";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },
                new IdentityRole
                 {
                    Id = writerRoleId,
                    ConcurrencyStamp = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }

}
