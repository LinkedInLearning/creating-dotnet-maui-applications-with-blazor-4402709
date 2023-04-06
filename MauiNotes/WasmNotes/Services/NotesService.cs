using IndexedDB.Blazor;
using Microsoft.JSInterop;
using Notes.Core.Interfaces;
using Notes.Core.Models;
using System;

namespace WasmNotes.Services
{
    public class NotesService : INotesService
    {
        private readonly IIndexedDbFactory _DbFactory;

        public NotesService(IIndexedDbFactory dbFactory)
        {
            this._DbFactory = dbFactory;

            _DbFactory.Create<NotesDb>();
        }

        public async Task AddNote(Note note)
        {
            using (var db = await _DbFactory.Create<NotesDb>())
            {
                db.Notes.Add(note);
                await db.SaveChanges();
            }
        }

        public async Task DeleteNote(Note note)
        {
            using (var db = await _DbFactory.Create<NotesDb>())
            {
                db.Notes.Remove(note);
                await db.SaveChanges();
            }
        }

        public async Task<Note> GetNote(int id)
        {
            using (var db = await _DbFactory.Create<NotesDb>())
            {
                return db.Notes.SingleOrDefault(n => n.NoteId == id);
            }
        }

        public async Task<List<Note>> GetNotes(NoteType noteType)
        {
            using (var db = await _DbFactory.Create<NotesDb>())
            {
                return db.Notes.Where(n => n.NoteType == noteType).ToList();
            }
        }

        public async Task SaveNote(Note note)
        {
            using (var db = await _DbFactory.Create<NotesDb>())
            {
                if (db.Notes.Any(n => n.NoteId == note.NoteId))
                {
                    db.Notes.Remove(note);
                    await db.SaveChanges();
                }
                db.Notes.Add(note);
                await db.SaveChanges();
            }
        }
    }

    public class NotesDb : IndexedDb
    {
        public NotesDb(IJSRuntime jSRuntime, string name, int version) : base(jSRuntime, name, version) { }
        public IndexedSet<Note> Notes { get; set; }
    }
}