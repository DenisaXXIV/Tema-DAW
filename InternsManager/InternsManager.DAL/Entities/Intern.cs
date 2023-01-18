using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternsManager.DAL.Entities
{
    public class Intern
    {
        [Required]
        [Key]
        public int IdIntern { get; set; }

        [Required(ErrorMessage = "*** Person Err ***")]
        [ForeignKey("Person")]
        public int IdPerson { get; set; }

        [Required(ErrorMessage = "*** Internship Err ***")]
        [ForeignKey("Internship")]
        public int IdInternship { get; set; }

        [Required(ErrorMessage = "*** VacationDays Err ***")]
        public int VacationDays { get; set; }
    }
}
