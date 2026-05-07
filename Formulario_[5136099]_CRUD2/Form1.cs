using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formulario__5136099__CRUD2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAlumnos_Click(object sender, EventArgs e)
        {
            frmAlumnos ventanaAlumnos = new frmAlumnos();
            this.Hide();
            ventanaAlumnos.ShowDialog();
            this.Close();
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            frmMaterias ventanaMaterias = new frmMaterias();
            this.Hide();
            ventanaMaterias.ShowDialog();
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
            "¿Está seguro de que desea salir de la aplicación?",
            "Confirmar salida",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button2);

            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
