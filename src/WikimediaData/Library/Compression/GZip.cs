﻿using System;
using System.IO;
using System.IO.Compression;
using WikimediaData.Interfaces;

namespace WikimediaData.Compression
{
    public class GZip : ICompression
    {
        public void Decompress(FileInfo fileToDecompress)
        {
            

            using (FileStream originalFileStream = fileToDecompress.OpenRead())
            {
                string currentFileName = fileToDecompress.FullName;

                Console.WriteLine(string.Concat("Decompressing file ", currentFileName, "..."));

                string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

                using (FileStream decompressedFileStream = File.Create(newFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFileStream);
                    }
                }
            }
        }

        public void Compress(FileInfo fileTocompress)
        {
            throw new NotImplementedException();
        }

        public string GetFileExtension()
        {
            return "gz";
        }

        public string GetFileExtensionPattern()
        {
            return "*.gz";
        }
    }
}
