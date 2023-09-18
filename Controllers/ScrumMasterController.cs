using DignitaTask.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DignitaTask.Services;
using DignitaTask.Filters;

namespace DignitaTask.Controllers
{
    [ValidateSession]
    public class ScrumMasterController : Controller
    {
        //Singleton
        private static DatabaseConnection dbConnection = DatabaseConnection.Instancia;

        //GET : Default
        public ActionResult Proyectos()
        {

            return View();
        }

        public ActionResult Requerimientos()
        {

            return View();
        }

        public ActionResult Tareas()
        {

            return View();
        }

        public ActionResult Versiones()
        {

            return View();
        }


        public static List<Proyecto> ListadoProyectosContratados()
        {
            List<Proyecto> proyectos = new List<Proyecto>();
            try
            {
                using (SqlConnection cn = dbConnection.Conectar())
                {
                    SqlCommand cmd = new SqlCommand("ListarProyectosContratados", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Proyecto p = new Proyecto();
                        p.NombreProyecto = (dr["nombre_proy"]).ToString();
                        p.RazonSocial = (dr["razon_social"]).ToString();
                        p.NombreEstadoProyecto = (dr["nombre_estado"]).ToString();
                        p.Fecha_Fin = Convert.ToDateTime(dr["fecha_fin"]).Date;
                        proyectos.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {
                // Maneja la excepción o registra el error según tus necesidades
                Console.WriteLine("Error al obtener la lista de proyectos: " + ex.Message);
            }
            return proyectos;
        }
    }
}