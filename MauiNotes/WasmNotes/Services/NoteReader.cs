using Microsoft.JSInterop;
using Notes.Core.Interfaces;

namespace WasmNotes.Services
{
    public class NoteReader : INoteReader
    {
        private IJSRuntime _JsRuntime;

        public NoteReader(IJSRuntime jsRuntime) 
        {
            _JsRuntime = jsRuntime;
        }
        
        public async Task ReadNote(string textToRead)
        {
            await _JsRuntime.InvokeVoidAsync("readText");
        }
    }
}
