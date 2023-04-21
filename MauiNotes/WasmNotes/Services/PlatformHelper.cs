using Microsoft.JSInterop;
using Notes.Core.Interfaces;

namespace WasmNotes.Services
{
    public class PlatformHelper : IPlatformHelper
    {
        private IJSRuntime _JsRuntime;

        public PlatformHelper(IJSRuntime jsRuntime)
        {
            _JsRuntime = jsRuntime;
        }

        public PlatformType PlatformType
        {
            get
            {
                return PlatformType.WasmWeb;
            }
        }

        public async Task<bool> IsOnline()
        {
            return await _JsRuntime.InvokeAsync<bool>("isOnline");
        }
    }
}
