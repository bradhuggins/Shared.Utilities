#region Using Statements
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuGet.Frameworks;
using System.ComponentModel.Design;
#endregion

namespace Shared.Utilities.Tests
{
    [TestClass]
    public class StringHelperTests
    {
        [TestMethod]
        public void ToBase64EncodedString_Test()
        {
            // Arrange
            var input = "Hello World";
            // Act
            var actual = StringHelper.ToBase64EncodedString(input);

            // Asset
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual == "SGVsbG8gV29ybGQ=");
        }

        [TestMethod]
        public void ToBase64DecodedString_Test()
        {
            // Arrange
            var input = "SGVsbG8gV29ybGQ=";

            // Act
            var actual = StringHelper.ToBase64DecodedString(input);

            // Asset
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual == "Hello World");
        }

        [TestMethod]
        public void Reverse_Test()
        {
            // Arrange
            string input = "Hello World";

            // Act
            var actual = StringHelper.Reverse(input);

            // Asset
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual == "dlroW olleH");
        }

        [TestMethod]
        public void StripNonNumericCharacters_Test()
        {
            // Arrange
            string input = "a1b2c3d4e5f6";

            // Act
            var actual = StringHelper.StripNonNumericCharacters(input);

            // Asset
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual == "123456");
        }

        [TestMethod]
        public void SerializeObjectToString_Test()
        {
            // Arrange

            // Act

            // Asset

        }

        [TestMethod]
        public void RetrieveObjectFromString_Test()
        {
            // Arrange

            // Act

            // Asset

        }

        [TestMethod]
        public void GenerateCleanGuid_Test()
        {
            // Arrange

            // Act
            var actual = StringHelper.GenerateCleanGuid();

            // Asset
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void ToHexString_Test()
        {
            // Arrange
             byte[] input = {0x47, 0x49, 0x46, 0x38, 0x39, 0x61, 0x01, 0x00,
                            0x01, 0x00, 0x80, 0xff, 0x00, 0xc0, 0xc0, 0xc0,
                            0x00, 0x00, 0x00, 0x21, 0xf9, 0x04, 0x01, 0x00,
                            0x00, 0x00, 0x00, 0x2c, 0x00, 0x00, 0x00, 0x00,
                            0x01, 0x00, 0x01, 0x00, 0x00, 0x02, 0x02, 0x44,
                            0x01, 0x00, 0x3b};
            // Act
            var actual = StringHelper.ToHexString(input);

            // Asset
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual == "4749463839610100010080ff00c0c0c000000021f90401000000002c00000000010001000002024401003b");
        }

    }
}
