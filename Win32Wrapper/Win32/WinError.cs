using System;
using System.Collections.Generic;
using System.Text;

namespace SunokoLibrary.Windows.Win32
{
    public class WinError
    {
        public const uint S_OK = 0;
        public const uint S_FALSE = 1;
        public const uint E_NOTIMPL = 0x80004001;
        public const uint E_NOINTERFACE = 0x80004002;
        public const uint E_FAIL = 0x80004005;
    }
}
