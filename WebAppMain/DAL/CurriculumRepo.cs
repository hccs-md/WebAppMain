using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppMain.Interfaces;
using WebAppMain.Models;

namespace WebAppMain.DAL
{
    public class CurriculumRepo : ICurriculum, IDisposable
    {
        private MyDbContext db = null;
        public CurriculumRepo()
        {
            db = new MyDbContext();
            db.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }
        
        public void Add(Textbook t)
        {
            db.Textbooks.Add(t);
            db.SaveChanges();
        }

        public void Add(Classroom t)
        {
            db.Classrooms.Add(t);
            db.SaveChanges();
        }

        public IEnumerable<Classroom> AllClassroooms()
        {
            return db.Classrooms.ToList();
        }

        public IEnumerable<Person> AllTeachers(string schoolyear)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Textbook> AllTextbooks()
        {
            return db.Textbooks.ToList();
        }

        public void Dispose()
        {
            if(db != null)
            {
                db.Dispose();
            }
        }

        public void Edit(Textbook t)
        {            
            throw new NotImplementedException();
        }

        public void Edit(Classroom t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetCoursesBySchoolYear(string schoolyear)
        {
            return db.Courses.Where( c => c.SchoolYear == schoolyear ).ToList();
        }

        public IEnumerable<Contact> GetTeacherContactsBySchooYear(string schoolyear)
        {
            DateTime thisYear = new DateTime(ExtractStartYear(schoolyear), 1, 1);
            var contacts = from c in db.Contacts
                           join h in db.HccsRoles on c.PersonID equals h.PersonID
                           where h.HccsRoleEffEndDt > thisYear && c.ContactEffEndDt == new DateTime(9999, 12, 31)
                           select c;
            return contacts.ToList();
        }
        public IEnumerable<Person> GetTeachersBySchoolYear(string schoolyear)
        {
            DateTime thisYear = new DateTime(ExtractStartYear(schoolyear), 1, 1);
            //var c1 = db.People.ToList();
            //var c2 = db.HccsRoles.ToList();
            var teachers = from p in db.People
                          join h in db.HccsRoles on p.PersonID equals h.PersonID
                          where p.PersonType==0 && h.HccsRoleEffEndDt > thisYear
                          select p;
            if (teachers != null)
                return teachers.ToList<Person>();
            else
                return null;
        }

        public CurriculumViewModel1 GetCurriculumsBySchoolYear(string schoolyear)
        {
            CurriculumViewModel1 vm = new CurriculumViewModel1 { SchoolYear = schoolyear };
            var lll = new List<CurriculumsByCampus>();
            string spStmt = string.Format("call registration_get_curriculum_by_schoolyear_semester('{0}', 'fullyear')", schoolyear);
            List<CurriculumDTO> data = db.Database.SqlQuery<CurriculumDTO>(spStmt).ToList();
            foreach (string campus in new string[]{ "HCC", "CCBC"})
            {
                CurriculumsByCampus cbc = new CurriculumsByCampus { Campus = campus };

                var clst = new List<CurriculumByType>();

                foreach (int cat in new int[] { 0, 1, 2, 3, 4 })
                {
                    var cbt = new CurriculumByType { id = cat };
                    
                    var typedCur = from d in data
                                   where d.campus == campus && d.coursetype == cat
                                   select new CurriculumsByCampusNType
                                   {
                                       AgeLimit = d.minimumage,
                                       BookFee = d.unitPrice,
                                       BookNameChinese = d.bookchinese,
                                       BookNameEnglish = d.bookenglish,
                                       Capacity = d.capacity,
                                       ChineseName = d.classnamechinese,
                                       ClassTime = d.classtime,
                                       EnglishName = d.classnameenglish,
                                       RegistrationFee = d.registrationFee,
                                       Room = d.classroomid,
                                       TeacherChinese = d.chineseName,
                                       TeacherEnglish = string.Format("{0} {1}", d.firstName, d.lastName),
                                       TeacherEmail = d.email,
                                       Tuition = d.tuition,                                       
                                   };
                    var lst = new List<CurriculumsByCampusNType>();
                    lst.AddRange(typedCur.ToList());
                    cbt.typedCurriculums = lst;

                    clst.Add(cbt);
                }
                cbc.ListCurriculumsByType = clst;
                lll.Add(cbc);
            }
            vm.ListCampus = lll;

            return vm;
        }
        
        public IEnumerable<Schedule> GetSchedulesBySchoolYear(string schoolyear)
        {
            return db.Schedules.Where(r =>
                db.Courses.Where( c => c.SchoolYear==schoolyear).Select( c => c.CourseID ).Contains( r.CourseID )
            ).ToList();
        }

        private static int ExtractStartYear(string schoolyear)
        {
            var fields = schoolyear.Split(new char[] { '-' });
            return Convert.ToInt32(fields[0]);
        }
    }
}