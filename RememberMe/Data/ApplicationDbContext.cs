using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RememberMe.Models;
using RememberMe.Models._ModelDefs;

namespace RememberMe.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Mission> missions { get; set; }

        #region Async
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.ChangeTracker.DetectChanges();
            await _BeforeAddingAsync();
            _BeforeDeleting();
            return (await base.SaveChangesAsync(true, cancellationToken));
        }

        private async Task _BeforeAddingAsync()
        {
            var added = this.ChangeTracker.Entries()
                        .Where(t => t.State == EntityState.Added)
                        .Select(t => t.Entity)
                        .ToArray();

            foreach (var entity in added)
            {


                if (entity is DbObject)
                {
                    DbObject temp = entity as DbObject;
                    temp.CreatedAt = DateTime.Now;
                }
            }
        }

        #endregion
        #region Normal
        public override int SaveChanges()
        {

            this.ChangeTracker.DetectChanges();
            _BeforeAdding();
            _BeforeDeleting();

            return base.SaveChanges();
        }
        private void _BeforeAdding()
        {
            var added = this.ChangeTracker.Entries()
                        .Where(t => t.State == EntityState.Added)
                        .Select(t => t.Entity)
                        .ToArray();

            foreach (var entity in added)
            {


                if (entity is DbObject)
                {
                    DbObject temp = entity as DbObject;
                    temp.CreatedAt = DateTime.Now;
                }

            }
        }
        private void _BeforeDeleting()
        {
            var deleted = this.ChangeTracker.Entries()
                        .Where(t => t.State == EntityState.Deleted)
                        .Select(t => t.Entity)
                        .ToArray();
        }
        #endregion
    }
}
