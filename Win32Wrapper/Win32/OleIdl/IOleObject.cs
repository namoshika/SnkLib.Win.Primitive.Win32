using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace SunokoLibrary.Windows.Win32
{
    [ComImport, Guid("00000112-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleObject
    {
        void SetClientSite(
            [In, MarshalAs(UnmanagedType.Interface)] IOleClientSite pClientSite);
        void GetClientSite(
            [Out, MarshalAs(UnmanagedType.Interface)]out IOleClientSite ppClientSite);
        void SetHostNames(
           [In, MarshalAs(UnmanagedType.LPWStr)] string szContainerApp,
           [In, MarshalAs(UnmanagedType.LPWStr)] string szContainerObj);
        void Close(
           [In, MarshalAs(UnmanagedType.U4)] uint dwSaveOption);
        void SetMoniker(
           [In, MarshalAs(UnmanagedType.U4)] uint dwWhichMoniker,
           [In, MarshalAs(UnmanagedType.Interface)] IMoniker pmk);
        void GetMoniker(
           [In, MarshalAs(UnmanagedType.U4)] uint dwAssign,
           [In, MarshalAs(UnmanagedType.U4)] uint dwWhichMoniker,
           [Out, MarshalAs(UnmanagedType.Interface)] out IMoniker ppmk);
        void InitFromData(
           [In, MarshalAs(UnmanagedType.Interface)] IDataObject pDataObject,
           [In, MarshalAs(UnmanagedType.Bool)] bool fCreation,
           [In, MarshalAs(UnmanagedType.U4)] uint dwReserved);
        void GetClipboardData(
           [In, MarshalAs(UnmanagedType.U4)] uint dwReserved,
           [Out, MarshalAs(UnmanagedType.Interface)]out IDataObject ppDataObject);
        void DoVerb(
           [In, MarshalAs(UnmanagedType.U8)] long iVerb,
           [In, MarshalAs(UnmanagedType.SysUInt)] IntPtr lpmsg,
           [In, MarshalAs(UnmanagedType.Interface)] IOleClientSite pActiveSite,
           [In, MarshalAs(UnmanagedType.U8)] long lindex,
           [In, MarshalAs(UnmanagedType.SysUInt)] IntPtr hwndParent,
           [In, MarshalAs(UnmanagedType.SysUInt)] IntPtr lprcPosRect);
        void EnumVerbs(
            [Out, MarshalAs(UnmanagedType.IUnknown)] out object ppEnumOleVerb);
        void Update();
        void IsUpToDate();
        void GetUserClassID(
           [Out, MarshalAs(UnmanagedType.Struct)] out Guid pClsid);
        void GetUserType(
           [In, MarshalAs(UnmanagedType.U4)] uint dwFormOfType,
           [Out, MarshalAs(UnmanagedType.LPWStr)] out string pszUserType);
        void SetExtent(
           [In, MarshalAs(UnmanagedType.U4)] uint dwDrawAspect,
           [In, MarshalAs(UnmanagedType.LPStruct)] object psizel);
        void GetExtent(
           [In, MarshalAs(UnmanagedType.U4)] uint dwDrawAspect,
           [Out, MarshalAs(UnmanagedType.LPStruct)] out uint psizel);
        void Advise(
           [In, MarshalAs(UnmanagedType.Interface)]  IAdviseSink pAdvSink,
           [Out, MarshalAs(UnmanagedType.U4)] out uint pdwConnection);
        void Unadvise(
           [In, MarshalAs(UnmanagedType.U4)] uint dwConnection);
        void EnumAdvise(
           [Out, MarshalAs(UnmanagedType.Interface)] out IEnumSTATDATA ppenumAdvise);
        void GetMiscStatus(
           [In, MarshalAs(UnmanagedType.U4)] uint dwAspect,
           [Out, MarshalAs(UnmanagedType.U4)] out uint pdwStatus);
        void SetColorScheme(
           [In, MarshalAs(UnmanagedType.Struct)] object pLogpal);
    }
}
