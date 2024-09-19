using System;
using ComandaPlus_Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ComandaPlus_Data.Context;

public class DatabaseContext : DbContext
{
    public DatabaseContext() : base() {}
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

    public DbSet<User> Users { get;}
    
    protected override void OnModelCreating(ModelBuilder builder){
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
    }
}
