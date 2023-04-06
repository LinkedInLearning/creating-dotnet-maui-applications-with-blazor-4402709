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

        public Task AddNote(Note note)
        {
            _notes.Add(note);
            return Task.CompletedTask;
        }

        public Task DeleteNote(Note note)
        {
            _notes.Remove(note);
            return Task.CompletedTask;
        }

        public Task<Note> GetNote(int id)
        {
            var oTcs = new TaskCompletionSource<Note>();
            oTcs.SetResult(_notes.SingleOrDefault(n => n.NoteId == id));
            return oTcs.Task;
        }

        public Task<List<Note>> GetNotes(NoteType noteType)
        {
            var oTcs = new TaskCompletionSource<List<Note>>();
            oTcs.SetResult(_notes.Where(n => n.NoteType == noteType).ToList());
            return oTcs.Task;
        }
    }
}