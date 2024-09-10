using System;
using ComandaPlus_Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ComandaPlus_Data.Context;

public class Context : DbContext
{
    public Context() : base() {}
    public Context(DbContextOptions<Context> options) : base(options) {}

    public DbSet<User> Users { get;}
    
    protected override void OnModelCreating(ModelBuilder builder){
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
    }
}
