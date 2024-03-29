﻿using Microsoft.EntityFrameworkCore;
using MotoXShare.Infraestructure.Data.Mapping.Base;

namespace MotoXShare.Infraestructure.Context;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    public ApplicationContext() : base()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("User ID=postgres;Password=Gc$#@130201---;Host=localhost;Port=5432;Database=MotoXShareDB;Pooling=true;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IEntityFrameworkEntrypoint).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}