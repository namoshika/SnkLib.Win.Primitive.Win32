using System;
using System.Runtime.InteropServices;

namespace SunokoLibrary.Windows.Win32
{
  [ComImport(), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), GuidAttribute("3050f3f0-98b5-11cf-bb82-00aa00bdce0b")]
  public interface ICustomDoc
  {
    [PreserveSig]
    void SetUIHandler(IDocHostUIHandler pUIHandler);
  }

}
