#region Using Statements
using System;
using System.IO;
#endregion

namespace Shared.Utilities
{
    public partial class FileHelper
    {
        public static byte[] Base64StringToByteArray(string input)
        {
            byte[] toReturn = Convert.FromBase64String(input);
            return toReturn;
        }

        public static void Base64StringToFile(string fileName, string content)
        {
            byte[] fileContent = Base64StringToByteArray(content);
            using (FileStream file = new FileStream(fileName, FileMode.Create))
            {
                using (BinaryWriter writer = new BinaryWriter(file))
                {
                    writer.Write(fileContent, 0, fileContent.Length);
                }
            }
        }

        public static Stream Base64StringToStream(string input)
        {
            Stream toReturn = null;
            byte[] fileContent = Convert.FromBase64String(input);
            toReturn = new MemoryStream(fileContent);
            return toReturn;
        }

        public static string ByteArrayToBase64String(byte[] input)
        {
            string toReturn = null;
            
                throw new NotImplementedException();

            //return toReturn;
        }

        public static Stream ByteArrayToStream(byte[] input)
        {
            Stream toReturn = null;
            toReturn = new MemoryStream(input);
            return toReturn;
        }

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

        public static string FileToBase64String(string fileName)
        {
            string toReturn = null;
            byte[] fileContent = FileToByteArray(fileName);
            toReturn = ByteArrayToBase64String(fileContent);
            return toReturn;
        }

        public static string StreamToBase64String(Stream input)
        {
            string toReturn = null;
            byte[] fileContent = null;
            using (var memoryStream = new MemoryStream())
            {
                input.CopyTo(memoryStream);
                fileContent = memoryStream.ToArray();
            }
            toReturn = ByteArrayToBase64String(fileContent);
            return toReturn;
        }

        public static byte[] StreamToByteArray(Stream input)
        {
            byte[] toReturn = null;
            using (var memoryStream = new MemoryStream())
            {
                input.CopyTo(memoryStream);
                toReturn = memoryStream.ToArray();
            }            
            return toReturn;
        }

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

        public static byte[] EmptyTextFile = { 0xef, 0xbb, 0xbf };

        public static byte[] TransparentGif = {0x47, 0x49, 0x46, 0x38, 0x39, 0x61, 0x01, 0x00,
                                               0x01, 0x00, 0x80, 0xff, 0x00, 0xc0, 0xc0, 0xc0,
                                               0x00, 0x00, 0x00, 0x21, 0xf9, 0x04, 0x01, 0x00,
                                               0x00, 0x00, 0x00, 0x2c, 0x00, 0x00, 0x00, 0x00,
                                               0x01, 0x00, 0x01, 0x00, 0x00, 0x02, 0x02, 0x44,
                                               0x01, 0x00, 0x3b};
        //clear gif
        // data:image/gif;base64,R0lGODlhAQABAIAAAP///wAAACH5BAEAAAAALAAAAAABAAEAAAICRAEAOw==
        // <img src="data:image/gif;base64,R0lGODlhAQABAIAAAP///wAAACH5BAEAAAAALAAAAAABAAEAAAICRAEAOw==" />


    }

}
