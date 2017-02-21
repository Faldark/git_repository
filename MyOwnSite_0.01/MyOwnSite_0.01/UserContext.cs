using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using MyOwnSite_0._01.Interfaces;
using MyOwnSite_0._01.Models;

namespace MyOwnSite_0._01
{
    public class UserContext :DbContext, IUserContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Comment>().HasRequired<Post>(s => s.Post).WithMany(s => s.Comments).WillCascadeOnDelete(false);


            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }
        
    }
}