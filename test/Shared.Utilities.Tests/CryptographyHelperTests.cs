#region Using Statements
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuGet.Frameworks;
#endregion

namespace Shared.Utilities.Tests
{
    [TestClass]
    public class CryptographyHelperTests
    {
        [TestMethod]
        public void EncryptTest()
        {
            // Arrange
            CryptographyHelper target = new CryptographyHelper();
            string input = "hello world";

            // Act
            var actual = target.Encrypt(input);

            // Asset
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual == "ZKzGl/b565UeYrQrclIvlQ==");
        }

        [TestMethod]
        public void Encrypt2Test()
        {
            // Arrange
            CryptographyHelper target = new CryptographyHelper();
            string input = "hello world";
            string _key = "0123456789abcdef";

            // Act
            var actual = target.Encrypt(input, _key);

            // Asset
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual == "A2/oouTwRxQRIjmCu5bvgg==");
        }






    }
}
