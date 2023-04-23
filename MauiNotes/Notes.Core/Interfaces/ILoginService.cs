using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Core.Interfaces
{
    public interface ILoginService
    {
        Task<bool> IsAuthenticated();

        Task<bool> Login(string username, string password);

        string CurrentToken();
    }
}