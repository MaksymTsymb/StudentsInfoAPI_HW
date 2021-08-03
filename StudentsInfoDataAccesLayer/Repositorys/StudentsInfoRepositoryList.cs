using System;
using System.Collections.Generic;
using System.Linq;
using DataAccesLayer.Interfaces;

namespace DataAccesLayer.Repositorys
{
    public class StudentsInfoRepositoryList : IStudentsInfoRepository
    {
        private static readonly List<StudentsInfoDTO> studentsInfoDTOs;

        static StudentsInfoRepositoryList()
        {
            studentsInfoDTOs = new List<StudentsInfoDTO>();

            studentsInfoDTOs.Add(new StudentsInfoDTO()
            {
                Id = Guid.NewGuid(),
                FamilyName = "Johnson",
                DateOfBirth = DateTime.Now.AddYears(new Random().Next(-50, -20)),
                GeneralGrade = new Random().Next(1, 101),
                Nationality = "Canada"
            });

            studentsInfoDTOs.Add(new StudentsInfoDTO()
            {
                Id = Guid.NewGuid(),
                FamilyName = "Maersk",
                DateOfBirth = DateTime.Now.AddYears(new Random().Next(-50, -20)),
                GeneralGrade = new Random().Next(1, 101),
                Nationality = "CANADIAN"
            });
        }

        public Guid AddStudentsInfoDTO(StudentsInfoDTO studentsInfoDTO)
        {
            studentsInfoDTO.Id = Guid.NewGuid();
            studentsInfoDTOs.Add(studentsInfoDTO);

            return studentsInfoDTO.Id;
        }

        public IEnumerable<StudentsInfoDTO> GetAll()
        {
            return studentsInfoDTOs;
        }

        public StudentsInfoDTO GetById(Guid id)
        {
            return studentsInfoDTOs.FirstOrDefault(x => x.Id == id);
        }

        public bool RemoveStudentsInfoDTO(Guid id)
        {
            var elToBeRemoved = GetById(id);
            var result = false;
            if (elToBeRemoved != null)
            {
                studentsInfoDTOs.Remove(elToBeRemoved);
                result = true;
            }

            return result;
        }

        public bool Update(StudentsInfoDTO studentsInfoDTO)
        {
            var result = false;
            var elToBeEdited = GetById(studentsInfoDTO.Id);
            if (elToBeEdited != null)
            {
                RemoveStudentsInfoDTO(elToBeEdited.Id);
                studentsInfoDTOs.Add(studentsInfoDTO);
                result = true;
            }

            return result;
        }
    }
}
