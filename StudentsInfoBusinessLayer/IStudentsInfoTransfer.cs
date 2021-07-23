using StudentsInfoDataAccesLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsInfoBusinessLayer
{
    interface IStudentsInfoTransfer
    {
        StudentsInfoDTO StudentsInfoToStudentsInfoDTO(StudentsInfo studentsInfo);
        StudentsInfo StudentsInfoDTOToStudentsInfo(StudentsInfoDTO studentsInfoDTO);
    }
}
