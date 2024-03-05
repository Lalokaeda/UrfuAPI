using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UrfuAPI.Models;

namespace UrfuAPI;

public partial class UrfuBaseContext : DbContext
{

    public UrfuBaseContext(DbContextOptions<UrfuBaseContext> options)
        : base(options)
    {
    }

     public virtual DbSet<Article> Articles {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
