#region Using Statements
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO; 
#endregion

namespace Shared.Utilities
{
    public static partial class FileHelper
    {
        /// <summary>
        /// converts a file to a byte array
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns></returns>
        public static byte[] FileToByteArray(string filename)
        {
            byte[] fileData = null;
            if (File.Exists(filename))
            {
                using (System.IO.FileStream fs = System.IO.File.Open(filename, System.IO.FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    if (fs.Length > 0)
                    {
                        fileData = new byte[(int)fs.Length];
                        fs.Read(fileData, 0, (int)fs.Length);
                    }
                }
            }
            return fileData;
        }

        /// <summary>
        /// converts a string to a byte array
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static byte[] StringToByteArray(string input)
        {
            byte[] fileData = null;
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(memoryStream))
                {
                    streamWriter.Write(input);
                    streamWriter.Flush();

                    // let the memory stream point back to the BOF(begining of file)
                    memoryStream.Seek(0, System.IO.SeekOrigin.Begin);

                    //create buffer with defined size
                    fileData = new Byte[(int)memoryStream.Length];

                    //write the stream to the buffer  
                    memoryStream.Read(fileData, 0, (int)memoryStream.Length - 1);
                }
            }
            return fileData;
        }

        /// <summary>
        /// Exports the base64 string to file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="content">The content.</param>
        public static void ExportBase64StringToFile(string fileName, string content)
        {
            byte[] fileContent = Convert.FromBase64String(content);
            using (FileStream file = new FileStream(fileName, FileMode.Create))
            {
                using (BinaryWriter writer = new BinaryWriter(file))
                {
                    writer.Write(fileContent, 0, fileContent.Length);
                }
            }
        }

        /// <summary>
        /// Converts the file to Base64 string.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public static string ConvertFileToBase64String(string fileName)
        {
            string toReturn = null;
            byte[] fileContent = FileToByteArray(fileName);
            toReturn = Convert.ToBase64String(fileContent);
            return toReturn;
        }

        /// <summary>
        /// Converts the stream to base64 string.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static string ConvertStreamToBase64String(Stream input)
        {
            string toReturn = null;
            byte[] fileContent = null;
            using (var memoryStream = new MemoryStream())
            {
                input.CopyTo(memoryStream);
                fileContent = memoryStream.ToArray();
            }
            toReturn = Convert.ToBase64String(fileContent);
            return toReturn;
        }

        /// <summary>
        /// Converts the base64 string to stream.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static MemoryStream ConvertBase64StringToStream(string input)
        {
            MemoryStream toReturn = null;
            byte[] fileContent = Convert.FromBase64String(input);
            toReturn = new MemoryStream(fileContent);
            return toReturn;
        }

        //clear gif
        // data:image/gif;base64,R0lGODlhAQABAIAAAP///wAAACH5BAEAAAAALAAAAAABAAEAAAICRAEAOw==
        // <img src="data:image/gif;base64,R0lGODlhAQABAIAAAP///wAAACH5BAEAAAAALAAAAAABAAEAAAICRAEAOw==" />

        public static byte[] TransparentGif = {0x47, 0x49, 0x46, 0x38, 0x39, 0x61, 0x01, 0x00,
                                               0x01, 0x00, 0x80, 0xff, 0x00, 0xc0, 0xc0, 0xc0,
                                               0x00, 0x00, 0x00, 0x21, 0xf9, 0x04, 0x01, 0x00,
                                               0x00, 0x00, 0x00, 0x2c, 0x00, 0x00, 0x00, 0x00,
                                               0x01, 0x00, 0x01, 0x00, 0x00, 0x02, 0x02, 0x44,
                                               0x01, 0x00, 0x3b};
    }

}
