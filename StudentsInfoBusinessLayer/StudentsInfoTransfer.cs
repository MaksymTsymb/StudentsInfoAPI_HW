using StudentsInfoDataAccesLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsInfoBusinessLayer
{
    public class StudentsInfoTransfer : IStudentsInfoTransfer
    {
        public StudentsInfo StudentsInfoDTOToStudentsInfo(StudentsInfoDTO studentsInfoDTO)
        {
            var studentsInfo = new StudentsInfo()
            {
                Id = studentsInfoDTO.Id,
                FamilyName = studentsInfoDTO.FamilyName,
                DateOfBirth = studentsInfoDTO.DateOfBirth,
                GeneralGrade = studentsInfoDTO.GeneralGrade,
                Nationality = studentsInfoDTO.Nationality,
                NativeResident = new StudentsInfoDataExtension().IsNativeResident(studentsInfoDTO.Nationality),
                GradeMark = new StudentsInfoDataExtension().GetGradeMark(studentsInfoDTO.GeneralGrade),
                CurentAge = new StudentsInfoDataExtension().GetCurentAge(studentsInfoDTO.DateOfBirth)
            };

            return studentsInfo;
        }

        public StudentsInfoDTO StudentsInfoToStudentsInfoDTO(StudentsInfo studentsInfo)
        {
            var studentsInfoDTO = new StudentsInfoDTO()
            {
                Id = studentsInfo.Id,
                FamilyName = studentsInfo.FamilyName,
                DateOfBirth = studentsInfo.DateOfBirth,
                GeneralGrade = studentsInfo.GeneralGrade,
                Nationality = studentsInfo.Nationality,
            };

            return studentsInfoDTO;
        }
    }
}
