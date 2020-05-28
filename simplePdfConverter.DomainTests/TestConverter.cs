using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using pdfconverter.Domain;

namespace simplePdfConverter.DomainTests
{
    [TestClass]
    public class TestConverter
    {
        private byte[] LoadPdf()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "simplePdfConverter.DomainTests.Source.sample.pdf";
            using (Stream input = assembly.GetManifestResourceStream(resourceName))
            {
                byte[] buffer = new byte[16 * 1024];
                using (MemoryStream ms = new MemoryStream())
                {
                    int read;
                    while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                    return ms.ToArray();
                }
            }
        }

        [TestMethod]
        public void SingleFile_Pages()
        {
            var pdf = LoadPdf();
            var converter = new Converter();
            var expected = 2;

            var result = converter.SingleFile(pdf);
            var actual = result.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FirstPage_NotEmptyImage()
        {
            var pdf = LoadPdf();
            var converter = new Converter();

            var result = converter.FirstPage(pdf);
            Assert.AreNotEqual(0, result.Width);
            Assert.AreNotEqual(0, result.Height);
        }

        [TestMethod]
        public void SingleFile_NotEmptyImages()
        {
            var pdf = LoadPdf();
            var converter = new Converter();

            var result = converter.SingleFile(pdf);
            Assert.AreEqual(2, result.Count());


            Assert.AreNotEqual(0, result[0].Width);
            Assert.AreNotEqual(0, result[0].Height);
            Assert.AreNotEqual(0, result[1].Width);
            Assert.AreNotEqual(0, result[1].Height);
        }
    }
}
