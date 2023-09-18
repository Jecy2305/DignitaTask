using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DignitaTask.Models
{
    public class Empresa : EstadoProyecto
    {
        public string RazonSocial { get; set; }
        public string RucEmpresa { get; set; }
        public string Rubro { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public bool InhabilitadoEmpresa { get; set; }
    }
}