using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UrfuAPI;

public partial class UrfuBaseContext : DbContext
{
    public UrfuBaseContext()
    {
    }

    public UrfuBaseContext(DbContextOptions<UrfuBaseContext> options)
        : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
