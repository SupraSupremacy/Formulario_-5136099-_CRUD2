using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formulario__5136099__CRUD2
{
    public partial class frmBuscadorMaterias : Form
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
        public frmBuscadorMaterias()
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

        private void btnBuscarMaterias1_Click(object sender, EventArgs e)
        {
            //variable que tendrá la consulta
            string seleccion;
            seleccion = "Select * From Materia where CodigoMateria= '" + txtCODMateria2.Text + "'";
            da1 = new SqlDataAdapter(seleccion, conn1);
            SqlParameter prm = new SqlParameter("CodigoMateria", SqlDbType.VarChar);
            prm.Value = txtCODMateria2.Text;
            da1.SelectCommand.Parameters.Add(prm); dr1 = da1.SelectCommand.ExecuteReader();
            while (dr1.Read())
            {
                txtNombreMateria2.Text = dr1["NombreMateria"].ToString().Trim();
                txtUVMateria2.Text = dr1["UV"].ToString().Trim();
                txtPrerequisitosMateria2.Text = dr1["Prerequisitos"].ToString().Trim();
            }
            if (dr1 != null)
            {
                MessageBox.Show("Datos encontrados");
                dr1.Close();
            }
        }

        private void btnBuscadorMateriasLimpiar1_Click(object sender, EventArgs e)
        {
            //Limpiamos los textbox
            txtCODMateria2.Text = "";
            txtNombreMateria2.Text = "";
            txtUVMateria2.Text = "";
            txtPrerequisitosMateria2.Text = "";
            MessageBox.Show("Campos limpiados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnMateriaIrRegistro_Click(object sender, EventArgs e)
        {
            frmMaterias ventanaMaterias = new frmMaterias();
            this.Hide();
            ventanaMaterias.ShowDialog();
            this.Close();
        }

        private void btnMateriasRegresarMenu2_Click(object sender, EventArgs e)
        {
            Form1 ventanaForm1 = new Form1();
            this.Hide();
            ventanaForm1.ShowDialog();
            this.Close();
        }
    }
}
