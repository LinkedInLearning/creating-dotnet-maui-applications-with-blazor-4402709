using Notes.Core.Interfaces;
using Notes.Core.Models;

namespace WasmNotes.Services
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
            var returnValue = _notes.SingleOrDefault(n => n.NoteId == id);
            if (returnValue != null)
            {
                returnValue = CopyNote(returnValue);
            }
            oTcs.SetResult(returnValue);
            return oTcs.Task;
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

        public Task<List<Note>> GetNotes(NoteType noteType)
        {
            var oTcs = new TaskCompletionSource<List<Note>>();
            oTcs.SetResult(_notes.Where(n => n.NoteType == noteType).ToList());
            return oTcs.Task;
        }

        public Task SaveNote(Note note)
        {
            var oTcs = new TaskCompletionSource<Note>();
            if (note.NoteId <= 0)
            {
                note.NoteId = _notes.Max(n => n.NoteId) + 1;
            }
            if (_notes.Any(n => n.NoteId == note.NoteId))
            {
                _notes.Remove(_notes.Single(n => n.NoteId == note.NoteId));
            }
            _notes.Add(note);

            oTcs.SetResult(note);
            return oTcs.Task;
        }
    }
}