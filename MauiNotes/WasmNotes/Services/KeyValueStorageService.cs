using Blazored.LocalStorage;
using Notes.Core.Interfaces;

namespace WasmNotes.Services
{
    public class KeyValueStorageService : IKeyValueStorageService
    {
        private readonly ILocalStorageService _localStore;

        public KeyValueStorageService(ILocalStorageService localStorageService)
        {
            _localStore = localStorageService;
        }
        public async Task<T> GetValue<T>(string key)
        {
            return await _localStore.GetItemAsync<T>(key);
        }

        public async Task RemoveValue(string key)
        {
            await _localStore.RemoveItemAsync(key);
        }

        public async Task<bool> SetValue<T>(string key, T value)
        {
            try
            {
                await _localStore.SetItemAsync<T>(key, value);
                return true;
            }
            catch (Exception) { return false; }
        }
    }
}
