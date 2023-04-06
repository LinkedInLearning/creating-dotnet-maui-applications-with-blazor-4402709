using Notes.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Core.Interfaces
{
    public interface INotesService
    {
        Task<List<Note>> GetNotes(NoteType noteType);

        Task DeleteNote(Note note);

        Task AddNote(Note note);

        Task<Note> GetNote(int id);

        Task SaveNote(Note note);
    }
}