using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options)
        {
        }



        public DbSet<User> Users { get; set; }

        public DbSet<ContactData> ContactData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

             
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<ContactData>().HasKey(p => new { p.UserId, p.ContactId });


            modelBuilder.Entity<ContactData>()
           .HasOne(pr => pr.UserData)
           .WithMany(p => p.ContactData)
           .HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);



            modelBuilder.Entity<ContactData>()
           .HasOne(p => p.UsersDatas)
           .WithMany(p => p.ContactsDatas)
           .HasForeignKey(p => p.ContactId ).OnDelete(DeleteBehavior.Restrict); ;

       

    }
    }

}



            //composite key
            //modelBuilder.Entity<ContactData>(b =>
            //{
            //    b.HasKey(x => new { x.UserId, x.ContactId });

            //b.HasOne(x => x.userData)
            //    .WithMany(x => x.contactData)
            //    .HasForeignKey(x => x.UserId);



            //        b.HasMany(x => x.users)

            //            .WithMany(x => x.contactsDatas)
            //            .HasForeignKey(x => x.ContactId, x => x.UserId);


            //    });
            //}
            //public DbSet<User> users { get; set; }




        //modelBuilder.Entity<ContactData>()
        //.HasOne(x => x.userDatas)
        //        .WithMany(x => x.contactData)
        //        .HasForeignKey(x => x.UserId)
        //        .OnDelete(DeleteBehavior.Restrict);
        //modelBuilder.Entity<ContactData>()
        //.HasOne(x => x.data)
        //    .WithMany(x => x.contact)
        //    .HasForeignKey(x => x.ContactId)
        //    .OnDelete(DeleteBehavior.Restrict);

        //modelBuilder.Entity<ContactData>()
        //    .HasMany<User>(s => s.userDatas)
        //    .WithMany(c => c.contactDatas)
        //    .HasForeignKey(c => c.UserId);

        //modelBuilder.Entity<ContactData>()
        //    .HasOne<User>(s => s.userData)
        //    .WithMany(c => c.contactDatas)
        //.HasForeignKey(c => c.ContactId);


        //configures one-to - many relationship
        //modelBuilder.Entity<ContactData>().
        //        HasOne<User>(p =>p.userDatas).
        //        WithMany(c => c.contactData).
        //        HasForeignKey(p => new { p.ContactId, p.UserId });




    





