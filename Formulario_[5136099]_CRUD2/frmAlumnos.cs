using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Formulario__5136099__CRUD2
{
    public partial class frmAlumnos : Form
    {
        private SqlConnection conn;
        private SqlCommand insert1;
        private string sCn;
        public frmAlumnos()
        {
            InitializeComponent();
            //usando la clase conexion
            //creo un nuevo objeto de tipo conexión y lo asigno a un cn
            conexion cn = new conexion();
            //acceso a la función conec de la clase conexión
            cn.conec();
            //Agrego la variable sCn a la cadena conexion
            sCn = cn.cadena;
            //creo la conexion pensándole como argumento la cadena
            conn = new SqlConnection(sCn);
            //abro la conexión
            conn.Open();
        }

        private void btnInsertarAlumnos1_Click(object sender, EventArgs e)
        {
            try
            {
                //Creo la variable que contendrá la consulta sql de inserción
                string InsertarAlumno;
                InsertarAlumno = "INSERT INTO Participantes(Codigo,Nombres,Apellidos,Edad,Direccion)";
                InsertarAlumno += "VALUES(@CodigoAlumno,@Nombre,@Apellido,@Edad,@Direccion)";
                insert1 = new SqlCommand(InsertarAlumno, conn);
                insert1.Parameters.Add(new SqlParameter("@CodigoAlumno", SqlDbType.Char));
                insert1.Parameters["@CodigoAlumno"].Value = txtCODAlumno.Text;
                insert1.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar));
                insert1.Parameters["@Nombre"].Value = txtCODAlumno.Text;
                insert1.Parameters.Add(new SqlParameter("@Apellido", SqlDbType.VarChar));
                insert1.Parameters["@Apellido"].Value = txtCODAlumno.Text;
                insert1.Parameters.Add(new SqlParameter("@Edad", SqlDbType.VarChar));
                insert1.Parameters["@Edad"].Value = txtCODAlumno.Text;
                insert1.Parameters.Add(new SqlParameter("@Direccion", SqlDbType.VarChar));
                insert1.Parameters["@Direccion"].Value = txtCODAlumno.Text;
                insert1.ExecuteNonQuery();
                MessageBox.Show("Registro Agregado");
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Registro agregado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAlumnosLimpiar1_Click(object sender, EventArgs e)
        {
            //Limpiamos los textbox
            txtCODAlumno.Text = "";
            txtNombreAlumno.Text = "";
            txtApellidoAlumno.Text = "";
            txtEdadAlumno.Text = "";
            txtDireccionAlumno.Text = "";
            MessageBox.Show("Campos limpiados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAlumnoIrBuscador_Click(object sender, EventArgs e)
        {
            frmBuscadorAlumnos ventanaBuscadorAlumnos = new frmBuscadorAlumnos();
            this.Hide();
            ventanaBuscadorAlumnos.ShowDialog();
            this.Close();
        }

        private void btnAlumnosRegresarMenu1_Click(object sender, EventArgs e)
        {
            Form1 ventanaForm1 = new Form1();
            this.Hide();
            ventanaForm1.ShowDialog();
            this.Close();
        }
    }
}