using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Triario.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id_Num { get; set; }
        public int CC { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string EUser { get; set; }
        public string Email { get; set; }
        public Decimal Salary { get; set; }
        public string Fk_Department { get; set; }

    }
}