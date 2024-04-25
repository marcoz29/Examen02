using Examen02.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen02.Pages
{
    public partial class CrearPersona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenarPersona();
            }
        }

        private void LlenarPersona()
        {
            try
            {
                var ListaPersonas = new List<ListItem>();

                using (PV_Examen02Entities db = new PV_Examen02Entities())
                {
                    var query = (from lr in db.spConsultarTodasLasProvincias()
                                 select new ListItem
                                 {
                                     Value = lr.idProvincia.ToString(),
                                     Text = lr.nombre.ToString()
                                 }).ToList();

                    ListaPersonas.AddRange(query);
                    DdProvincias.DataTextField = "Text";
                    DdProvincias.DataValueField = "Value";

                    DdProvincias.DataSource = ListaPersonas;
                    DdProvincias.DataBind();
                }
            }
            catch 
            {
                Response.Redirect("~/Pages/Error.aspx");
            }
        }
        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            int idProvincia = Convert.ToInt32(DdProvincias.SelectedItem.Value);
            string nombre = TxtNombre.Text.Trim();
            string telefono = TxtTelefono.Text.Trim();
            DateTime nacimiento = DateTime.Parse(TxtNacimiento.Text.Trim());
            decimal salario = decimal.Parse(TxtSalario.Text.Trim());

            try
            {
                using(PV_Examen02Entities db = new PV_Examen02Entities())
                {
                    db.spCrearPersona(idProvincia, nombre, telefono, nacimiento, salario);
                }
            }
            catch 
            {
                Response.Redirect("~/Pages/Error.aspx");
            }

            Response.Redirect("~/Pages/Mensaje.aspx");
        }

        protected void BtnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/ListaPersonas");
        }
    }
}