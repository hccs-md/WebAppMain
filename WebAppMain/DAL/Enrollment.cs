using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppMain.DAL
{
    public class Enrollment
    {
        public Person Person { get; set; }
        public IEnumerable<Registration> Registrations { get; set; }
    }
}