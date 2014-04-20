using System;
using System.Collections.Generic;
using System.Text;

namespace SunokoLibrary.Windows.Win32
{
    public enum RefreshConstants
    {
        /// <summary>Refresh without sending a "Pragma:no-cache" HTTP header to the server.</summary>
        REFRESH_NORMAL = 0,
        /// <summary>Not implemented.</summary>
        REFRESH_IFEXPIRED = 1,
        /// <summary>
        /// Refresh without forced cache validation by sending a "Pragma:no-cache" 
        /// header to the server (HTTP URLs only). Same as pressing Ctrl+F5 in Windows Internet Explorer.
        /// </summary>
        REFRESH_COMPLETELY = 3
    }
}
