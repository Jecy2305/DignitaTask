using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DignitaTask.Models
{
    public class Trabajador
    {
        public int Dni { get; set; }
        public string Email { get; set; }
        public string Password{ get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }

        public int Rol {  get; set; }
        
    }
}