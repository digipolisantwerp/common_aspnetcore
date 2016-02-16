using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Toolbox.Common.Helpers
{
    public class UriHelper
    {  /// <summary>
       /// Returns true if the given string contains a valid url.
       /// </summary>
       /// <param name="uri">A string that contains a uri.</param>
       /// <returns>True when valid url, False when invalid url.</returns>
        public static bool IsValidUri(string uri)
        {
            Uri uriResult;
            bool result = Uri.TryCreate(uri, UriKind.Absolute, out uriResult);
            if (result)
                return (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            else
                return result;
        }

        /// <summary>
        /// Displays the name of the primary host.
        /// </summary>
        /// <param name="uri">A string that contains a uri.</param>
        /// <returns>The primary host name.</returns>
        /// <exception cref="ArgumentException">If the string is not a valid uri.</exception>
        public static string GetPrimaryHostName(string uri)
        {
            if (!IsValidUri(uri)) throw new ArgumentException(String.Format("The given uri {0} is not a valid uri.", StringHelper.GetValidString(uri)), "uri");
            var hostName = GetPrimaryHostName(new Uri(uri));
            return hostName;
        }

        /// <summary>
        /// Returns the name of the primary host.
        /// </summary>
        /// <param name="uri">An Uri object.</param>
        /// <returns>The primary host name.</returns>
        public static string GetPrimaryHostName(Uri uri)
        {
            var hostEntry = Dns.GetHostEntry(uri.Host);
            return hostEntry.HostName;
        }
    }
}
