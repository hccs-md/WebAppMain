using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppMain.DAL
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("familyID", Order = 1)]
        public int FamilyID { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("addressEffBegDt", Order = 2)]
        public DateTime AddressEffBegDt { get; set; }
        public DateTime? AddressEffEndDt { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}