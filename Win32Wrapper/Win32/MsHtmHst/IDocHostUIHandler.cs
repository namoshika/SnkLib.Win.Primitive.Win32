using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace SunokoLibrary.Windows.Win32
{
    using System.Runtime.InteropServices.ComTypes;

    [ComImport()]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GuidAttribute("bd3f23c0-d43e-11cf-893b-00aa00bdce1a")]
    public interface IDocHostUIHandler
    {
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Error)]
        uint ShowContextMenu(
            [In, MarshalAs(UnmanagedType.U4)] ContextMenu dwID,
            [In, MarshalAs(UnmanagedType.Struct)]ref TagPoint ppt,
            [In, MarshalAs(UnmanagedType.IUnknown)] object pcmdtReserved,
            [In, MarshalAs(UnmanagedType.IDispatch)] object pdispReserved);
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Error)]
        uint GetHostInfo(
            [In, Out, MarshalAs(UnmanagedType.Struct)] ref DocHostUiInfo pInfo);
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Error)]
        uint ShowUI(
            [In, MarshalAs(UnmanagedType.U4)]DocHostUiType dwID,
            [In, MarshalAs(UnmanagedType.Interface)]object pActiveObject,
            [In, MarshalAs(UnmanagedType.Interface)]object pCommandTarget,
            [In, MarshalAs(UnmanagedType.Interface)]object pFrame,
            [In, MarshalAs(UnmanagedType.Interface)]object pDoc);
        void HideUI();
        void UpdateUI();
        void EnableModeless(
            [In, MarshalAs(UnmanagedType.Bool)]bool fEnable);
        void OnDocWindowActivate(
            [In, MarshalAs(UnmanagedType.Bool)]bool fActivate);
        void OnFrameWindowActivate(
            [In, MarshalAs(UnmanagedType.Bool)]bool fActivate);
        void ResizeBorder(
            [In, MarshalAs(UnmanagedType.Struct)]ref TagRect prcBorder,
            [In, MarshalAs(UnmanagedType.SysUInt)]IntPtr pUIWindow,
            [In, MarshalAs(UnmanagedType.Bool)]bool fFrameWindow);
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Error)]
        uint TranslateAccelerator(
            [In, MarshalAs(UnmanagedType.Struct)]ref TagMsg lpMsg,
            [In, MarshalAs(UnmanagedType.Struct)]ref Guid pguidCmdGroup,
            [In, MarshalAs(UnmanagedType.U4)] uint nCmdID);
        void GetOptionKeyPath(
            [In, Out, MarshalAs(UnmanagedType.BStr)] ref string pchKey,
            [In, MarshalAs(UnmanagedType.U4)] uint dw);
        void GetDropTarget(
            [In, MarshalAs(UnmanagedType.Interface)] object pDropTarget,
            [Out, MarshalAs(UnmanagedType.Interface)] out object ppDropTarget);
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Error)]
        uint GetExternal(
            [Out, MarshalAs(UnmanagedType.IDispatch)] out object ppDispatch);
        void TranslateUrl(
            [In, MarshalAs(UnmanagedType.U4)] uint dwTranslate,
            [In, MarshalAs(UnmanagedType.BStr)] string pchURLIn,
            [Out, MarshalAs(UnmanagedType.BStr)] out string ppchURLOut);
        void FilterDataObject(
            [In]IDataObject pDO,
            [Out]out IDataObject ppDORet);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TagMsg
    {
        public IntPtr hwnd;
        public uint message;
        public uint wParam;
        public int lParam;
        public uint time;
        public TagPoint pt;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct DocHostUiInfo
    {
        [MarshalAs(UnmanagedType.U4)]
        public uint cbSize;
        [MarshalAs(UnmanagedType.U4)]
        public DocHostUiFlag dwFlags;
        [MarshalAs(UnmanagedType.U4)]
        public DocHostUiDoubleClick dwDoubleClick;
        [MarshalAs(UnmanagedType.SysInt)]
        public IntPtr pchHostCss;
        [MarshalAs(UnmanagedType.SysInt)]
        public IntPtr pchHostNS;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct TagPoint
    {
        public TagPoint(int x, int y) { this.x = x; this.y = y; }
        public int x;
        public int y;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct TagRect
    {
        long left;
        long top;
        long right;
        long bottom;
    }
    [Flags()]
    public enum DocHostUiFlag : uint
    {
        DOCHOSTUIFLAG_DIALOG = 0x00000001,
        DOCHOSTUIFLAG_DISABLE_HELP_MENU = 0x00000002,
        DOCHOSTUIFLAG_NO3DBORDER = 0x00000004,
        DOCHOSTUIFLAG_SCROLL_NO = 0x00000008,
        DOCHOSTUIFLAG_DISABLE_SCRIPT_INACTIVE = 0x00000010,
        DOCHOSTUIFLAG_OPENNEWWIN = 0x00000020,
        DOCHOSTUIFLAG_DISABLE_OFFSCREEN = 0x00000040,
        DOCHOSTUIFLAG_FLAT_SCROLLBAR = 0x00000080,
        DOCHOSTUIFLAG_DIV_BLOCKDEFAULT = 0x00000100,
        DOCHOSTUIFLAG_ACTIVATE_CLIENTHIT_ONLY = 0x00000200,
        DOCHOSTUIFLAG_OVERRIDEBEHAVIORFACTORY = 0x00000400,
        DOCHOSTUIFLAG_CODEPAGELINKEDFONTS = 0x00000800,
        DOCHOSTUIFLAG_URL_ENCODING_DISABLE_UTF8 = 0x00001000,
        DOCHOSTUIFLAG_URL_ENCODING_ENABLE_UTF8 = 0x00002000,
        DOCHOSTUIFLAG_ENABLE_FORMS_AUTOCOMPLETE = 0x00004000,
        DOCHOSTUIFLAG_ENABLE_INPLACE_NAVIGATION = 0x00010000,
        DOCHOSTUIFLAG_IME_ENABLE_RECONVERSION = 0x00020000,
        DOCHOSTUIFLAG_THEME = 0x00040000,
        DOCHOSTUIFLAG_NOTHEME = 0x00080000,
        DOCHOSTUIFLAG_NOPICS = 0x00100000,
        DOCHOSTUIFLAG_NO3DOUTERBORDER = 0x00200000,
        DOCHOSTUIFLAG_DISABLE_EDIT_NS_FIXUP = 0x400000,
        DOCHOSTUIFLAG_LOCAL_MACHINE_ACCESS_CHECK = 0x800000,
        DOCHOSTUIFLAG_DISABLE_UNTRUSTEDPROTOCOL = 0x1000000
    }
    public enum DocHostUiType : uint
    {
        DOCHOSTUITYPE_BROWSE = 0,
        DOCHOSTUITYPE_AUTHOR = 1
    }
    public enum DocHostUiDoubleClick : uint
    {
        DOCHOSTUIDBLCLK_DEFAULT = 0,
        DOCHOSTUIDBLCLK_SHOWPROPERTIES = 1,
        DOCHOSTUIDBLCLK_SHOWCODE = 2
    }
    public enum ContextMenu : uint
    {
        CONTEXT_MENU_DEFAULT = 0,
        CONTEXT_MENU_IMAGE = 1,
        CONTEXT_MENU_CONTROL = 2,
        CONTEXT_MENU_TABLE = 3,
        // in browse mode
        CONTEXT_MENU_TEXTSELECT = 4,
        CONTEXT_MENU_ANCHOR = 5,
        CONTEXT_MENU_UNKNOWN = 6,
        //;begin_internal
        // These 2 are mapped to IMAGE for the public
        CONTEXT_MENU_IMGDYNSRC = 7,
        CONTEXT_MENU_IMGART = 8,
        CONTEXT_MENU_DEBUG = 9,
        //;end_internal
        CONTEXT_MENU_VSCROLL = 10,
        CONTEXT_MENU_HSCROLL = 11,
    }
}
