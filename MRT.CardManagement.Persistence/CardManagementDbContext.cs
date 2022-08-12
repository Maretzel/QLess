using Microsoft.EntityFrameworkCore;
using MRT.CardManagement.Domain;
using MRT.CardManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MRT.CardManagement.Persistence
{
    public class CardManagementDbContext : DbContext
    {
        public CardManagementDbContext(DbContextOptions<CardManagementDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CardManagementDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastModifiedDate = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);

        }

        public DbSet<Card> Card { get; set; }
        public DbSet<CardType> CardType { get; set; }
        public DbSet<TransactionHistory> TransactionHistory { get; set; }

    }
}
