using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace Toolkie.Configuration.Application
{
    public static class ApplicationVersion
    {
        public static string InformationalVersion
        {
            get
            {
                return FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location).ProductVersion;
            }
        }

        /// <summary>
        /// Gets release (last build) date of the application.
        /// It's shown in the web page.
        /// </summary>
        public static DateTime ReleaseDate
        {
            get
            {
                return new FileInfo(Assembly.GetEntryAssembly().Location).LastWriteTime;
            }
        }


        public static string ProjectName
        {
            get
            {
                return Assembly.GetEntryAssembly().GetName().Name;
            }
        }
    }
}
