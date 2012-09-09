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

            try
            {
                //Set libvlc.dll and libvlccore.dll directory path
                VlcContext.LibVlcDllsPath = CommonStrings.LIBVLC_DLLS_PATH_DEFAULT_VALUE_AMD64;
                //Set the vlc plugins directory path
                VlcContext.LibVlcPluginsPath = CommonStrings.PLUGINS_PATH_DEFAULT_VALUE_AMD64;

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

            Application.Run(new Main());

	        try
            {
                //Close the VlcContexttry 
                VlcContext.CloseAll();
	        }
	        catch (Exception) { }
        }
    }
}
