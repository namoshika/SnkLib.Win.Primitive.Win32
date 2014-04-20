using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace SunokoLibrary.Windows.Win32
{
    public static class Wininet
    {
        public static string GetIECookieHeader(string url)
        {
            var cookieStr = new StringBuilder();
            uint size = (uint)cookieStr.Length;

            InternetGetCookie(url, null, cookieStr, ref size);
            cookieStr.Capacity = (int)size;

            InternetGetCookie(url, null, cookieStr, ref size);
            var returnStr = cookieStr.ToString().Replace(";", ",");
            return returnStr;
        }
        public static string GetInternetOptionProxy(IntPtr hInternet)
        {
            var length = (uint)0;
            var ipiPtr = IntPtr.Zero;
            InternetQueryOption(hInternet, (uint)InternetOption.INTERNET_OPTION_PROXY, ipiPtr, ref length);
            try
            {
                ipiPtr = Marshal.AllocHGlobal((int)length);
                InternetQueryOption(hInternet, (uint)InternetOption.INTERNET_OPTION_PROXY, ipiPtr, ref length);
                var ipi = (Wininet.InternetProxyInfo)Marshal.PtrToStructure(ipiPtr, typeof(Wininet.InternetProxyInfo));
                switch (ipi.dwAccessType)
                {
                    case InternetOpenType.INTERNET_OPEN_TYPE_DIRECT:
                        return Urlmon.ProxyUrl_Direct;
                    case InternetOpenType.INTERNET_OPEN_TYPE_PROXY:
                        return ipi.lpszProxy;
                    case InternetOpenType.INTERNET_OPEN_TYPE_PRECONFIG:
                        return Urlmon.ProxyUrl_InternetOptionProxy;
                    default:
                        throw new Exception("変な値が返された。");
                }
            }
            finally
            {
                Marshal.FreeCoTaskMem(ipiPtr);
            }
        }
        public static string GetInternetOptionProxy()
        {
            return GetInternetOptionProxy(IntPtr.Zero);
        }

        [System.Runtime.InteropServices.DllImport("wininet.dll")]
        public extern static bool InternetGetCookie(string lpszUrl, string lpszCookieName, StringBuilder lpCookieData, ref uint lpdwSize);
        [System.Runtime.InteropServices.DllImport("wininet.dll")]
        public extern static bool InternetSetCookie(string lpszUrl, string lpszCookieName, string lpszCookieData);
        [System.Runtime.InteropServices.DllImport("wininet.dll")]
        public extern static bool InternetQueryOption(IntPtr hInternet, uint dwOption, IntPtr lpBuffer, ref uint lpdwBufferLength);

        [StructLayout(LayoutKind.Sequential)]
        public struct InternetProxyInfo
        {
            public InternetOpenType dwAccessType;
            public string lpszProxy;
            public string lpszProxyBypass;
        }
        public enum InternetOption
        {
            INTERNET_OPTION_REFRESH = 37,
            INTERNET_OPTION_PROXY = 38,
        }
        public enum InternetOpenType
        {
            INTERNET_OPEN_TYPE_PRECONFIG = 0,// use registry configuration
            INTERNET_OPEN_TYPE_DIRECT = 1,// direct to net
            INTERNET_OPEN_TYPE_PROXY = 3,// via named proxy
            INTERNET_OPEN_TYPE_PRECONFIG_WITH_NO_AUTOPROXY = 4,// prevent using java/script/INS
        }
    }
}
