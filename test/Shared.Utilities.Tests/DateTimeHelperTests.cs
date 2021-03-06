#region Using Statements
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#endregion

namespace Shared.Utilities.Tests
{
    [TestClass]
    public class DateTimeHelperTests
    {
        private readonly DateTime _defaultDate = Convert.ToDateTime("2/20/2020 2:00:00 PM");

        [TestMethod]
        public void ToIntTest()
        {
            // Arrange

            // Act
            var actual = DateTimeHelper.ToInt(_defaultDate, "yyyyMMdd");

            // Asset
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual == 20200220);
        }

        [TestMethod]
        public void ToDateTest()
        {
            // Arrange

            // Act
            var actual = DateTimeHelper.ToDate(20200220, "yyyyMMdd");

            // Asset
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual == Convert.ToDateTime("2/20/2020"));
        }

        [TestMethod]
        public void ToStringTest()
        {
            // Arrange

            // Act
            var actual = DateTimeHelper.ToString(_defaultDate);

            // Asset
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual == "2/20/2020 2:00 PM");
        }

        [TestMethod]
        public void ToStringFailTest()
        {
            // Arrange

            // Act
            var actual = DateTimeHelper.ToString(DateTime.MinValue);

            // Asset
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GetFirstDayOfMonthTest()
        {
            // Arrange

            // Act
            var actual = DateTimeHelper.GetFirstDayOfMonth(_defaultDate);

            // Asset
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Date == (Convert.ToDateTime("2/1/2020")).Date);
        }

        [TestMethod]
        public void GetLastDayOfMonthTest()
        {
            // Arrange

            // Act
            var actual = DateTimeHelper.GetLastDayOfMonth(_defaultDate);

            // Asset
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Date == (Convert.ToDateTime("2/29/2020")).Date);
        }

        [TestMethod]
        public void GetFirstDayOfQuarterQ1Test()
        {
            // Arrange

            // Act
            var actual = DateTimeHelper.GetFirstDayOfQuarter(Convert.ToDateTime("2/20/2020"));

            // Asset
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Date == (Convert.ToDateTime("1/1/2020")).Date);
        }

        [TestMethod]
        public void GetFirstDayOfQuarterQ2Test()
        {
            // Arrange

            // Act
            var actual = DateTimeHelper.GetFirstDayOfQuarter(Convert.ToDateTime("5/20/2020"));

            // Asset
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Date == (Convert.ToDateTime("4/1/2020")).Date);
        }

        [TestMethod]
        public void GetFirstDayOfQuarterQ3Test()
        {
            // Arrange

            // Act
            var actual = DateTimeHelper.GetFirstDayOfQuarter(Convert.ToDateTime("8/20/2020"));

            // Asset
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Date == (Convert.ToDateTime("7/1/2020")).Date);
        }

        [TestMethod]
        public void GetFirstDayOfQuarterQ4Test()
        {
            // Arrange

            // Act
            var actual = DateTimeHelper.GetFirstDayOfQuarter(Convert.ToDateTime("12/20/2020"));

            // Asset
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Date == (Convert.ToDateTime("10/1/2020")).Date);
        }

        [TestMethod]
        public void GetLastDayOfQuarterTest()
        {
            // Arrange

            // Act
            var actual = DateTimeHelper.GetLastDayOfQuarter(_defaultDate);

            // Asset
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Date == (Convert.ToDateTime("3/31/2020")).Date);
        }

        [TestMethod]
        public void GenerateDateFileNameTest()
        {
            // Arrange

            // Act
            var actual = DateTimeHelper.GenerateDateFileName(_defaultDate);

            // Asset
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual == "20200220");
        }

        [TestMethod]
        public void GenerateDateFileName2Test()
        {
            // Arrange

            // Act
            var actual = DateTimeHelper.GenerateDateFileName("pre_", ".txt", _defaultDate);

            // Asset
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual == "pre_20200220.txt");
        }

        [TestMethod]
        public void GenerateDateTimeFileNameTest()
        {
            // Arrange

            // Act
            var actual = DateTimeHelper.GenerateDateTimeFileName(_defaultDate);

            // Asset
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual == "20200220_1400");
        }

        [TestMethod]
        public void GenerateDateTimeFileName2Test()
        {
            // Arrange

            // Act
            var actual = DateTimeHelper.GenerateDateTimeFileName("pre_", ".txt", _defaultDate);

            // Asset
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual == "pre_20200220_1400.txt");
        }


    }
}
