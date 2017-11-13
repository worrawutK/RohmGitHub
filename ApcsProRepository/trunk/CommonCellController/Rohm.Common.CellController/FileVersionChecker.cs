using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rohm.Common.CellController
{
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    public class FileVersionChecker : IFileVersionChecker
    {

        public FileVersion GetFileVersion(string fileName)
        {

            byte[] hashArray = null;
            FileInfo fileInfo = new FileInfo(fileName);

            using (FileStream stream = fileInfo.OpenRead())
            {
                using (MD5CryptoServiceProvider encryptor = new MD5CryptoServiceProvider())
                {
                    hashArray = encryptor.ComputeHash(stream);
                }
            }

            StringBuilder strBuilder = new StringBuilder();
            foreach (byte b in hashArray)
            {
                strBuilder.Append(string.Format("{0}", b.ToString("X1")));
            }

            FileVersion fv = new FileVersion();
            fv.CheckSum = strBuilder.ToString();
            fv.FileName = fileInfo.Name;

            return fv;

        }

    }
}
