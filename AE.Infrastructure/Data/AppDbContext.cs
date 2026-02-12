using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using AE.Domain.Models;
namespace AE.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // 1. Point to "My Documents" folder (Shared ground for all projects)
                // This works for the App, the Migration Tool, ANY project type.
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // 2. Name the file explicitly
                string dbPath = System.IO.Path.Combine(documentsPath, "AttendEase.db");

                // 3. Connect
                optionsBuilder.UseSqlite($"Data Source={dbPath}");
            }
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Section> Sections { get; set; } 
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Attendance> AttendanceRecords { get; set; }
    }
}
