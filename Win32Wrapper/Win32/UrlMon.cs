using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace SunokoLibrary.Windows.Win32
{
    public class Urlmon
    {
        public const string ProxyUrl_InternetOptionProxy = "INTERNET_OPEN_TYPE_PRECONFIG";
        public const string ProxyUrl_Direct = "INTERNET_OPEN_TYPE_DIRECT";

        public static string ProxyUrl
        {
            get { return Wininet.GetInternetOptionProxy(); }
            set
            {
                var ipi = new Wininet.InternetProxyInfo();
                var ipiPtr = IntPtr.Zero;
                switch (value)
                {
                    case null:
                    case ProxyUrl_InternetOptionProxy:
                        ipi.dwAccessType = Wininet.InternetOpenType.INTERNET_OPEN_TYPE_PRECONFIG;
                        break;
                    case ProxyUrl_Direct:
                        ipi.dwAccessType = Wininet.InternetOpenType.INTERNET_OPEN_TYPE_DIRECT;
                        break;
                    default:
                        ipi.dwAccessType = Wininet.InternetOpenType.INTERNET_OPEN_TYPE_PROXY;
                        break;
                }
                try
                {
                    ipi.lpszProxy = value;
                    var ipiSz = Marshal.SizeOf(ipi);
                    ipiPtr = Marshal.AllocHGlobal(ipiSz);
                    Marshal.StructureToPtr(ipi, ipiPtr, true);
                    UrlMkSetSessionOption((uint)Wininet.InternetOption.INTERNET_OPTION_PROXY, ipiPtr, (uint)ipiSz, 0);
                }
                finally
                {
                    //解放処理
                    Marshal.FreeHGlobal(ipiPtr);
                }
            }
        }
        public static string UserAgent
        {
            get
            {
                var valSz = (uint)0;
                IntPtr valPtr = IntPtr.Zero;
                try
                {
                    UrlMkGetSessionOption((uint)UrlmonOption.URLMON_OPTION_USERAGENT, valPtr, valSz, out valSz, 0);
                    valPtr = Marshal.AllocHGlobal((int)valSz);
                    UrlMkGetSessionOption((uint)UrlmonOption.URLMON_OPTION_USERAGENT, valPtr, valSz, out valSz, 0);
                    var val = Marshal.PtrToStringAnsi(valPtr);
                    return val;
                }
                finally
                {
                    Marshal.FreeHGlobal(valPtr);
                }
            }
            set
            {
                IntPtr valPtr = IntPtr.Zero;
                try
                {
                    var valSz = (uint)System.Text.ASCIIEncoding.ASCII.GetByteCount(value);
                    valPtr = Marshal.StringToHGlobalAnsi(value);
                    UrlMkSetSessionOption((uint)UrlmonOption.URLMON_OPTION_USERAGENT, valPtr, valSz, 0);
                }
                finally
                {
                    Marshal.FreeHGlobal(valPtr);
                }
            }
        }

        [DllImport("urlmon.dll", CharSet = CharSet.Ansi)]
        public static extern void UrlMkSetSessionOption(
            [In, MarshalAs(UnmanagedType.U4)] uint dwOption,
            [In, MarshalAs(UnmanagedType.SysInt)] IntPtr pBuffer,
            [In, MarshalAs(UnmanagedType.U4)] uint dwBufferLength,
            [In, MarshalAs(UnmanagedType.U4)] uint dwReserved);
        [DllImport("urlmon.dll", CharSet = CharSet.Ansi)]
        public static extern void UrlMkGetSessionOption(
            [In, MarshalAs(UnmanagedType.U4)] uint dwOption,
            [In, MarshalAs(UnmanagedType.SysInt)] IntPtr pBuffer,
            [In, MarshalAs(UnmanagedType.U4)] uint dwBufferLength,
            [Out, MarshalAs(UnmanagedType.U4)]out uint pdwBufferLengthOut,
            [In, MarshalAs(UnmanagedType.U4)] uint dwReserved);

        public enum UrlmonOption
        {
            URLMON_OPTION_USERAGENT = 0x10000001,
            URLMON_OPTION_USERAGENT_REFRESH = 0x10000002,
            URLMON_OPTION_URL_ENCODING = 0x10000004,
        }
    }

}