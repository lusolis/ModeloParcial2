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
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }
        CCuentas cuentas = new CCuentas();
        

        private void Form2_Load(object sender, EventArgs e)
        {
            tvwCheques.Nodes.Clear();
            // cargar el TreeView con los datos de las cuentas y sus cheques
            cuentas.CargarTreeView(tvwCheques);
            // en los nodos de las cuentas mostrar el nro de cuenta seguido del nombre del banco
            // en los nodos de los cheques mostrar el nro de cheque


        }

        private void tvwCheques_AfterSelect(object sender, TreeViewEventArgs e)
        {
            CCheques cheques = new CCheques();
            // obtener el nodo que se seleccionó en el TreeView y
            int Total;
            
            // determinar el nivel del nodo seleccionado
            TreeNode nodo = e.Node;
            switch (nodo.Level)
            {
                case 0: // es el nodo raiz
                    lvwDetalle.Items.Clear();
                    txtTotal.Text = "";
                    break;

                case 1: // es un nodo de Banco
                    cheques.ObtenerDetallePorBanco(int.Parse(nodo.Name), lvwDetalle);
                    txtTotal.Text = cheques.Importe.ToString();
                    break;

                case 2: // es un nodo de Cheque
                    cheques.ObtenerDetallePorCheque(nodo.Name, int.Parse(nodo.Text), lvwDetalle);
                    txtTotal.Text = cheques.Importe.ToString();
                    break;
            }
            // liberar los recursos
            cheques.Dispose();

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
