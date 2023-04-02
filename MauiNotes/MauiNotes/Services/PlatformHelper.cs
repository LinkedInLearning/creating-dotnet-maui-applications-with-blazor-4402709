using Notes.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiNotes.Services
{
    public class PlatformHelper : IPlatformHelper
    {
        public PlatformType PlatformType
        {
            get
            {
#if ANDROID
                return PlatformType.Android;
#elif IOS
                return PlatformType.iOS;
#else
                return PlatformType.Unsupported;
#endif
            }
        }
    }
}
