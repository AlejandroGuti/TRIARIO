using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Triario.Models.ViewModels
{
    public class JoinViewModel
    {
        [Key]
        public int id { get; set; }
        public int CC { get; set; }
        public string FullName { get; set; }
        public string DName { get; set; }
        public decimal Salary { get; set; }
        public decimal PSalary { get; set; }
    }
}