using Notes.Core.Interfaces;

namespace WasmNotes.Services
{
    public class PlatformHelper : IPlatformHelper
    {
        public PlatformType PlatformType
        {
            get
            {
                return PlatformType.WasmWeb;
            }
        }
    }
}
