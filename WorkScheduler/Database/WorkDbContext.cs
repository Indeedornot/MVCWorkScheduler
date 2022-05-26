using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WorkScheduler.Data;

namespace WorkScheduler.Database;

public sealed class WorkDbContext : DbContext
{
    public WorkDbContext(DbContextOptions<WorkDbContext> options) : base(options)
    {
        ChangeTracker.Tracked += OnEntityTracked;
        ChangeTracker.StateChanged += OnEntityStateChanged;
    }

    void OnEntityTracked(object? sender, EntityTrackedEventArgs e)
    {
        if (e.FromQuery || e.Entry.State != EntityState.Added || e.Entry.Entity is not Work entity) return;
        
        entity.Created = DateTime.Now;
        entity.Updated = DateTime.Now;
    }

    void OnEntityStateChanged(object? sender, EntityStateChangedEventArgs e)
    {
        if (e.NewState != EntityState.Modified || e.Entry.Entity is not Work entity) return;
        entity.Updated = DateTime.Now;
        if (entity.Created == DateTime.MinValue)
        {
            entity.Created = DateTime.Now;
        }
        
    }
    public DbSet<Work> Works { get; set; }
}