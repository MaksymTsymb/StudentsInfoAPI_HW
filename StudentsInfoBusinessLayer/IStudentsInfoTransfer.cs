using StudentsInfoDataAccesLayer;
using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Class implementing current interface is no longer in use
/// </summary>
namespace StudentsInfoBusinessLayer
{
    interface IStudentsInfoTransfer
    {
        StudentsInfoDTO StudentsInfoToStudentsInfoDTO(StudentsInfo studentsInfo);
        StudentsInfo StudentsInfoDTOToStudentsInfo(StudentsInfoDTO studentsInfoDTO);
    }
}
