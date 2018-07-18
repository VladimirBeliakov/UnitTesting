using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinjaUnitTests.Mocking
{
    [TestFixture]
    public class InstallerHelperUnitTests
    {
        [Test]
        public void DownloadInstaller_DownloadSucceeds_ReturnsTrue()
        {
            // Arrange
            var instHelper = new InstallerHelper();
            var webClient = new FakeWebClient();
            instHelper.Client = webClient;
            var customerName = "vlad_beliakov";
            var installerName = "installer_name";

            // Act
            var result = instHelper.DownloadInstaller(customerName, installerName);

            // Assert
            Assert.IsTrue(result);
        }

        private FakeWebClient WebclientFactory()
        {
            return Substitute.For<FakeWebClient>();
        }

        public class FakeWebClient : WebClient
        {
            public new void DownloadFile(string address, string fileName)
            {


            }
        }
    }
}
