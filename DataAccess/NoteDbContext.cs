using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DataAccess
{
    public class NoteDbContext:DbContext
    {
        public NoteDbContext() { }
        public NoteDbContext(DbContextOptions<NoteDbContext>options):base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Label> Labels { get; set; }


    }
}
