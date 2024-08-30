using Microsoft.EntityFrameworkCore;

namespace PSL.Infrastructure.Data.ContextApp;

public class PSLContext : DbContext
{
    public PSLContext(DbContextOptions<PSLContext> options) : base(options)
    {
        
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}