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

namespace DignitaTask.Controllers
{
    public class DefaultController : Controller
    {

        static string conection = "Data Source = LAPTOP-BFK427HA\\SQL; Initial Catalog = DB_DIGNITA; Integrated Security = true";

        // GET: Default
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Trabajador oTrabajador)
        {
            using (SqlConnection cn = new SqlConnection(conection))
            {
                SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", cn);
                cmd.Parameters.AddWithValue("Correo", oTrabajador.Email);
                cmd.Parameters.AddWithValue("Clave", oTrabajador.Password);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                oTrabajador.Dni = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            }

            if (oTrabajador.Dni != 0)
            {
                Session["trabajador"] = oTrabajador;
                return RedirectToAction("Contact", "Home");
            }
            else
            {
                ViewData["Mensaje"] = "Trabajador no encontrado";
                return RedirectToAction("Login", "Default");
            }
        }
    }
}