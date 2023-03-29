using System;
using Notes.Core.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WasmNotes.Services
{
    public class GlobalNavigation : IGlobalNavigation
    {
        private NavigationManager _NavigationManager;
        private IJSRuntime _JsRuntime;

        public GlobalNavigation(NavigationManager navigationManager, IJSRuntime jsRuntime)
        {
            _NavigationManager = navigationManager;
            _JsRuntime = jsRuntime;
        }

        public async Task NavigateBack()
        {
            await _JsRuntime.InvokeVoidAsync("goBack");
        }

        public Task NavigateTo(string uri)
        {
            _NavigationManager.NavigateTo(uri);
            return Task.CompletedTask;
        }
    }
}
