using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsInfoBusinessLayer
{
    class StudentsInfoDataExtension : IStudentsInfoDataExtension
    {
        public int GetCurentAge(DateTime dateOfBirth)
        {
            int result = DateTime.Now.Year - dateOfBirth.Year;
            return result;
        }

        public char GetGradeMark(int generalGrade)
        {
            char gradeMark;

            if (generalGrade > 80) gradeMark = 'A';
            else if (generalGrade > 60) gradeMark = 'B';
            else if (generalGrade > 40) gradeMark = 'C';
            else if (generalGrade > 20) gradeMark = 'D';
            else gradeMark = 'E';

            return gradeMark;
        }

        public bool IsNativeResident(string nationality)
        {
            bool result = false;
            string inputNationalityLowCase = nationality.ToLower();
            string[] expectedNationality = new string[]
            {
                "canadian",
                "canada",
                "can",
                "ca"
            };

            foreach (var el in expectedNationality)
            {
                if (el == inputNationalityLowCase)
                {
                    result = true;
                }
            }

            return result;
        }
    }
}
