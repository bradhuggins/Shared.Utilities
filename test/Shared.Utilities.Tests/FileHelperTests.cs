#region Using Statements
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#endregion

namespace Shared.Utilities.Tests
{
    [TestClass]
    public class FileHelperTests
    {
        [TestMethod]
        public void Base64StringToByteArrayTest()
        {
            // Arrange
            string input = @"77u/";
            // Act
            var actual = FileHelper.Base64StringToByteArray(input);

            // Asset
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void Base64StringToFileTest()
        {
            // Arrange
            string filename = AppDomain.CurrentDomain.BaseDirectory + StringHelper.GenerateCleanGuid() + ".txt";
            string content = @"77u/";

            // Act
            FileHelper.Base64StringToFile(filename, content);

            // Asset
        }

        [TestMethod]
        public void Base64StringToStreamTest()
        {
            // Arrange
            string input = @"77u/";

            // Act
            var actual = FileHelper.Base64StringToStream(input);

            // Asset
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void ByteArrayToBase64StringTest()
        {
            // Arrange

            // Act
            var actual = FileHelper.ByteArrayToBase64String(FileHelper.TransparentGif);

            // Asset
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual == "R0lGODlhAQABAID/AMDAwAAAACH5BAEAAAAALAAAAAABAAEAAAICRAEAOw==");
        }

        [TestMethod]
        public void ByteArrayToStreamTest()
        {
            // Arrange

            // Act
            var actual = FileHelper.ByteArrayToStream(FileHelper.EmptyTextFile);

            // Asset
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void FileToByteArrayTest()
        {
            // Arrange
            string filename = AppDomain.CurrentDomain.BaseDirectory + "sample.txt";
            //string filename = AppDomain.CurrentDomain.BaseDirectory + "transparentgif.gif";

            // Act
            var actual = FileHelper.FileToByteArray(filename);

            // Asset
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void FileToBase64StringTest()
        {
            // Arrange
            string filename = AppDomain.CurrentDomain.BaseDirectory + "sample.txt";

            // Act
            var actual = FileHelper.FileToBase64String(filename);

            // Asset
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual == @"77u/");
        }

        [TestMethod]
        public void StreamToBase64StringTest()
        {
            // Arrange
            string input = @"77u/";
            var stream = FileHelper.Base64StringToStream(input);

            // Act
            var actual = FileHelper.StreamToBase64String(stream);

            // Asset
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual == input);
        }

        [TestMethod]
        public void StreamToByteArrayTest()
        {
            // Arrange
            var input = FileHelper.ByteArrayToStream(FileHelper.TransparentGif);

            // Act
            var actual = FileHelper.StreamToByteArray(input);

            // Asset
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void StringToByteArrayTest()
        {
            // Arrange
            string input = "hello world";

            // Act
            var actual = FileHelper.StringToByteArray(input);

            // Asset
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void EmptyTextFileTest()
        {
            // Arrange

            // Act
            var actual = FileHelper.EmptyTextFile;

            // Asset
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void TransparentGifTest()
        {
            // Arrange

            // Act
            var actual = FileHelper.TransparentGif;

            // Asset
            Assert.IsNotNull(actual);
        }


    }
}
