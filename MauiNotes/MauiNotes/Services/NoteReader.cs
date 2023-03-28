using Notes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiNotes.Services
{
    public class NoteReader : INoteReader
    {
        public async Task ReadNote(string textToRead)
        {
            IEnumerable<Locale> locales = await TextToSpeech.Default.GetLocalesAsync();
            SpeechOptions options = new SpeechOptions()
            {
                Pitch = 1.0f,
                Volume = 0.75f,
                Locale = locales.FirstOrDefault(l => l.Language == "en")
            };
            await TextToSpeech.Default.SpeakAsync(textToRead, options);
        }
    }
}