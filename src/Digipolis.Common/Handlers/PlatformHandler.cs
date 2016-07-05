using Microsoft.AspNetCore.Hosting;
using System;
using System.Runtime.InteropServices;

namespace Digipolis.Common.Handlers
{
    public class PlatformHandler
    {
        static PlatformHandler()
        {

            var currentPlatform = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                ? OSPlatform.Windows
                : RuntimeInformation.IsOSPlatform(OSPlatform.OSX)
                ? OSPlatform.OSX
                : OSPlatform.Linux;
            Platform = new Platform(currentPlatform);
        }

        public static Platform Platform { get; set; }
    }

    public class Platform
    {
        public Platform(OSPlatform platform)
        {
            OSPlatform = platform;
        }

        public OSPlatform OSPlatform { get; set; }

        public bool IsLinux { get { return OSPlatform == OSPlatform.Linux; } }

        public bool IsMac { get { return OSPlatform == OSPlatform.OSX; } }

        public bool IsWindows { get { return OSPlatform == OSPlatform.Windows; } }
    }
}
