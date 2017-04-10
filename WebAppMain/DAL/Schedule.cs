using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppMain.DAL
{
    public class Schedule
    {
        [Key]
        public int ScheduleID { get; set; }
        public string ClassNameEnglish { get; set; }
        public string ClassNameChinese { get; set; }
        public string CourseID { get; set; }
        public int TeacherID { get; set; }
        public int TextbookID { get; set; }
        public string ClassroomID { get; set; }
        public int Capacity { get; set; }
        public string ClassTime { get; set; }
        public float ClassStartTime { get; set; }
        public float ClassEndTime { get; set; }
        public int WaitingListLimit { get; set; }
    }
}