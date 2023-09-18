using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DignitaTask.Models
{
    public class Proyecto : Contrato
    {
        public int IdProyecto { get; set; }
        public string NombreProyecto { get; set; }
        public int TipoProyecto { get; set; }
        public bool Contratado { get; set; }
        public bool Asignado { get; set; }
        public bool InhabilitadoProyecto { get; set; }
        public string Descripcion { get; set; }
    }
}