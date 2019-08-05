using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Exceptions;
using DataAccess;
using Entities;

namespace BusinessLayer
{
    public class NoteService : INoteService
    {
        public readonly INoteRepository repository;

        public NoteService (INoteRepository noteRepository)
        {
            repository = noteRepository;
        }
        public int CreateNotes(Note notes)
        {
            var _notes = repository.GetNotesByID(notes.NoteId);
            if(_notes==null)
            {
                return repository.CreateNotes(notes);
            }
            else
            {
                throw new NoteAlreadyExistsException($"Notes with NoteId {notes.NoteId}already Exists");
            }
        }

        public List<Note> GetAllNotes()
        {
            return repository.GetAllNotes();
        }

        public Note GetNotesByID(int NoteId)
        {
            var _notes = repository.GetNotesByID(NoteId);
            if (_notes == null)
            {
                throw new NoteNotFoundException($"Notes with NoteId {NoteId}does not exist");
            }
            else
                return _notes;
        }

        public int RemoveNotes(int NoteId)
        {
            var _notes = repository.GetNotesByID(NoteId);
            if (_notes == null)
            {
                throw new NoteNotFoundException($"Notes with NoteId {NoteId}does not exist");
            }
            else
                return repository.RemoveNotes(NoteId);

        }

        public int UpdateNotes(Note note)
        {
            var _notes = repository.GetNotesByID(note.NoteId);
            if (_notes == null)
            {
                throw new NoteNotFoundException($"Notes with NoteId {note.NoteId}does not exist");
            }
            else
            {
                _notes.NoteId = note.NoteId;
                _notes.Title = note.Title;
                _notes.Text = note.Text;
                return repository.UpdateNotes(_notes);
            }
          

        }
    }
}
