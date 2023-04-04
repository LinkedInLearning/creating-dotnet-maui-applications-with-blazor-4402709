using Notes.Core.Interfaces;
using Notes.Core.Models;
using SQLite;

namespace MauiNotes.Services
{
    public class NotesService : INotesService
    {
        SQLiteConnection _Connection;

        public NotesService()
        {
            _Connection = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
            _Connection.CreateTable<Note>();
        }

        public void AddNote(Note note)
        {
            _Connection.Insert(note);
        }

        public void DeleteNote(Note note)
        {
            _Connection.Delete(note);
        }

        public Note GetNote(int id)
        {
            return _Connection.Table<Note>().SingleOrDefault(n => n.NoteId == id);
        }

        public List<Note> GetNotes(NoteType noteType)
        {
            return _Connection.Table<Note>().Where(n => n.NoteType == noteType).ToList();
        }

        public void SaveNote(Note note)
        {
            _Connection.InsertOrReplace(note);
        }
    }
}