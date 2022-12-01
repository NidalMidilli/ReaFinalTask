using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=DESKTOP-RPBUNGP\\SQLEXPRESS;Database=TaskProject;Trusted_Connection=true;");
        }

       
        public DbSet<User> Users { get; set; }
        public DbSet<EntTask> Tasks { get; set; }

        public DbSet<Comment> Comments { get; set; }

    }
}
