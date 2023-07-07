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

namespace ModeloParcial2
{
    public partial class Form3 : Form
    {

        public Form3()
        {
            InitializeComponent();
        }

        CCuentas cuentas = new CCuentas();


        private void Form3_Load(object sender, EventArgs e)
        {
            // cargar el comboBox con los datos de las cuentas existentes
            // mostrar el número de cuenta
            cmbCuenta.DisplayMember = "NroCuenta";
            cmbCuenta.ValueMember = "NroCuenta";
            cmbCuenta.DataSource = cuentas.GetCuentas();
        }

        

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            // graficar todos los cheques de la cuenta seleccionada en el comboBox
            // en el eje X mostrar el número de cheque
            // en el eje Y mostrar los importes de cada cheque
            int cta = int.Parse(cmbCuenta.SelectedValue.ToString());
            chtCheques.Titles.Clear();
            cuentas.Graficar(cta, chtCheques);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
