using Microsoft.EntityFrameworkCore;
using NoteApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.DataBase
{
    public class NoteEntity : IDataHelper<Note>
    {
        DataBaseContext db;
        public NoteEntity() 
        {
            db = new DataBaseContext();
        }
        public async Task AddDataAsync(Note table)
        {
            await db.Notes.AddAsync(table);
            await db.SaveChangesAsync();
        }

        public async Task<Note> FindAsync(int Id)
        {
            return await db.Notes.FindAsync(Id);
        }

        public async Task<List<Note>> GetAllAsync()
        {
          return await db.Notes.ToListAsync();
        }

        public async Task RemoveDataAsync(Note table)
        {
            db.Notes.Remove(table);
            await db.SaveChangesAsync();
        }

        public async Task UpdateDataAsync(Note table)
        {
            db=new DataBaseContext();
            db.Notes.Update(table);
            await db.SaveChangesAsync();
        }
    }
}
