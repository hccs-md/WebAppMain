using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppMain.DAL
{
    public class Invoice
    {
        [Key]
        [Column("InvoiceID", Order=1)]
        public int InvoiceID { get; set; }
        public DateTime InvoiceDt { get; set; }
        public int FamilyID { get; set; }
        [Key]
        [Column("InvoiceEffBegDt", Order =2)]
        public DateTime InvoiceEffBegDt { get; set; }
        public DateTime? InvoiceEffEndDt { get; set; }
        public string SchoolYear { get; set; }
        public string Semester { get; set; }
        public byte PaymentStatus { get; set; }
        public DateTime? PaymentDate { get; set; }
        public float PaymentAmount { get; set; }
        public float TotalBalanceAmount { get; set; }
        public string InvoiceNotes { get; set; }
        public int UpdatedByID { get; set; }
    }
}