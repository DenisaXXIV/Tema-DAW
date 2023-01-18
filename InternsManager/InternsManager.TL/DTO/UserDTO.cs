using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternsManager.TL.DTO
{
    public class UserDTO
    {
        public int IdUser { get; set; }
        public int IdPerson { get; set; }
        public int IdRole { get; set; }
        public string Username { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
    }
}
