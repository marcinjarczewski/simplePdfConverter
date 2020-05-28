using AutoMapper;
using Caliburn.Micro;
using Microsoft.Win32;
using pdfconverter.Domain;
using pdfConverter.Contracts;
using pdfConverter.Contracts.Db;
using simplePdfConverter.Contracts.Bootstrappers;
using System;
using System.IO;

namespace pdfConverter.WPF.ViewModels
{
    public class MainViewModel : PropertyChangedBase, IScreenViewModel
    {
        private IDbAccess _database;
        private IMapper _mapper;
        private INavigator _navigator;

        private string _SingleFile;

        public string SingleFile
        {
            get { return _SingleFile; }
            set
            {
                _SingleFile = value;
                NotifyOfPropertyChange(() => SingleFile);
            }
        }

        private string _TargetPath;

        public string TargetPath
        {
            get { return _TargetPath; }
            set { _TargetPath = value; }
        }

        private string _SourcePath;

        public string SourcePath
        {
            get { return _SourcePath; }
            set { _SourcePath = value; }
        }

        /// <summary>
        /// Calls just once.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="mapper"></param>
        public MainViewModel(IDbAccess db, IMapper mapper, INavigator navigator)
        {
            _database = db;
            _mapper = mapper;
            _navigator = navigator;
        }
        /// <summary>
        /// Calls every time when view is activated.
        /// </summary>
        public void Init()
        {
            var config = _database.GetConfig();
            SourcePath = config.SourceFolderPath;
            TargetPath = config.TargetFolderPath;
        }

        public bool CanConvertPdfs()
        {
            return !string.IsNullOrEmpty(SourcePath) && !string.IsNullOrEmpty(TargetPath);
        }

        public void ConvertPdfs()
        {
            try
            {
                var converter = new Converter();
                converter.SaveAsImage(SourcePath, TargetPath);
                _navigator.ShowDialog("Confirmation", "PDFs converted.");
            }
            catch(Exception ex)
            {
                _navigator.ShowDialog("Error", ex.Message);
            }
        }

        public bool CanConvertSinglePdf(string singleFile)
        {
            return !string.IsNullOrEmpty(singleFile);
        }

        public void ConvertSinglePdf(string singleFile)
        {
            try
            {
                var converter = new Converter();
                var img = converter.FirstPage(singleFile);

                //save to temp and open in default image viewer
                var path = string.Concat(Path.GetTempPath(), Guid.NewGuid().ToString(), ".png");
                img.Save(path);
                System.Diagnostics.Process.Start(path);
            }
            catch (Exception ex)
            {
                _navigator.ShowDialog("Error", ex.Message);
            }
        }

        public void SinglePdfPicker()
        {
            OpenFileDialog saveFileDialog = new OpenFileDialog();
            saveFileDialog.Filter = "PDF (*.pdf)|*.pdf";
            if (saveFileDialog.ShowDialog() == true)
            {
                SingleFile = saveFileDialog.FileName;
            }
        }

    }
}
