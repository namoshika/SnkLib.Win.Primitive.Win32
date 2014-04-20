using System;
using System.Collections.Generic;
using System.Text;

namespace SunokoLibrary.Windows.Win32
{
    public enum CommandStateChangeConstants : uint
    {
        CSC_UPDATECOMMANDS = 0xFFFFFFFF,
        CSC_NAVIGATEFORWARD = 0x1,
        CSC_NAVIGATEBACK = 0x2
    }
}
