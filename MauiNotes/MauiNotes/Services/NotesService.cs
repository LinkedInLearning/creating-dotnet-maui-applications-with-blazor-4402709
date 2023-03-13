using MauiNotes.Interfaces;
using MauiNotes.Models;

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
            return _notes.SingleOrDefault(n => n.NoteId == id);
        }

        public List<Note> GetNotes(NoteType noteType)
        {
            return _notes.Where(n => n.NoteType == noteType).ToList();
        }
    }
}