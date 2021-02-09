using Xunit;
using WikimediaData.Compression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikimediaData.Compression.Tests
{
    public class GZipTests
    {
        GZip testInstance = new GZip();

        [Fact()]
        public void GetFileExtensionTest()
        {
            string value = testInstance.GetFileExtension();
            Assert.Equal("gz", value);
        }

        [Fact()]
        public void GetFileExtensionPatternTest()
        {
            string value = testInstance.GetFileExtension();
            Assert.Equal("*.gz", value);
        }
    }
}