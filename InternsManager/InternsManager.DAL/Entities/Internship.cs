using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternsManager.DAL.Entities
{
    public class Internship
    {
        [Required]
        [Key]
        public int IdInternship { get; set; }

        [Required(ErrorMessage = "*** Name Err ***")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*** StartDate Err ***")]
        public string StartDate { get; set; }

        [Required(ErrorMessage = "*** EndDate Err ***")]
        public string EndDate { get; set; }

        [Required(ErrorMessage = "*** SalaryBRUT Err ***")]
        public string SalaryBRUT { get; set; }

        [Required(ErrorMessage = "*** Position Err ***")]
        public string Position { get; set; }
    }
}
