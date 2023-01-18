using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternsManager.TL.DTO
{
    public class InternshipDTO
    {
        public int IdInternship { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string SalaryBRUT { get; set; }
        public string Position { get; set; }
    }
}
