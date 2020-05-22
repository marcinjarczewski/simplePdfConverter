using AutoMapper;
using Caliburn.Micro;
using Microsoft.Win32;
using pdfConverter.Contracts;
using pdfConverter.Contracts.Db;
using simplePdfConverter.Contracts.Db;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace pdfConverter.WPF.ViewModels
{
    public class SettingsViewModel
    {
        private readonly IDbAccess _database;
        private readonly IMapper _mapper;

        private string _SourceFolderPath;

        public string SourceFolderPath
        {
            get { return _SourceFolderPath; }
            set { _SourceFolderPath = value; }
        }

        private string _TargetFolderPath;

        public string TargetFolderPath
        {
            get { return _TargetFolderPath; }
            set { _TargetFolderPath = value; }
        }


        public SettingsViewModel(IMapper mapper, IDbAccess db)
        {
            _database = db;
            _mapper = mapper;
            var config = db.GetConfig();           
            SourceFolderPath = config.SourceFolderPath;
            TargetFolderPath = config.TargetFolderPath;
        }

        public void Save()
        {
            var config = new DbConfigDto
            {
                SourceFolderPath = SourceFolderPath,
                TargetFolderPath = TargetFolderPath
            };
            _database.SaveConfig(config);
        }
    }
}
