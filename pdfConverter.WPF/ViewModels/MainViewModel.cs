﻿using AutoMapper;
using Caliburn.Micro;
using pdfconverter.Domain;
using pdfConverter.Contracts;
using pdfConverter.Contracts.Db;
using pdfConverter.WPF.Models;
using simplePdfConverter.Contracts.Bootstrappers;
using System;
using System.IO;

namespace pdfConverter.WPF.ViewModels
{
    public class MainViewModel : PropertyChangedBase, IScreenViewModel
    {
        private Models.SettingsModel _settingsModel;
        private IDbAccess _database;
        private IMapper _mapper;

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
        public MainViewModel(IDbAccess db, IMapper mapper)
        {
            _database = db;
            _mapper = mapper;
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
            var converter = new Converter();
            converter.SaveAsImage(SourcePath, TargetPath);
        }

        public bool CanConvertSinglePdf(string singleFile)
        {
            return !string.IsNullOrEmpty(singleFile);
        }

        public void ConvertSinglePdf(string singleFile)
        {
            var converter = new Converter();
            var img = converter.SingleFile(singleFile);

            //save to temp and open in default image viewer
            var path =string.Concat(Path.GetTempPath() , Guid.NewGuid().ToString() , ".png");
            img.Save(path);
            System.Diagnostics.Process.Start(path);
        }
    }
}
