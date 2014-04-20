using System;
using System.Collections.Generic;
using System.Text;

namespace SunokoLibrary.Windows.Win32
{
    public enum BrowserNavConstants
    {
        /// <summary>Open the resource or file in a new window.</summary>
        navOpenInNewWindow = 0x1,
        /// <summary>Do not add the resource or file to the history list. The new page replaces the current page in the list.</summary>
        navNoHistory = 0x2,
        /// <summary>Not implemented.</summary>
        navNoReadFromCache = 0x4,
        /// <summary>Not implemented.</summary>
        navNoWriteToCache = 0x8,
        /// <summary>If the navigation fails, the autosearch functionality attempts to navigate common root domains (.com, .edu, and so on). If this also fails, the URL is passed to a search engine.</summary>
        navAllowAutosearch = 0x10,
        /// <summary>Causes the current Explorer Bar to navigate to the given item, if possible.</summary>
        navBrowserBar = 0x20,
        /// <summary>Microsoft Internet Explorer 6 for Windows XP Service Pack 2 (SP2) and later. If the navigation fails when a hyperlink is being followed, this constant specifies that the resource should then be bound to the moniker using the BINDF_HYPERLINK flag.</summary>
        navHyperlink = 0x40,
        /// <summary>Internet Explorer 6 for Windows XP SP2 and later. Force the URL into the restricted zone.</summary>
        navEnforceRestricted = 0x80,
        /// <summary>Internet Explorer 6 for Windows XP SP2 and later. Use the default Popup Manager to block pop-up windows.</summary>
        navNewWindowsManaged = 0x0100,
        /// <summary>Internet Explorer 6 for Windows XP SP2 and later. Block files that normally trigger a file download dialog box.</summary>
        navUntrustedForDownload = 0x0200,
        /// <summary>Internet Explorer 6 for Windows XP SP2 and later. Prompt for the installation of Microsoft ActiveX controls.</summary>
        navTrustedForActiveX = 0x0400,
        /// <summary>Windows Internet Explorer 7. Open the resource or file in a new tab. Allow the destination window to come to the foreground, if necessary.</summary>
        navOpenInNewTab = 0x0800,
        /// <summary>Internet Explorer 7. Open the resource or file in a new background tab; the currently active window and/or tab remains open on top.</summary>
        navOpenInBackgroundTab = 0x1000,
        /// <summary>Internet Explorer 7. Maintain state for dynamic navigation based on the filter string entered in the search band text box (wordwheel). Restore the wordwheel text when the navigation completes.</summary>
        navKeepWordWheelText = 0x2000,
        /// <summary>Internet Explorer 8. Open the resource as a replacement for the current or target tab. The existing tab is closed while the new tab takes its place in the tab bar and replaces it in the tab group, if any. Browser history is copied forward to the new tab. On Windows Vista, this flag is implied if the navigation would cross integrity levels and navOpenInNewTab, navOpenInBackgroundTab, or navOpenInNewWindow is not specified.</summary>
        navVirtualTab = 0x4000,
        /// <summary>Internet Explorer 8. Block cross-domain redirect requests. The navigation triggers the DWebBrowserEvents2::RedirectXDomainBlocked event if blocked.</summary>
        navBlockRedirectsXDomain = 0x8000,
        /// <summary>Internet Explorer 8 and later. Open the resource in a new tab that becomes the foreground tab.</summary>
        navOpenNewForegroundTab = 0x10000
    }
}
