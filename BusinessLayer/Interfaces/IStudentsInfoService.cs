using System;
using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    public interface IStudentsInfoService
    {
        Guid AddStudentsInfo(StudentsInfo studentsInfo);
        StudentsInfo GetById(Guid id);
        IEnumerable<StudentsInfo> GetAll();
        bool Update(StudentsInfo studentsInfo);
        bool RemoveStudentsInfo(Guid id);
        bool RemoveAllStudentsInfo();
    }
}
