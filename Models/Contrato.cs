using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DignitaTask.Models
{
    public class Contrato : Empresa
    {
        public int IdContrato { get; set; }
        public float Costo {  get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin {  get; set; }
        public bool InhabilitadoContrato { get; set; }
    }
}