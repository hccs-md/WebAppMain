using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppMain.DAL
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(16)]
        public string CourseID { get; set; }
        public string CourseNameEnglish { get; set; }
        public string CourseNameChinese { get; set; }
        public int CourseType { get; set; }
        public float RegistrationFee { get; set; }
        public float Tuition { get; set; }
        public string SchoolYear { get; set; }
        public string Semester { get; set; }
        public int PreferredSeqNum { get; set; }
        public int? MinimumAge { get; set; }

    }
}