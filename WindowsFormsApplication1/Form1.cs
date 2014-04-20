using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    using SunokoLibrary.Windows.Win32;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var aa = IeFrame.GetProtectedModeIECookieValue("plus.google.com");

            //SunokoLibrary.Win32.Urlmon.ProxyUrl = "localhost:8080";
            ////SunokoLibrary.Win32.Urlmon.UserAgent = "HogeBrowser";
            //webBrowser1.Navigate("http://www.google.co.jp");
            ////MessageBox.Show(SunokoLibrary.Win32.Wininet.GetInternetOptionProxy());
            //MessageBox.Show(SunokoLibrary.Win32.Urlmon.ProxyUrl);
            ////MessageBox.Show(SunokoLibrary.Win32.Urlmon.UserAgent);
        }
    }
}
