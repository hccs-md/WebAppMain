using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppMain.DAL
{
    public class Classroom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(16)]
        public string ClassroomID { get; set; }
        public string RoomNum { get; set; }
        public string Building { get; set; }
        public string Campus { get; set; }
        public int? Capacity { get; set; }
    }
}