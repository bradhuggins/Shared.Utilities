#region Using Statements
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endregion

namespace Shared.Utilities.Tests
{
    [TestClass]
    public class EnumHelperTests
    {
        [TestMethod]
        public void GetDescriptionFromEnumValue_Test()
        {
            // Arrange

            // Act
            var actual = EnumHelper.GetDescriptionFromEnumValue(Models.ExampleEnum.Unknown);

            // Asset
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual == "Unknown");
        }



    }
}
