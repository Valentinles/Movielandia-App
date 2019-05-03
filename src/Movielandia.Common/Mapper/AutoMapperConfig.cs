using AutoMapper;
using Movielandia.Common.ViewModels;
using Movielandia.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movielandia.Common.Mapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            this.CreateMap<Movie, AllMoviesViewModel>();
        }
    }
}
