using Microsoft.EntityFrameworkCore;
using NoteApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.DataBase
{
    public class DataBaseContext:DbContext
    {
        public DbSet<Note> Notes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filename = Path.Combine(path, "NoteAppDB.db");
            optionsBuilder.UseSqlite($"FileName={filename}");
        }
    }
}
