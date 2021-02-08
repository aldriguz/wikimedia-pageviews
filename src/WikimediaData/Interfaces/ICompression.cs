using System.IO;

namespace WikimediaData.Interfaces
{
    public interface ICompression
    {
        string GetFileExtensionPattern();
        string GetFileExtension();
        void Decompress(FileInfo fileToDecompress);
        void Compress(FileInfo fileToDecompress);
    }
}
