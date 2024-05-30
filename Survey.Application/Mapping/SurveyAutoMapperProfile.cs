using AutoMapper;
using Survey.Application.Responses;
using Survey.Domain.SurveyAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Mapping
{
    public class SurveyAutoMapperProfile : Profile
    {
        public SurveyAutoMapperProfile()
        {
            CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<Option, OptionResponse>().ReverseMap();
        }
    }
}
