using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMain.DAL;

namespace WebAppMain.Interfaces
{
    public interface ICurriculum
    {
        void Add(Textbook t);
        void Edit(Textbook t);

        void Add(Classroom t);
        void Edit(Classroom t);
        IEnumerable<Classroom> AllClassroooms();

        IEnumerable<Textbook> AllTextbooks();

        IEnumerable<Person> AllTeachers(string schoolyear);
        IEnumerable<Course> GetCoursesBySchoolYear(string schoolyear);
        IEnumerable<Schedule> GetSchedulesBySchoolYear(string schoolyear);
    }
}
