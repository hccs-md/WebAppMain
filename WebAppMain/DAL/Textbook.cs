using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppMain.DAL
{
    public class Textbook
    {
        [Key]
        public int TextbookID { get; set; }
        public string BookTitleEnglish { get; set; }
        public string BookTitleChinese { get; set; }
        public int? UnitPrice { get; set; }
    }
}