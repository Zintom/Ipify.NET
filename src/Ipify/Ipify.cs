/*
    Copyright © 2015 David Musgrove.
    Licensed under the terms of the MIT License.
*/

using System.Net;

namespace Ipify
{
    /// <summary>
    /// Static utility class exposing methods to facilitate resolving a client's
    /// public IP address on the Internet by querying the service at ipify.org.
    /// </summary>
    public static class Ipify
    {
        /// <summary>
        /// Resolves the public IP address and returns it as a <see cref="string"/>.
        /// </summary>
        /// <param name="useHttps">
        /// Specifies whether to use HTTPS to talk to ipify.org (defaults to
        /// <b>true</b> if omitted).
        /// </param>
        /// <returns>
        /// A <see cref="string"/> containing the public IP address, or <see cref="string.Empty"/> if an error is
        /// encountered.
        /// </returns>
        public static string GetPublicIPAddressString(bool useHttps = true)
        {
            var endpoint = useHttps ? "https://api.ipify.org" : "http://api.ipify.org";
            using (var client = new WebClient())
            {
                try
                {
                    return client.DownloadString(endpoint);
                }
                catch
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Resolves the public IP address and returns it as an instance of
        /// <see cref="IPAddress" />.
        /// </summary>
        /// <param name="useHttps">
        /// Specifies whether to use HTTPS to talk to ipify.org (defaults to
        /// <b>true</b> if omitted).
        /// </param>
        /// <returns>
        /// An instance of <see cref="IPAddress" /> containing the public IP address, or <see cref="IPAddress.None" /> if an error is
        /// encountered.
        /// </returns>
        public static IPAddress GetPublicIPAddress(bool useHttps = true)
        {
            if (!IPAddress.TryParse(GetPublicIPAddressString(useHttps), out IPAddress ipAddress))
            {
                return IPAddress.None;
            }

            return ipAddress;
        }

    }
}