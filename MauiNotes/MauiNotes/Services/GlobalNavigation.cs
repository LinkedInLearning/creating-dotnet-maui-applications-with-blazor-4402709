using System;
using Notes.Core.Interfaces;
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

        public async Task NavigateBack()
        {
            if (_NativeStack != null && _NativeStack.Count >= 1)
            {
                var currentRoute = _NativeStack.Pop();
                switch (currentRoute.Type)
                {
                    case ApplicationRoute.NavigationType.Native:
                        await GetXamlNavigation().PopAsync();
                        break;
                    case ApplicationRoute.NavigationType.NativeModal:
                        await GetXamlNavigation().PopModalAsync();
                        break;
                }
            }
            else
            {
                await _JsRuntime.InvokeVoidAsync("goBack");
            }

        }

        public async Task NavigateTo(string uri)
        {
            var oRoute = _ApplicationRoutes.SingleOrDefault(r => r.Uri == uri);
            if (oRoute != null)
            {
                switch (oRoute.Type)
                {
                    case ApplicationRoute.NavigationType.Native:

                        await GetXamlNavigation().PushAsync((Page)_ServiceProvider.GetService(oRoute.NativeType));
                        _NativeStack.Push(oRoute);
                        break;
                    case ApplicationRoute.NavigationType.NativeModal:
                        await GetXamlNavigation().PushModalAsync((Page)_ServiceProvider.GetService(oRoute.NativeType));
                        _NativeStack.Push(oRoute);
                        break;
                }
            }
            else
            {
                if (_NativeStack.Count > 0) 
                {
                    throw new InvalidNavigationException("Blazor navigation cannot be called from within xaml navigation");
                }
                _NavigationManager.NavigateTo(uri);
            }
        }

        private INavigation GetXamlNavigation()
        {
            return App.Current.MainPage.Navigation;
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
