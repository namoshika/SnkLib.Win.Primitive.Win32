﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SunokoLibrary.Windows.Win32
{
    public enum NWMF
    {
        NWMF_UNLOADING = 0x00000001,
        NWMF_USERINITED = 0x00000002,
        NWMF_FIRST = 0x00000004,
        NWMF_OVERRIDEKEY = 0x00000008,
        NWMF_SHOWHELP = 0x00000010,
        NWMF_HTMLDIALOG = 0x00000020,
        NWMF_FROMDIALOGCHILD = 0x00000040,
        NWMF_USERREQUESTED = 0x00000080,
        NWMF_USERALLOWED = 0x00000100,
        NWMF_FORCEWINDOW = 0x00010000,
        NWMF_FORCETAB = 0x00020000,
        NWMF_SUGGESTWINDOW = 0x00040000,
        NWMF_SUGGESTTAB = 0x00080000,
        NWMF_INACTIVETAB = 0x00100000
    }
}