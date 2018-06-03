using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using DeltaXMVC;
using Deltax;
namespace DeltaXMVC.Repository
{
    public class DeltaXMapper:Profile
    {
        public DeltaXMapper()
        {
            CreateMap<Movie, Models.Movie>();
            CreateMap<Models.Movie, Movie>();


        }
    }
}