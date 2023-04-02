using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Core.Interfaces
{
    public enum PlatformType
    {
        Unsupported = 0,
        WasmWeb = 1,
        iOS = 2,
        Android = 3,
    }
    public interface IPlatformHelper
    {
        PlatformType PlatformType { get; }
    }
}