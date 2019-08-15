using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HMS.Models
{
    public class HMSContext : DbContext
    {
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<AdvertisePosition> AdvertisePositions { get; set; }
        public DbSet<AdvertiseType> AdvertiseTypes { get; set; }
        public DbSet<Advertise> Advertises { get; set; }
        public DbSet<Duration> Durations { get; set; }
        public DbSet<PeoplePerRoom> PeoplePerRooms { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelDetail> HotelDetails { get; set; }
        public DbSet<RecentSearch> RecentSearchs { get; set; }
        public DbSet<PackageSource> PackageSources { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<PackageDetail> PackageDetails { get; set; }
        public DbSet<binaryObjectType> binaryObjectTypes { get; set; }
        public DbSet<binaryObject> binaryObjects { get; set; }
        public DbSet<Event> Events { get; set; }

        public DbSet<QuestionType> QuestionTypes { get; set; }
        //public DbSet<QuestionAnswer> QuestionAnswers { get; set; }

        public DbSet<News> News { get; set; }
        public DbSet<Experience> Experiences { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ClientInstallment>().HasRequired(p=>p.CPId).
            modelBuilder.Entity<Event>()
               .HasRequired(a => a.Fk_DocumentId1)
               .WithMany()
               .HasForeignKey(u => u.DocumentId1).WillCascadeOnDelete(false);

            //modelBuilder.Entity<Event>()
            //   .HasRequired(a => a.Fk_DocumentId2)
            //   .WithMany()
            //   .HasForeignKey(u => u.DocumentId2).WillCascadeOnDelete(false);


            modelBuilder.Entity<Event>()
               .HasRequired(a => a.Fk_Logo)
               .WithMany()
               .HasForeignKey(u => u.Logo).WillCascadeOnDelete(false);
        }
    }
}