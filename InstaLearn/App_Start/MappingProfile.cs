using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using InstaLearn.Dtos;
using InstaLearn.Models;

namespace InstaLearn.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Course, CourseDto>();
            Mapper.CreateMap<CourseDto, Course>();
        }                                                          //maps source => target
    }
}