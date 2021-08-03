using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    interface IStudentsInfoDataExtension
    {
        public char GetGradeMark(int generalGrade);
        int GetCurentAge(DateTime dateOfBirth);
        bool IsCanadianResident(string nationality);
    }
}
