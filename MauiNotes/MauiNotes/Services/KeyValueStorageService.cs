using Newtonsoft.Json;
using Notes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiNotes.Services
{
    public class KeyValueStorageService : IKeyValueStorageService
    {
        public async Task<T> GetValue<T>(string key)
        {
            T returnValue = default(T);

            string serialzedValue = await SecureStorage.Default.GetAsync(key);

            if (serialzedValue != null)
            {
                returnValue = JsonConvert.DeserializeObject<T>(serialzedValue);
            }

            return returnValue;
        }

        public Task RemoveValue(string key)
        {
            SecureStorage.Default.Remove(key);
            return Task.CompletedTask;
        }

        public async Task<bool> SetValue<T>(string key, T value)
        {
            try
            {
                string serializedObject = JsonConvert.SerializeObject(value);
                await SecureStorage.Default.SetAsync(key, serializedObject);
                return true;
            }
            catch (Exception) 
            {
                return false;
            }
        }
    }
}
