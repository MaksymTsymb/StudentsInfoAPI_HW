using System;

namespace DataAccessLayer
{
    public class StudentsInfoDTO
    {
        public Guid Id { get; set; }
        public string FamilyName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int GeneralGrade { get; set; }
        public string Nationality { get; set; }
    }
}
