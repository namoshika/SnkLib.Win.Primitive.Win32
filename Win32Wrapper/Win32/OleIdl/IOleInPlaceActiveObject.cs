using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SunokoLibrary.Windows.Win32
{
    [ComImport, Guid("00000117-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), System.Security.SuppressUnmanagedCodeSecurity]
    public interface IOleInPlaceActiveObject
    {
        [PreserveSig]
        uint GetWindow(
            [Out, MarshalAs(UnmanagedType.SysUInt)] out IntPtr hwnd);
        void ContextSensitiveHelp(
            [In, MarshalAs(UnmanagedType.SysUInt)] int fEnterMode);
        [PreserveSig]
        uint TranslateAccelerator(
            [In, Out, MarshalAs(UnmanagedType.Struct)] ref System.Windows.Forms.Message lpmsg);
        void OnFrameWindowActivate(
            [In, MarshalAs(UnmanagedType.Bool)] bool fActivate);
        void OnDocWindowActivate(
            [In, MarshalAs(UnmanagedType.I4)] int fActivate);
        void ResizeBorder(
            [In, MarshalAs(UnmanagedType.Struct)] COMRECT prcBorder,
            [In, MarshalAs(UnmanagedType.IUnknown)] IOleInPlaceUIWindow pUIWindow,
            [In, MarshalAs(UnmanagedType.Bool)] bool fFrameWindow);
        void EnableModeless(
            [In, MarshalAs(UnmanagedType.I4)]int fEnable);
    }
}
