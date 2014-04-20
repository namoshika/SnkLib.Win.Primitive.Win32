using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace SunokoLibrary.Windows.Win32
{
    public static class IeFrame
    {
        public static bool IEIsProtectedMode()
        {
            var res = false;
            var code = 0;
            if ((code = IEIsProtectedModeProcess(ref res)) != 0)
                Marshal.ThrowExceptionForHR(code);

            return res;
        }

        [DllImport("ieframe.dll")]
        public static extern int IEIsProtectedModeProcess(ref bool pbResult);

        [DllImport("ieframe.dll", CharSet = CharSet.Unicode, EntryPoint = "IEGetProtectedModeCookie", SetLastError = true)]
        public static extern int IEGetProtectedModeCookie(String url, String cookieName, StringBuilder cookieData, ref int size, int flag);

        public static string GetProtectedModeIECookieValue(string url)
        {
            var cookieStr = new StringBuilder();
            var size = cookieStr.Length;
            var code = 0;

            if ((code = IEGetProtectedModeCookie(url, null, cookieStr, ref size, 0)) != 0)
                Marshal.ThrowExceptionForHR(code);
            cookieStr.Capacity = (int)size;

            if ((code = IEGetProtectedModeCookie(url, null, cookieStr, ref size, 0)) != 0)
                Marshal.ThrowExceptionForHR(code);
            var returnStr = cookieStr.ToString().Replace(";", ",");
            return returnStr;
        }
    }
}
