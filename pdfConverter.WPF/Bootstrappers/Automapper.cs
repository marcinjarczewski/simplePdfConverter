using AutoMapper;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using pdfConverter.Contracts;
using pdfConverter.WPF.ViewModels;
using simplePdfConverter.Contracts.Db;
using simplePdfConverter.Database.DbModels;
using System.Collections.Generic;
using System.Reflection;

namespace pdfConverter.WPF.Bootstrappers
{
    public static class Automapper
    {
        //public static IMapper Mapper;
        public static IMapper Init()
        {
            var _configuraton = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DbConfigModel, DbConfigDto>();
                cfg.CreateMap<DbConfigDto, DbConfigModel>();

                cfg.CreateMap<DbLogModel, DbLogDto>();
                cfg.CreateMap<DbLogDto, DbLogModel>();
            });

            return _configuraton.CreateMapper();
        }
    }
}