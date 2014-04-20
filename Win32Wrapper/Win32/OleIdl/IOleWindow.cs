using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SunokoLibrary.Windows.Win32
{
    [Guid("00000114-0000-0000-C000-000000000046")]
    public interface IOleWindow
    {
        uint GetWindow(
            [Out, MarshalAs(UnmanagedType.SysUInt)] out IntPtr phwnd);
        uint ContextSensitiveHelp( 
            [In, MarshalAs(UnmanagedType.Bool)] bool fEnterMode);
    };
}
