using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace pdfconverter.Domain
{
    public class Converter
    {
        public Image FirstPage(string sourcePath)
        {
            if(File.Exists(sourcePath))
            {
                var doc = new Spire.Pdf.PdfDocument();
                doc.LoadFromFile(sourcePath);
                return doc.SaveAsImage(0);
            }
            return null;
        }

        public Image FirstPage(byte[] source)
        {
            var doc = new Spire.Pdf.PdfDocument();
            doc.LoadFromBytes(source);
            return doc.SaveAsImage(0);
        }

        public List<Image> SingleFile(byte[] source)
        {
            var result = new List<Image>();
            var doc = new Spire.Pdf.PdfDocument();
            doc.LoadFromBytes(source);
            for (int it = 0; it < doc.Pages.Count; it++)
            {
                result.Add(doc.SaveAsImage(it));
            }

            return result;
        }

        public void SaveAsImage(string sourcePath, string targetPath)
        {
            // Get some file names
            string[] files = GetPDfs(sourcePath);

            // Iterate files
            foreach (string file in files)
            {
                var name = Path.GetFileNameWithoutExtension(file);
                var path = targetPath.Contains(".") ? Path.GetDirectoryName(targetPath) : targetPath;
                if (File.Exists(Path.Combine(path, name + "_1".ToString() + ".jpg")))
                {
                    continue;
                }
                var doc = new Spire.Pdf.PdfDocument();
                doc.LoadFromFile(file);
                for (int it = 0; it < doc.Pages.Count; it++)
                {
                    var bmp = doc.SaveAsImage(it);                  
                    bmp.Save(Path.Combine(path, name + "_" + (it + 1).ToString() + ".jpg"), ImageFormat.Jpeg);
                }
            }
        }
        private string[] GetPDfs(string path)
        {
            string[] files =
                Directory.GetFiles(path, "*.pdf", SearchOption.TopDirectoryOnly);
            return files;
        }
    }
}
