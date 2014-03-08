using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISWII.Models
{
    public class Recomend
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string telephone{ get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string commentary { get; set; }
    }
}