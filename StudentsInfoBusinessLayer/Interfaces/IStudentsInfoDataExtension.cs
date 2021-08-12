using System;

namespace BusinessLayer.Interfaces
{
    interface IStudentsInfoDataExtension
    {
        public char GetGradeMark(int generalGrade);
        int GetCurentAge(DateTime dateOfBirth);
        bool IsCanadianResident(string nationality);
    }
}
