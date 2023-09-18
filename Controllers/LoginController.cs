using DignitaTask.Filters;
using DignitaTask.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DignitaTask.Services;

namespace DignitaTask.Controllers
{

    public class LoginController : Controller
    {
        //Singleton
        private static DatabaseConnection dbConnection = DatabaseConnection.Instancia;


        // GET: Default
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Trabajador oTrabajador)
        {
            using (SqlConnection cn = dbConnection.Conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_ValidarTrabajador", cn);
                cmd.Parameters.AddWithValue("Correo", oTrabajador.Email);
                cmd.Parameters.AddWithValue("Clave", oTrabajador.Password);

                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                oTrabajador.Rol = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            }

            if (oTrabajador.Rol == 1)   
            {
                Session["session"] = oTrabajador;
                return RedirectToAction("Proyectos", "ScrumMaster");
            }

            else if (oTrabajador.Rol == 3)
            {
                Session["session"] = oTrabajador; 
                return RedirectToAction("Contratos", "Ventas");
            }

            else
            {
                ViewData["session"] = "Trabajador no encontrado";
                return RedirectToAction("Login", "Login");
            }
        }


       

        
    }
}