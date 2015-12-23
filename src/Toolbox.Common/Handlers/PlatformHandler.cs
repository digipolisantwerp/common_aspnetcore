using System;

namespace Toolbox.Common.Handlers
{
    public class PlatformHandler
    {
        static PlatformHandler()
        {
            Platform = new Platform(Environment.OSVersion.Platform);
        }

        public static Platform Platform { get; set; }
    }

    public class Platform
    {
        public Platform(PlatformID platformId)
        {
            PlatformID = platformId;
        }

        public PlatformID PlatformID { get; private set; }

        public bool IsLinux { get { return ( PlatformID == PlatformID.Unix ); } }

        public bool IsMac { get { return ( PlatformID == PlatformID.MacOSX ); } }

        public bool IsUnix { get { return ( PlatformID == PlatformID.Unix ); } }

        public bool IsWindows
        {
            get
            {
                return ( PlatformID == PlatformID.Win32NT ||
                         PlatformID == PlatformID.Win32S ||
                         PlatformID == PlatformID.Win32Windows ||
                         PlatformID == PlatformID.WinCE );
            }
        }

        public bool IsXbox { get { return ( PlatformID == PlatformID.Xbox ); } }
    }
}
