/*
    Copyright © 2015 David Musgrove.
    Licensed under the terms of the MIT License.
*/

using System.Net;

using NUnit.Framework;

namespace Ipify.Tests
{
    [TestFixture]
    public class IpifyTests
    {
        [Test]
        public void GetAddress_ReturnsStringContainingAnIPAddress()
        {
            Assert.IsTrue(IPAddress.TryParse(Ipify.GetPublicIPAddressString(), out _));
        }

        [Test]
        public void GetAddress_ReturnsStringContainingAnIPAddressUsingHttp()
        {
            Assert.IsTrue(IPAddress.TryParse(Ipify.GetPublicIPAddressString(false), out _));
        }

        [Test]
        public void GetIPAddress_ReturnsIPAddressInstance()
        {
            IPAddress ipAddress = Ipify.GetPublicIPAddress();
            Assert.IsNotNull(ipAddress);
            Assert.AreNotEqual(IPAddress.None, ipAddress);
        }

        [Test]
        public void GetIPAddress_ReturnsIPAddressInstanceUsingHttp()
        {
            IPAddress ipAddress = Ipify.GetPublicIPAddress(false);
            Assert.IsNotNull(ipAddress);
            Assert.AreNotEqual(IPAddress.None, ipAddress);
        }
    }
}
