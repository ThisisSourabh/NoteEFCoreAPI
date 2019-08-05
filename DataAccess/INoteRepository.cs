using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface INoteRepository
    {
        Note GetNotesByID(int NoteId);
        List<Note> GetAllNotes();
        int CreateNotes(Note notes);
        int RemoveNotes(int NoteId);
        int UpdateNotes(Note note);

    }
}
