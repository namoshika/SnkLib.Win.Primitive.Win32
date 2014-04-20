using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SunokoLibrary.Windows.Win32
{
    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("00000115-0000-0000-C000-000000000046")]
    public interface IOleInPlaceUIWindow : IOleWindow
    {
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Error)]
        uint GetBorder(
           [Out, MarshalAs(UnmanagedType.Struct)] COMRECT lprectBorder);
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Error)]
        uint RequestBorderSpace(
           [In, MarshalAs(UnmanagedType.Struct)] COMRECT pborderwidths);
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Error)]
        uint SetBorderSpace(
           [In, MarshalAs(UnmanagedType.Struct)] COMRECT pborderwidths);
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Error)]
        uint SetActiveObject(
           [In, MarshalAs(UnmanagedType.IUnknown)] IOleInPlaceActiveObject pActiveObject,
           [In, MarshalAs(UnmanagedType.LPStr)]string pszObjName);
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct COMRECT
    {
        public COMRECT(int left, int top, int right, int bottom)
        {
            this.left = left;
            this.top = top;
            this.right = right;
            this.bottom = bottom;
        }

        public int left;
        public int top;
        public int right;
        public int bottom;

        public static COMRECT FromXYWH(int x, int y, int width, int height)
        {
            return new COMRECT(x, y, x + width, y + height);
        }
        public override string ToString()
        {
            return String.Format("X={0},Y={1},W={2},H={3}", this.left, this.top, this.right - this.left, this.bottom - this.top);
        }
    }
}
