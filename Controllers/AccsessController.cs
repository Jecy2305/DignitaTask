using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DignitaTask.Models;

namespace DignitaTask.Controllers
{
    public class AccsessController : Controller
    {

        static string conection = "Data Source = LAPTOP-BFK427HA\\SQL; Initial Catalog = DB_DIGNITA; Integrated Security = true"; 

        // GET: Accsess
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Trabajador oUsuario)
        {
            using (SqlConnection cn = new SqlConnection(conection))
            {
                SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", cn);
                cmd.Parameters.AddWithValue("Correo", oUsuario.Email);
                cmd.Parameters.AddWithValue("Clave", oUsuario.Password);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                
                oUsuario.Dni = (Int16)cmd.ExecuteScalar();
            }

            if (oUsuario.Dni != 0)
            {
                return RedirectToAction("Home","Contact"); 
            }


            return View();
        }
    }
}