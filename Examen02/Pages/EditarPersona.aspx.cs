using Examen02.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen02.Pages
{
    public partial class EditarPersona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                CargarInformacionPersona();
                LlenarProvincia();
            }
        }

        private void CargarInformacionPersona()
        {
            int idPersona = Convert.ToInt32(Request.QueryString["id"]);

            try
            {
                using(PV_Examen02Entities db = new PV_Examen02Entities())
                {
                    var datosPersona = db.spConsultarPersonaPorId(idPersona).FirstOrDefault();

                    if (datosPersona != null) 
                    {
                        TxtNombre.Text = datosPersona.nombreCompleto;
                        TxtTelefono.Text = datosPersona.telefono;
                        TxtNacimiento.Text = datosPersona.fechaNacimiento.ToString();
                        TxtSalario.Text = datosPersona.salario.ToString();

                        string idProvincia = datosPersona.idProvincia.ToString();

                        DdProvincias.SelectedValue = idProvincia;
                    }
                }
            }
            catch 
            {
                Response.Redirect("~/Pages/Error.aspx");
            }
        }
        private void LlenarProvincia()
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

        protected void BtnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/ListaPersonas.aspx");
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int idPersona = Convert.ToInt32(Request.QueryString["id"]);
                int idProvincia = Convert.ToInt32(DdProvincias.Text.Trim());
                string nombre = TxtNombre.Text.Trim();
                string telefono = TxtTelefono.Text.Trim();
                DateTime nacimiento = DateTime.Parse(TxtNacimiento.Text.Trim());
                decimal salario = decimal.Parse(TxtSalario.Text.Trim());

                using(PV_Examen02Entities db = new PV_Examen02Entities())
                {
                    db.spEditarPersona(idPersona, idProvincia, nombre, telefono, nacimiento, salario);
                }
            }
            catch
            {
                Response.Redirect("~/Pages/Error.aspx");
            }
            Response.Redirect("~/Pages/MensajeEditar.aspx");
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int idPersona = Convert.ToInt32(Request.QueryString["id"]);

                using(PV_Examen02Entities db= new PV_Examen02Entities())
                {
                    db.spEliminarPersona(idPersona);
                }
            }
            catch
            {
                Response.Redirect("~/Pages/Error.aspx");
            }
            Response.Redirect("~/Pages/MensajeEliminar.aspx");
        }
    }

}