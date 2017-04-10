using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppMain.DAL
{
    public class Contact
    {
        [Key]
        [Column("personID", Order = 1)]
        public int PersonID { get; set; }
        [Key]
        [Column("contactEffBegDt", Order = 2)]
        public DateTime ContactEffBegDt { get; set; }
        public DateTime? ContactEffEndDt { get; set; }
        public string Email { get; set; }
        public string IsOnEmailList { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string CellPhone { get; set; }
    }
}