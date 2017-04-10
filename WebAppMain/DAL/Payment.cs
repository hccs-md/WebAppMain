using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppMain.DAL
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        public int ObligationID { get; set; }
        public int FamilyID { get; set; }
        public byte PaymentMethod { get; set; }
        public string CheckNum { get; set; }
        public float Amount { get; set; }
        public string Note { get; set; }
        public DateTime ReceivedDate { get; set; }
        public DateTime ProcessedDate { get; set; }
        public byte Processed { get; set; }
        public int UpdatedByID { get; set; }
        public byte Confirmed { get; set; }
        public DateTime ConfirmedDate { get; set; }
        public int ConfirmedByID { get; set; }
    }
}