using Notes.Core.Interfaces;
using Notes.Core.Models;

namespace MauiNotes.Services
{
    public class NotesService : INotesService
    {
        private List<Note> _notes;

        public NotesService()
        {
            _notes = new List<Note>
            {
                new Note
                {
                    NoteId = 1,
                    NoteText = "Make a new MAUI Timekeeping App",
                    NoteType = NoteType.Business
                },
                new Note
                {
                    NoteId = 2,
                    NoteText = "Update task board",
                    NoteType = NoteType.Business
                },
                                new Note
                {
                    NoteId = 3,
                    NoteText = "Get milk at store",
                    NoteType = NoteType.Personal
                }
            };
        }

        public void AddNote(Note note)
        {
            _notes.Add(note);
        }

        public void DeleteNote(Note note)
        {
            _notes.Remove(note);
        }

        public Note GetNote(int id)
        {
            var returnValue =  _notes.SingleOrDefault(n => n.NoteId == id);
            if (returnValue != null)
            {
                returnValue = CopyNote(returnValue);
            }
            return returnValue;
        }

        private Note CopyNote(Note note)
        {
            return new Note
            {
                NoteId = note.NoteId,
                NoteText = note.NoteText,
                NoteType = note.NoteType,
            };
        }

        public List<Note> GetNotes(NoteType noteType)
        {
            return _notes.Where(n => n.NoteType == noteType).ToList();
        }

        public void SaveNote(Note note)
        {
            if (note.NoteId <= 0)
            {
                note.NoteId = _notes.Max(n => n.NoteId) + 1;
            }
            if (_notes.Any(n => n.NoteId == note.NoteId))
            {
                _notes.Remove(_notes.Single(n => n.NoteId == note.NoteId));
            }
            _notes.Add(note);
        }
    }
}