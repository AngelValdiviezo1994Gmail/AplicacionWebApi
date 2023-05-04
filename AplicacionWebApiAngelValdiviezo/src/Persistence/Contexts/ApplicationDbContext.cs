


using AngelValdiviezoWebApi.Domain.Entities.Acontecimientos;
using AngelValdiviezoWebApi.Domain.Entities.Eventos;
using Microsoft.EntityFrameworkCore;
namespace AngelValdiviezoWebApi.Persistence.Contexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

    }
    
    public DbSet<tblEventoNextTi> eventosModels => Set<tblEventoNextTi>();
    public DbSet<AcontecimientosModels> acontecimientosModels => Set<AcontecimientosModels>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    //{
    //    foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
    //    {
    //        switch (entry.State)
    //        {
    //            case EntityState.Added:
    //                entry.Entity.Created = _dateTimeService.NowUtc;
    //                entry.Entity.Uid = new Guid();
    //                break;
    //            case EntityState.Modified:
    //                entry.Entity.LastModified = _dateTimeService.NowUtc;
    //                break;
    //        }
    //    }
    //    return await base.SaveChangesAsync(cancellationToken);
    //}
}