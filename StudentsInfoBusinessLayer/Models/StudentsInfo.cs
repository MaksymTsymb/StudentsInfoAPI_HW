using System;

namespace BusinessLayer
{
    public class StudentsInfo
    {
        public Guid Id { get; set; }
        public string FamilyName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int GeneralGrade { get; set; }
        public string Nationality { get; set; }
        public bool CanadianResident { get; set; }
        public char GradeMark { get; set; }
        public int CurentAge { get; set; }
    }
}
