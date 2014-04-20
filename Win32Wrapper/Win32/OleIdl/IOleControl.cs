using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SunokoLibrary.Windows.Win32
{
    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("B196B288-BAB4-101A-B69C-00AA00341D07")]
    public interface IOleControl
    {
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Error)]
        uint GetControlInfo([In, Out] ref tagCONTROLINFO pCI);
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Error)]
        uint OnMnemonic([In]System.Windows.Forms.Message pMsg);
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Error)]
        uint OnAmbientPropertyChange([In]int dispID);
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Error)]
        uint FreezeEvents([In, MarshalAs(UnmanagedType.Bool)] bool bFreeze);
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct tagCONTROLINFO
    {
        [MarshalAs(UnmanagedType.U8)]
        ulong cb;
        [MarshalAs(UnmanagedType.Struct)]
        tagACCEL hAccel;
        [MarshalAs(UnmanagedType.U2)]
        uint cAccel;
        [MarshalAs(UnmanagedType.U4)]
        uint dwFlags;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct tagACCEL
    {
        byte fVirt;
        [MarshalAs(UnmanagedType.U2)]
        uint key;
        [MarshalAs(UnmanagedType.U2)]
        uint cmd;
    }
}
