using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace SunokoLibrary.Windows.Win32
{
    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("00000118-0000-0000-C000-000000000046")]
    public interface IOleClientSite
    {
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Error)]
        uint SaveObject();
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Error)]
        uint GetMoniker(
            [In, MarshalAs(UnmanagedType.U4)]uint dwAssign,
            [In, MarshalAs(UnmanagedType.U4)] uint dwWhichMoniker,
            [Out, MarshalAs(UnmanagedType.Interface)] out IMoniker ppmk);
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Error)]
        uint GetContainer(
            [Out, MarshalAs(UnmanagedType.Interface)] out object ppContainer);
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Error)]
        uint ShowObject();
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Error)]
        uint OnShowWindow(
            [In, MarshalAs(UnmanagedType.Bool)] bool fShow);
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Error)]
        uint RequestNewObjectLayout();
    }
}
