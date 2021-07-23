using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsInfoDataAccesLayer
{
    public interface IStudentsInfoRepository
    {
        Guid AddStudentsInfoDTO(StudentsInfoDTO studentsInfoDTO);
        StudentsInfoDTO GetById(Guid id);
        IEnumerable<StudentsInfoDTO> GetAll();
        bool Update(StudentsInfoDTO studentsInfoDTO);
        bool RemoveStudentsInfoDTO(Guid id);
    }
}
