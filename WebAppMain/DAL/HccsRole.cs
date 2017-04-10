using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppMain.DAL
{
    public class HccsRole
    {
        [Key]
        [Column("personID", Order=1)]
        public int PersonID { get; set; }
        public int hccsRole { get; set; }
        [Key]
        [Column("hccsRoleEffBegDt", Order = 2)]
        public DateTime HccsRoleEffBegDt { get; set; }
        public DateTime? HccsRoleEffEndDt { get; set; }
        public string SchoolYear { get; set; }
        public string Semester { get; set; }
        public string HccsTitleEnglish { get; set; }
        public string HccsTitleChinese { get; set; }
    }
}