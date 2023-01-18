using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternsManager.DAL.Entities
{
    public class Role
    {
        [Required]
        [Key]
        public int IdRole { get; set; }

        [Required(ErrorMessage = "*** RoleName Err ***")]
        public string RoleName { get; set; }

    }
}
