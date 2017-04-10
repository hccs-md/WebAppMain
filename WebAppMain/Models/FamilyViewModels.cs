using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppMain.DAL;

namespace WebAppMain.Models
{
    public class FamilyViewModels
    {
        public Person HeadOfFamily { get; set; }
        public IEnumerable<Person> FamilyMembers { get; set; }
        public IEnumerable<Enrollment> Enrolled { get; set; }
        public IEnumerable<Invoice> Invoiced { get; set; }
        public IEnumerable<Payment> Payments { get; set; }
    }
}