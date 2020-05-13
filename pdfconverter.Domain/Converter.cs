using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.Drawing.Imaging;
using System.IO;

namespace pdfconverter.Domain
{
    public class Converter
    {
        public string[] GetFiles()
        {
            string[] files =
                Directory.GetFiles(@"F:\OneDrive\Projekty\pdfConverter\pdf", "*.pdf", SearchOption.TopDirectoryOnly);
            return files;
        }

        public string[] GetPDfs()
        {
            string[] files =
                Directory.GetFiles(@"F:\OneDrive\Projekty\pdfConverter\pdf", "*.pdf", SearchOption.TopDirectoryOnly);
            return files;
        }

        /// <summary>
        /// Imports all pages from a list of documents.
        /// </summary>
        public void SplitPages()
        {
            // Get some file names
            string[] files = GetFiles();
            var name = @"F:\OneDrive\Projekty\pdfConverter\pdf";
            int it = 1;
            // Open the output document


            // Iterate files
            foreach (string file in files)
            {
                // Open the document to import pages from it.
                PdfDocument inputDocument = PdfReader.Open(file, PdfDocumentOpenMode.Import);

                // Iterate pages
                int count = inputDocument.PageCount;
                for (int idx = 0; idx < count; idx++)
                {
                    PdfDocument outputDocument = new PdfDocument();
                    // Get the page from the external document...
                    PdfPage page = inputDocument.Pages[idx];
                    // ...and add it to the output document.
                    outputDocument.AddPage(page);
                    outputDocument.Save(name + it + ".pdf");
                    it++;
                }
            }
        }

        public void SaveAsImage()
        {
            // Get some file names
            string[] files = GetPDfs();
            var name = @"F:\OneDrive\Projekty\pdfConverter\pdf\";
            int it = 1;

            // Iterate files
            foreach (string file in files)
            {
                var doc = new Spire.Pdf.PdfDocument();
                doc.LoadFromFile(file);
                var bmp = doc.SaveAsImage(0);
                bmp.Save(name + it + ".jpg", ImageFormat.Jpeg);
                it++;
            }
        }
    }
}
