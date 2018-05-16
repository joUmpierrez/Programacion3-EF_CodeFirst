using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Data.Entity;

namespace DAL
{
    public class RestaurantContext : DbContext
    {
        public DbSet<Client> clients { get; set; }
        public DbSet<Address> addresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(u => u.idCard)
                .HasColumnName("Id Card");
        }
    }
}
