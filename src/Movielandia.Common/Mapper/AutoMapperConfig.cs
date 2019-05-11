using AutoMapper;
using AutoMapper.Mappers;
using Movielandia.Common.ViewModels;
using Movielandia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Movielandia.Common.Mapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            this.CreateMap<Movie, MovieViewModel>();
            this.CreateMap<Movie, AllMoviesViewModel>();
            this.CreateMap<Order, MakeOrderBindingModel>();
        }
    }
}

