using DestekPaneli.Domain.Common;
using DestekPaneli.Domain.Entities;
using DestekPaneli.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace DestekPaneli.Persistence.Context
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketMessage> TicketMessages { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is BaseEntity entity)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entity.CreatedAt = DateTimeOffset.Now;
                            break;
                        case EntityState.Modified:
                            if (entity.IsDeleted)
                            {
                                entity.DeletedAt = DateTimeOffset.Now;
                            }
                            else
                            {
                                entity.UpdatedAt = DateTimeOffset.Now;
                            }
                            break;
                    }
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(i => i.TicketStatus)
                    .HasConversion(
                        v => v.Value,
                        v => TicketStatusEnum.FromValue(v));

                entity.Property(i => i.Priority)
                    .HasConversion(
                        v => v.Value,
                        v => PriorityLevelEnum.FromValue(v));

            });
            modelBuilder.Entity<TicketMessage>(entity =>
            {
                entity.HasOne(i => i.Sender)
                .WithMany()
                .HasForeignKey(i => i.SenderId)
                .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
