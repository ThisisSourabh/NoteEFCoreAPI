using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;

namespace DataAccess
{
    public class NoteRepository : INoteRepository
    {
        private readonly NoteDbContext context;
        
        public NoteRepository(NoteDbContext noteDbContext)
        {
            context = noteDbContext;
        }
        public int CreateNotes(Note notes)
        {
            context.Notes.Add(notes);
            return context.SaveChanges();
        }

        public List<Note> GetAllNotes()
        {
            return context.Notes.ToList();
        }

        public Note GetNotesByID(int NoteId)
        {
            return context.Notes.Find(NoteId);
        }

        public int RemoveNotes(int NoteId)
        {
            var notes = context.Notes.Find(NoteId);
            context.Notes.Remove(notes);
            return context.SaveChanges();
        }

        public int UpdateNotes(Note note)
        {
            context.Entry<Note>(note).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return context.SaveChanges();
        }
    }
}
