#region Using Statements
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endregion

namespace Shared.Utilities.Tests
{
    [TestClass]
    public class HashHelperTests
    {
        [TestMethod]
        public void ToSHA1_Test()
        {
            // Arrange
            string message = "Hello World";

            // Act
            var actual = HashHelper.ToSHA1(message);

            // Asset
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual == "0a4d55a8d778e5022fab701977c5d840bbc486d0");
        }

        [TestMethod]
        public void ToMD5_Test()
        {
            // Arrange
            string message = "Hello World";

            // Act
            var actual = HashHelper.ToMD5(message);

            // Asset
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual == "b10a8db164e0754105b7a99be72e3fe5");
        }


    }
}
