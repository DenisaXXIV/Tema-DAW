using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternsManager.DAL.Entities
{
    public class Person
    {
        [Required]
        [Key]
        public int IdPerson { get; set; }

        [Required(ErrorMessage = "*** Name Err ***")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*** Date of Birth Err ***")]
        public string DateOfBirth { get; set; }

        [Required(ErrorMessage = "*** Gender Err ***")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "*** Pictures Err ***")]
        public string? PicPath { get; set; }
    }
}
