using Microsoft.EntityFrameworkCore;
using SocialNetwork.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
 
        public DbSet<Propiedad> Property { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region Tablenames
             
           modelBuilder.Entity<Propiedad>().ToTable("Propiedad");

            #endregion

            #region TableIDs

            modelBuilder.Entity<Propiedad>().HasKey(e => e.id);

            #endregion

            #region Relationships

            //modelBuilder.Entity<Entity>().HasMany<Entity2>(e => e.enumerable)
            // .WithOne<Entity2>(e => e.nav).HasForeignKey(e => e.id).OnDelete(DeleteBehavior.Cascade);

            #endregion

        }

    }
}
