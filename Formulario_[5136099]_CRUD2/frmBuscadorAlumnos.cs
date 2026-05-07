using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Formulario__5136099__CRUD2
{
    public partial class frmBuscadorAlumnos : Form
    {
        //Defino una variable de tipo Connection
        private SqlConnection conn1;
        //Defino una variable de tipo DataAdapter
        private SqlDataAdapter da1;
        //Defino una variable de tipo DataReader
        private SqlDataReader dr1;
        //Define una variable que contendrá la cadena de conexión
        private string sCn1;
        //Instancio una variable OleDbConnection
        OleDbConnection cnn = new OleDbConnection();
        public frmBuscadorAlumnos()
        {
            InitializeComponent();
            //Línea de conexion con el servicio de base de datos SQL por OLEDB
            cnn.ConnectionString =
            @"PROVIDER=SQLOLEDB;Server=DESKTOP-R518KSR\SQLEXPRESS;Database=DB_5136099;Uid=sa;Pwd=123456";
            //Conexion por medio de SQLCLIENT
            conexion cn1 = new
            conexion();
            cn1.conec();
            sCn1 = cn1.cadena;
            conn1 = new SqlConnection(sCn1);
            conn1.Open();
        }

        private void btnBuscarAlumno_Click(object sender, EventArgs e)
        {
            //variable que tendrá la consulta
            string seleccion;
            seleccion = "Select * From Alumnos where CodigoAlumno= '" + txtCODAlumno2.Text + "'";
            da1 = new SqlDataAdapter(seleccion, conn1);
            SqlParameter prm = new SqlParameter("Codigo", SqlDbType.VarChar);
            prm.Value = txtCODAlumno2.Text;
            da1.SelectCommand.Parameters.Add(prm); dr1 = da1.SelectCommand.ExecuteReader();
            while (dr1.Read())
            {
                txtNombreAlumno2.Text = dr1["Nombre"].ToString().Trim();
                txtApellidoAlumno2.Text = dr1["Apellido"].ToString().Trim();
                txtEdadAlumno2.Text = dr1["Edad"].ToString().Trim();
                txtDireccionAlumno2.Text = dr1["Direccion"].ToString().Trim();
            }
            if (dr1 != null)
            {
                MessageBox.Show("Datos encontrados");
                dr1.Close();
            }
        }

        private void btnBuscadorAlumnosLimpiar1_Click(object sender, EventArgs e)
        {
            //Limpiamos los textbox
            txtCODAlumno2.Text = "";
            txtNombreAlumno2.Text = "";
            txtApellidoAlumno2.Text = "";
            txtEdadAlumno2.Text = "";
            txtDireccionAlumno2.Text = "";
            MessageBox.Show("Campos limpiados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAlumnoIrRegistrador_Click(object sender, EventArgs e)
        {
            frmAlumnos ventanaAlumnos = new frmAlumnos();
            this.Hide();
            ventanaAlumnos.ShowDialog();
            this.Close();
        }

        private void btnAlumnosRegresarMenu2_Click(object sender, EventArgs e)
        {
            Form1 ventanaForm1 = new Form1();
            this.Hide();
            ventanaForm1.ShowDialog();
            this.Close();
        }
    }
}
