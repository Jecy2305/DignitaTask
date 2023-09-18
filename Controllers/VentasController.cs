using DignitaTask.Filters;
using DignitaTask.Models;
using DignitaTask.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DignitaTask.Controllers
{
    [ValidateSession]
    public class VentasController : Controller
    {

        //Singleton
        private static DatabaseConnection dbConnection = DatabaseConnection.Instancia;

        // GET: Ventas
        public ActionResult Contratos()
        {
            return View();
        }

        public ActionResult Empresas()
        {
            return View();
        }

        public static List<Proyecto> ListadoProyectos()
        {
            List<Proyecto> proyectos = new List<Proyecto>();
            try
            {
                using (SqlConnection cn = dbConnection.Conectar())
                {
                    SqlCommand cmd = new SqlCommand("spListarProyectos", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Proyecto p = new Proyecto();
                        p.NombreProyecto = (dr["nombre_proy"]).ToString();
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

       
        public static List<Empresa> ListadoEmpresas()
        {
            List<Empresa> empresa = new List<Empresa>();
            try
            {
                using (SqlConnection cn = dbConnection.Conectar())
                {
                    SqlCommand cmd = new SqlCommand("spListaEmpresa", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Empresa em = new Empresa();
                        em.RazonSocial = (dr["razon_social"]).ToString();
                        em.RucEmpresa = (dr["RUC"]).ToString();
                        em.Rubro = (dr["rubro"]).ToString();
                        em.Correo = (dr["correo"]).ToString();
                        empresa.Add(em);
                    }
                }
            }
            catch (Exception ex)
            {
                // Maneja la excepción o registra el error según tus necesidades
                Console.WriteLine("Error al obtener la lista de proyectos: " + ex.Message);
            }
            return empresa;
        }

        [HttpPost]
        public ActionResult InsertarEmpresa(Empresa e)
        {
            try
            {
                using (SqlConnection cn = dbConnection.Conectar())
                {
                    SqlCommand cmd = new SqlCommand("spInsertaEmpresa", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RUC", e.RucEmpresa);
                    cmd.Parameters.AddWithValue("@razon_social", e.RazonSocial);
                    cmd.Parameters.AddWithValue("@rubro", e.Rubro);
                    cmd.Parameters.AddWithValue("@direccion", e.Direccion);
                    cmd.Parameters.AddWithValue("@telefono", e.Telefono);
                    cmd.Parameters.AddWithValue("@correo", e.Correo);
                    cn.Open();
                    cmd.ExecuteNonQuery();

                }
                    
            }
            catch (Exception ex)
            {
                // Maneja la excepción o registra el error según tus necesidades
                Console.WriteLine("Error al insertar empresa: " + ex.Message);
                throw ex;
            }

            return RedirectToAction("Empresas", "Ventas");
        }
    }
}