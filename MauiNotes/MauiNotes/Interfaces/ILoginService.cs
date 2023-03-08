using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiNotes.Interfaces
{
    public interface ILoginService
    {
        bool IsAuthenticated { get; }

        bool Login(string username, string password);
    }
}
