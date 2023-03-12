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
        List<Note> GetNotes(NoteType noteType);

        void DeleteNote(Note note);

        void AddNote(Note note);

        Note GetNote(int id);
    }
}
