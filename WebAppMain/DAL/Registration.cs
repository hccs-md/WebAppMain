using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppMain.DAL
{
    public class Registration
    {
        [Key]
        [Column("RegistrationID", Order=1)]
        public int RegistrationID { get; set; }
        [Key]
        [Column("EffBegDtTime", Order =2)]
        public DateTime EffBegDtTime { get; set; }
        public DateTime? EffEndDtTime { get; set; }
        public int ScheduleID { get; set; }     
        public int PersonID { get; set; }
        public DateTime CreationDt { get; set; }
        public int InvoiceID { get; set; }
        public float RegistrationFeeAmount { get; set; }
        public float TuitionAmount { get; set; }
        public float MiddleWayTuitionDiscount { get; set; }
        public float ECOrTeacherDiscount { get; set; }
        public float? TextbookAmount { get; set; }
        public char TextbookNeeded { get; set; }
        public byte RegistrationStatus { get; set; }
        public int UpdatedByID { get; set; }
    }
}