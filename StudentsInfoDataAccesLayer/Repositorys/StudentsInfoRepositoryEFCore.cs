using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Repositorys
{
    public class StudentsInfoRepositoryEFCore : IStudentsInfoRepository
    {
        private readonly EFCoreContext dBContext;

        public StudentsInfoRepositoryEFCore(EFCoreContext eFCoreContext)
        {
            dBContext = eFCoreContext;

            if (!dBContext.StudentsInfos.Any())
            {
                dBContext.StudentsInfos.Add(new StudentsInfoDTO()
                {
                    Id = Guid.NewGuid(),
                    FamilyName = "Kumar",
                    DateOfBirth = DateTime.Now.AddYears(new Random().Next(-50, -20)),
                    GeneralGrade = new Random().Next(1, 101),
                    Nationality = "Indian"
                });

                dBContext.StudentsInfos.Add(new StudentsInfoDTO()
                {
                    Id = Guid.NewGuid(),
                    FamilyName = "Maersk",
                    DateOfBirth = DateTime.Now.AddYears(new Random().Next(-50, -20)),
                    GeneralGrade = new Random().Next(1, 101),
                    Nationality = "CANADIAN"
                });
                dBContext.SaveChanges();
            }
        }

        public Guid AddStudentsInfoDTO(StudentsInfoDTO studentsInfoDTO)
        {
            studentsInfoDTO.Id = Guid.NewGuid();
            dBContext.StudentsInfos.Add(studentsInfoDTO);
            dBContext.SaveChanges();

            return studentsInfoDTO.Id;
        }

        public IEnumerable<StudentsInfoDTO> GetAll()
        {
            return dBContext.StudentsInfos.ToList();
        }

        public StudentsInfoDTO GetById(Guid id)
        {
            return dBContext.StudentsInfos.FirstOrDefault(x => x.Id == id);
        }

        public bool RemoveStudentsInfoDTO(Guid id)
        {
            var elToBeRemoved = GetById(id);
            var result = false;
            if (elToBeRemoved != null)
            {
                dBContext.StudentsInfos.Remove(elToBeRemoved);
                dBContext.SaveChanges();
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
                dBContext.StudentsInfos.Add(studentsInfoDTO);
                dBContext.SaveChanges();
                result = true;
            }

            return result;
        }
    }
}
