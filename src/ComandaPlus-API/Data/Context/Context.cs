using System;
using ComandaPlus_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ComandaPlus_API.Context;

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
