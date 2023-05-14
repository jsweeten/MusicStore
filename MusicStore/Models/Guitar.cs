using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class GuitarContext : DbContext
{
    public DbSet<Guitar> Guitars { get; set; }

    public string DbPath { get; }

    public GuitarContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "guitars.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer($"Data Source={DbPath}");
}

public class Guitar
{
    public int GuitarId { get; set; }
    public string? Url { get; set; }
    }
