using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Core.Interfaces
{
    public interface INoteReader
    {
        Task ReadNote(string textToRead);
    }
}