﻿using System;
using Microsoft.EntityFrameworkCore;

namespace ModisAPI.Models
{
    public class ModisContext : DbContext
    {

        public DbSet<Studente> Studenti { get; set; }

        public DbSet<Corso> Corsi { get; set; }

        public DbSet<StudenteCorso> StudenteCorsi { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            modelBuilder.Entity<StudenteCorso>()
                .HasKey(sc => new { sc.StudenteId, sc.CorsoId });

            modelBuilder.Entity<StudenteCorso>()
            .HasOne(bc => bc.Studente)
            .WithMany(b => b.StudenteCorsi)
            .HasForeignKey(bc => bc.StudenteId);

            modelBuilder.Entity<StudenteCorso>()
                .HasOne(bc => bc.Corso)
                .WithMany(c => c.StudenteCorsi)
                .HasForeignKey(bc => bc.CorsoId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {

            var connection = "Data Source=Modis.db;";


            optionsBuilder.UseSqlite(connection);

        }

    }

}

/*  /Users/Cimusini/SQLITEDATABASES/SQLITEDB1.sqlite;  */