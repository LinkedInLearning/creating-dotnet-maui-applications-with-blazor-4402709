using MauiNotes.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiNotes.Services
{
    public class GlobalNavigation : IGlobalNavigation
    {
        private NavigationManager _NavigationManager;
        private List<ApplicationRoute> _ApplicationRoutes;
        private static Stack<ApplicationRoute> _NativeStack = new Stack<ApplicationRoute>();
        private IServiceProvider _ServiceProvider;
        private IJSRuntime _JsRuntime;

        public GlobalNavigation(NavigationManager navigationManager, IServiceProvider serviceProvider, IJSRuntime jsRuntime, List<ApplicationRoute> applicationRoutes)
        {
            _NavigationManager = navigationManager;
            _ServiceProvider = serviceProvider;
            _ApplicationRoutes = applicationRoutes;
            _JsRuntime = jsRuntime;
        }

        public Task NavigateBack()
        {
            throw new NotImplementedException();
        }

        public Task NavigateTo(string url)
        {
            throw new NotImplementedException();
        }

        public class ApplicationRoute
        {
            public string Uri { get; set; }
            public NavigationType Type { get; set; }
            public enum NavigationType
            {
                Native,
                NativeModal
            }

            public Type NativeType { get; set; }

        }
    }
}
