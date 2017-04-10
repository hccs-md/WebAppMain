using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMain.DAL;

namespace WebAppMain.Interfaces
{
    public interface IFamily
    {
        void Add(Person p);
        void Edit(Person p);

        void Add(Contact c);
        void Edit(Contact c);

        void Add(Address a);
        void Edit(Address a);

        IEnumerable<Registration> GetEnrollmentBySchoolYear(string schoolYear, string semster="Fullyear");

        void Enroll(List<Enrollment> enrollments);
        void GenerateInvoice(string schoolyear, string semester = "Fullyear");       
    }
}
