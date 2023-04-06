using Notes.Core.Interfaces;
using Notes.Core.Models;
using SQLite;
using static Android.Content.ClipData;

namespace MauiNotes.Services
{
    public class NotesService : INotesService
    {
        SQLiteAsyncConnection _Connection;

        public NotesService()
        {
            _Connection = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            _Connection.CreateTableAsync<Note>();
        }

        public async Task AddNote(Note note)
        {
            await _Connection.InsertAsync(note);
        }

        public async Task DeleteNote(Note note)
        {
            await _Connection.DeleteAsync(note);
        }

        public async Task<Note> GetNote(int id)
        {
            return await _Connection.Table<Note>().FirstOrDefaultAsync(n => n.NoteId == id);
        }
        
        public async Task<List<Note>> GetNotes(NoteType noteType)
        {
            return await _Connection.Table<Note>().Where(n => n.NoteType == noteType).ToListAsync();
        }

        public async Task SaveNote(Note note)
        {
            if (note.NoteId > 0)
            {
                await _Connection.UpdateAsync(note);
            }
            else
            {
                await _Connection.InsertAsync(note);
            }
        }
    }
}