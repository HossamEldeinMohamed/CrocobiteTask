using CrocobitTask.Data_Access.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrocobitTask.DataAccessLayer.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.SeedCompany(modelBuilder);
            modelBuilder.Entity<Registration>()
                   .HasOne(d => d.SendingCompany)
                    .WithMany(p => p.SendingRegistrations)
                    .HasForeignKey(d => d.SendingCompanyID)
                     .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Registration>()
                  .HasOne(d => d.ReceivingCompany)
                    .WithMany(p => p.ReceivingRegistrations)
                    .HasForeignKey(d => d.ReceivingCompanyID)
                    .OnDelete(DeleteBehavior.Restrict);


            //modelBuilder.Entity<Registration>(entity =>
            //{

            //    entity.HasOne(d => d.SendingCompany)
            //        .WithMany(p => p.SendingRegistrations)
            //        .HasForeignKey(d => d.SendingCompanyID)
            //        .HasConstraintName("FK_RecevingCompanyID");
            //    entity.HasOne(d => d.ReceivingCompany)
            //        .WithMany(p => p.ReceivingRegistrations)
            //        .HasForeignKey(d => d.ReceivingCompanyID)
            //        .HasConstraintName("FK_SendingCompanyID");
            //});
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        private void SeedCompany(ModelBuilder builder)
        {
            builder.Entity<Company>().HasData(
                new Company() { Id = Guid.NewGuid(), Name = "Crocobite1" },
                new Company() { Id = Guid.NewGuid(), Name = "Crocobite2" },
                new Company() { Id = Guid.NewGuid(), Name = "Crocobite3" },
                new Company() { Id = Guid.NewGuid(), Name = "Crocobite4" }
                );
        }
    }     
}
