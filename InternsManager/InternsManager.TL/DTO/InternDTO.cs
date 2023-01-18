using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternsManager.TL.DTO
{
    public class InternDTO
    {
        public int IdIntern { get; set; }
        public int IdPerson { get; set; }
        public int IdInternship { get; set; }
        public int VacationDays { get; set; }
    }
}
