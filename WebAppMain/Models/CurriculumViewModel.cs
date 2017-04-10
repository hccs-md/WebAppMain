using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppMain.DAL;

namespace WebAppMain.Models
{
    public class CurriculumViewModel
    {
        public string SchoolYear { get; set; }
        public IEnumerable<Schedule> SchedulesInThisYear { get; set; }
        public IEnumerable<Person> TeachersInThisYear { get; set; }
        public IEnumerable<Course> CoursesInThisYear { get; set; }
        public IEnumerable<Contact> TeacherContacts { get; set; }
        public IEnumerable<Textbook> BooksInThisYear { get; set; }
        public IEnumerable<Classroom> RoomsInThisYear { get; set; }
    }

    public class CurriculumViewModel1
    {
        public string SchoolYear { get; set; }

        public IEnumerable<CurriculumsByCampus> ListCampus { get; set; }
    }

    public class CurriculumsByCampus
    {
        public string Campus { get; set; }

        public IEnumerable<CurriculumByType> ListCurriculumsByType { get; set; }
    }

    public class CurriculumByType
    {
        public int id { get; set; }
        public IEnumerable<CurriculumsByCampusNType> typedCurriculums { get; set; }
    }
    public class CurriculumsByCampusNType
    { 
        public string EnglishName { get; set; }
        public string ChineseName { get; set; }
        public string ClassTime { get; set; }
        public string Room { get; set; }
        public string TeacherEnglish { get; set; }
        public string TeacherChinese { get; set; }
        public string TeacherEmail { get; set; }
        public string BookNameEnglish { get; set; }
        public string BookNameChinese { get; set; }
        public int RegistrationFee { get; set; }
        public int Tuition { get; set; }
        public int BookFee { get; set; }
        public int Capacity { get; set; }
        public int? AgeLimit { get; set; }
    }

    public class CurriculumDTO
    {
        public int perferredseqnum { get; set; }
        public int numofunits { get; set; }
        public string courseid { get; set; }
        public int? minimumage { get; set; }
        public string coursenameenglish { get; set; }
        public string coursenamechinese { get; set; }
        public int coursetype { get; set; }
        public int teacherid { get; set; }
        public int textbookid { get; set; }
        public string  classroomid { get; set; }
        public int capacity { get; set; }
        public string classtime { get; set; }
        public string classnamechinese { get; set; }
        public string classnameenglish { get; set; }
        public string campus { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string chineseName { get; set; }
        public string email { get; set; }

        public string bookenglish { get; set; }
        public string bookchinese { get; set; }
        public int unitPrice { get; set; }
        public int registrationFee { get; set; }
        public int tuition { get; set; }
    }
}