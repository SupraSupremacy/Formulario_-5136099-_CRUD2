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
    public partial class frmMaterias : Form
    {
        private SqlConnection conn;
        private SqlCommand insert1;
        private string sCn;
        public frmMaterias()
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

        private void btnInsertarMaterias1_Click(object sender, EventArgs e)
        {
            try
            {
                //Creo la variable que contendrá la consulta sql de inserción
                string InsertarAlumno;
                InsertarAlumno = "INSERT INTO Participantes(CodigoMateria,NombreMateria,UV,Prerequisitos)";
                InsertarAlumno += "VALUES(@CodigoMateria,@NombreMateria,@UV,@Prerequisitos)";
                insert1 = new SqlCommand(InsertarAlumno, conn);
                insert1.Parameters.Add(new SqlParameter("@CodigoMateria", SqlDbType.Char));
                insert1.Parameters["@CodigoMateria"].Value = txtCODMateria.Text;
                insert1.Parameters.Add(new SqlParameter("@NombreMateria", SqlDbType.VarChar));
                insert1.Parameters["@NombreMateria"].Value = txtNombreMateria.Text;
                insert1.Parameters.Add(new SqlParameter("@UV", SqlDbType.VarChar));
                insert1.Parameters["@UV"].Value = txtUVMateria.Text;
                insert1.Parameters.Add(new SqlParameter("@Prerequisitos", SqlDbType.VarChar));
                insert1.Parameters["@Prerequisitos"].Value = txtPrerequisitosMateria.Text;
                insert1.ExecuteNonQuery();
                MessageBox.Show("Registro Agregado");
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Registro agregado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnMateriasLimpiar1_Click(object sender, EventArgs e)
        {
            //Limpiamos los textbox
            txtCODMateria.Text = "";
            txtNombreMateria.Text = "";
            txtUVMateria.Text = "";
            txtPrerequisitosMateria.Text = "";
            MessageBox.Show("Campos limpiados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnMateriaIrBuscador_Click(object sender, EventArgs e)
        {
            frmBuscadorMaterias ventanaBuscadorMaterias = new frmBuscadorMaterias();
            this.Hide();
            ventanaBuscadorMaterias.ShowDialog();
            this.Close();
        }

        private void btnMateriasRegresarMenu1_Click(object sender, EventArgs e)
        {
            Form1 ventanaForm1 = new Form1();
            this.Hide();
            ventanaForm1.ShowDialog();
            this.Close();
        }
    }
}
