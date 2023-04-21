using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Core.Interfaces
{
    public interface IKeyValueStorageService
    {
        Task<bool> SetValue<T>(string key, T value);

        Task<T> GetValue<T>(string key);

        Task RemoveValue(string key);
    }
}
