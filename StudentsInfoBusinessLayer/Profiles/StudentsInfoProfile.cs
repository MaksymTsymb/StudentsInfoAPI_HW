using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using DataAccessLayer;

namespace BusinessLayer
{
    public class StudentsInfoProfile: Profile
    {
        public StudentsInfoProfile()
        {
            CreateMap<StudentsInfo, StudentsInfoDTO>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.FamilyName, opt => opt.MapFrom(src => src.FamilyName))
                .ForMember(x => x.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(x => x.GeneralGrade, opt => opt.MapFrom(src => src.GeneralGrade))
                .ForMember(x => x.Nationality, opt => opt.MapFrom(src => src.Nationality));

            CreateMap<StudentsInfoDTO, StudentsInfo>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.FamilyName, opt => opt.MapFrom(src => src.FamilyName))
                .ForMember(x => x.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(x => x.GeneralGrade, opt => opt.MapFrom(src => src.GeneralGrade))
                .ForMember(x => x.Nationality, opt => opt.MapFrom(src => src.Nationality))
                .ForMember(x => x.CanadianResident, opt => opt.MapFrom(src => new StudentsInfoDataExtension().IsCanadianResident(src.Nationality)))
                .ForMember(x => x.GradeMark, opt => opt.MapFrom(src => new StudentsInfoDataExtension().GetGradeMark(src.GeneralGrade)))
                .ForMember(x => x.CurentAge, opt => opt.MapFrom(src => new StudentsInfoDataExtension().GetCurentAge(src.DateOfBirth)));
        }
    }
}
