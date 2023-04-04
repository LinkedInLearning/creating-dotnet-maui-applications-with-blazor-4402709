using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Core.Models
{
    public class Note
    {
        [PrimaryKey]
        [AutoIncrement]
        public int NoteId { get; set; }

        public string NoteText { get; set; }

        public NoteType NoteType { get; set; }
    }

    public enum NoteType
    {
        Personal = 0,
        Business = 1,
    }
}