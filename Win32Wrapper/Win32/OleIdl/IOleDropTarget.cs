using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SunokoLibrary.Windows.Win32
{
    [ComImport, Guid("00000122-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleDropTarget
    {
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Error)]
        uint OleDragEnter(
            [In, MarshalAs(UnmanagedType.IUnknown)] object pDataObj,
            [In, MarshalAs(UnmanagedType.U4)] uint grfKeyState,
            [In, MarshalAs(UnmanagedType.U8)] ulong pt,
            [In, Out, MarshalAs(UnmanagedType.U4)] ref uint pdwEffect);
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Error)]
        uint OleDragOver(
            [In, MarshalAs(UnmanagedType.U4)] uint grfKeyState,
            [In, MarshalAs(UnmanagedType.U8)] ulong pt,
            [In, Out, MarshalAs(UnmanagedType.U4)] ref uint pdwEffect);
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Error)]
        uint OleDragLeave();
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Error)]
        uint OleDrop(
            [In, MarshalAs(UnmanagedType.IUnknown)] object pDataObj,
            [In, MarshalAs(UnmanagedType.U4)] uint grfKeyState,
            [In, MarshalAs(UnmanagedType.U8)] ulong pt,
            [In, Out, MarshalAs(UnmanagedType.U4)] ref uint pdwEffect);
    }
}
