using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using carpark_info_assignment.Models;

namespace carpark_info_assignment.CarparkDb
{
    public class SQLiteDbContext : DbContext
    {
        public DbSet<Carpark> Carparks { get; set; }
        public DbSet<MyFavourite> MyFavourites { get; set; }

        public string DbPath { get; }

        public SQLiteDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "carpark-info-assignment.db");
            Database.EnsureCreated();
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");


    }
}