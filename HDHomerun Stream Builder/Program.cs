using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Vlc.DotNet.Core;

namespace HDHomerun_Stream_Builder
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool isAMD64 = System.IO.Directory.Exists(CommonStrings.LIBVLC_DLLS_PATH_DEFAULT_VALUE_AMD64);
            bool isX86 = System.IO.Directory.Exists(CommonStrings.LIBVLC_DLLS_PATH_DEFAULT_VALUE_X86);

            if (isAMD64 || isX86)
            {
                try
                {
                    if (isAMD64)
                    {
                        //Set libvlc.dll and libvlccore.dll directory path
                        VlcContext.LibVlcDllsPath = CommonStrings.LIBVLC_DLLS_PATH_DEFAULT_VALUE_AMD64;
                        //Set the vlc plugins directory path
                        VlcContext.LibVlcPluginsPath = CommonStrings.PLUGINS_PATH_DEFAULT_VALUE_AMD64;
                    }
                    else
                    {
                        //Set libvlc.dll and libvlccore.dll directory path
                        VlcContext.LibVlcDllsPath = CommonStrings.LIBVLC_DLLS_PATH_DEFAULT_VALUE_X86;
                        //Set the vlc plugins directory path
                        VlcContext.LibVlcPluginsPath = CommonStrings.PLUGINS_PATH_DEFAULT_VALUE_X86;
                    }

                    //Set the startup options
                    VlcContext.StartupOptions.IgnoreConfig = true;
                    VlcContext.StartupOptions.LogOptions.LogInFile = true;
                    VlcContext.StartupOptions.LogOptions.ShowLoggerConsole = true;
                    VlcContext.StartupOptions.LogOptions.Verbosity = VlcLogVerbosities.None;

                    //Initialize the VlcContext
                    VlcContext.Initialize();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed loading the optional VLC library. Channel previewing may not work correctly. Do you have the latest version of VLC installed? " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("VLC DLL files not found in either of the standard locations: " + CommonStrings.LIBVLC_DLLS_PATH_DEFAULT_VALUE_AMD64 + " or " + CommonStrings.LIBVLC_DLLS_PATH_DEFAULT_VALUE_X86);
            }

            Application.Run(new Main());

            if (isAMD64 || isX86)
            {
                try
                {
                    //Close the VlcContexttry 
                    VlcContext.CloseAll();
                }
                catch (Exception) { }
            }
        }
    }
}
