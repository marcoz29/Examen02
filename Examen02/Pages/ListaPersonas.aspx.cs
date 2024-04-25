using Examen02.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen02.Pages
{
    public partial class ListaPersonas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                using (PV_Examen02Entities db = new PV_Examen02Entities())
                {
                    var Lista = db.spConsultarTodasLasPersonas().ToList();

                    GvListarPersonas.DataSource = Lista;
                    GvListarPersonas.DataBind();
                }
            }
            catch
            {

            }
        }

        protected int CalcularEdad(DateTime fechaNacimiento)
        {
            int edad = DateTime.Now.Year - fechaNacimiento.Year;

            if (DateTime.Now.DayOfYear < fechaNacimiento.DayOfYear)
            {
                edad--;
            }
            return edad;
        }

        protected string CalcularGeneracion(DateTime fechaNacimiento)
        {
            int generacion = fechaNacimiento.Year;
            if (generacion >= 1994 && generacion <= 2010)
            {
                return "Generación z";
            }
            else if (generacion >= 1981 && generacion <= 1993)
            {
                return "Generación Y";
            }
            else if (generacion >= 1969 && generacion <= 1980)
            {
                return "Generación X";
            }
            else if (generacion >= 1949 && generacion <= 1968)
            {
                return "Generación Baby Boomers";
            }
            else if (generacion >= 1930 && generacion <= 1948)
            {
                return "Generación silenciosa";
            }
            return String.Empty;
        }
    }
}