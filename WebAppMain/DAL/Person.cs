using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppMain.DAL
{
    public class Person
    {
        private DateTime _begDt;
        private DateTime? _endDt = null;
        private DateTime? _dob = null;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("personID", Order = 1)]
        public int PersonID { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("personEffBegDt", Order = 2)]
        public DateTime PersonEffBegDt {
            get {
                return _begDt;
            }
            set
            {
                DateTime dt;
                if(DateTime.TryParse(Convert.ToString(value), out dt))
                {
                    _begDt = dt;
                }
                else
                {
                    _begDt = DateTime.MinValue;
                }
            }
        }
        public DateTime? PersonEffEndDt {
            get
            {
                return _endDt;
            }
            set
            {
                DateTime dt = DateTime.MaxValue;
                if(DateTime.TryParse(Convert.ToString(value), out dt))
                {
                    _endDt = dt;
                }
                else
                {
                    _endDt = null;
                }
            }
        }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string ChineseName { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate {
            get
            {
                return _dob;
            }
            set
            {
                DateTime dt = DateTime.MaxValue;
                if(DateTime.TryParse(Convert.ToString(value), out dt))
                {
                    _dob = dt;
                }
                else
                {
                    _dob = null;
                }
            }
        }
        public int PersonType { get; set; }
        public DateTime CreationDt { get; set; }
    }
}