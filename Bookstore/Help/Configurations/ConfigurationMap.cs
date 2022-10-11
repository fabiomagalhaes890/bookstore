using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Help.Configs
{
    public class ConfigurationMap
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(config =>
            {
                config.AddProfile(new EntityToDto());
                config.AddProfile(new DtoToEntity());
            });
        }

        public static IMapper CreateMap()
        {
            var configurationMap = new MapperConfiguration(config =>
            {
                config.AddProfile(new EntityToDto());
                config.AddProfile(new DtoToEntity());
            });

            return configurationMap.CreateMapper();
        }
    }
}
