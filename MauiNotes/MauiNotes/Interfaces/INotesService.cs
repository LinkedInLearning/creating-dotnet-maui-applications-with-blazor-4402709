using MauiNotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiNotes.Interfaces
{
    public interface INotesService
    {
        Task<List<Note>> GetNotes(NoteType noteType);

        Task DeleteNote(Note note);

        Task AddNote(Note note);

        Task<Note> GetNote(int id);
    }
}