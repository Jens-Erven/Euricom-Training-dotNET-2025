using GymManagment.Application.Common.Interfaces;
using GymManagment.Domain.Subscriptions;
using Microsoft.EntityFrameworkCore;

namespace GymManagment.Infrastructure.Common.Persistence
{
    public class GymManagementDbContext : DbContext, IUnitOfWork
    {
        public DbSet<Subscription> Subscriptions { get; set; } = null!;
        public GymManagementDbContext(DbContextOptions options) : base(options)
        {

        }

        public async Task CommitChangesAsync()
        {
            await base.SaveChangesAsync();
        }

    }
}
