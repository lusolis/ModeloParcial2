using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ModeloParcial2
{
    public class CCuentas
    {
        DataSet DS;
        String TablaCuentas = "Cuentas";
        String TablaCheques = "Cheques";

        public CCuentas()
        {
            try
            {
                OleDbConnection cnn = new OleDbConnection();
                cnn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=ChequesEmitidos.mdb";
                cnn.Open();
                DS = new DataSet();
                OleDbCommand cmdCu = new OleDbCommand();
                cmdCu.Connection = cnn;
                cmdCu.CommandType = CommandType.TableDirect;
                cmdCu.CommandText = TablaCuentas;
                OleDbDataAdapter DAcu = new OleDbDataAdapter(cmdCu);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(DAcu);
                DAcu.Fill(DS, TablaCuentas);
                DataColumn[] pk = new DataColumn[1];
                pk[0] = DS.Tables[TablaCuentas].Columns["NroCuenta"];
                DS.Tables[TablaCuentas].PrimaryKey = pk;
                //
                OleDbCommand cmdChq = new OleDbCommand();
                cmdChq.Connection = cnn;
                cmdChq.CommandType = CommandType.TableDirect;
                cmdChq.CommandText = TablaCheques;
                OleDbDataAdapter DAch = new OleDbDataAdapter(cmdChq);
                OleDbCommandBuilder cbCh = new OleDbCommandBuilder(DAch);
                DAch.Fill(DS, TablaCheques);
                DataColumn[] pkCh = new DataColumn[2];
                pkCh[0] = DS.Tables[TablaCheques].Columns["NroCuenta"];
                pkCh[1] = DS.Tables[TablaCheques].Columns["NroCheque"];
                DS.Tables[TablaCheques].PrimaryKey = pkCh;

                cnn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("CCuentas: " + ex.Message);
            }
        }
        
        public void CargarTreeView(TreeView tvw)
        {
            tvw.Nodes.Clear();
            // agregar la raiz
            TreeNode raiz = tvw.Nodes.Add("raiz", "Cuentas");
            try
            {
                foreach (DataRow drCu in DS.Tables[TablaCuentas].Rows)
                {
                    TreeNode cuentas = raiz.Nodes.Add(drCu["NroCuenta"].ToString(), drCu["Banco"].ToString());

                    foreach (DataRow drCh in DS.Tables[TablaCheques].Rows)
                    {
                        // comparar el numero de cuenta
                        if ((int)drCu["NroCuenta"] == (int)drCh["NroCuenta"])
                        {
                            // agregar el nro de cheque como nodo hijo de la cuenta
                            cuentas.Nodes.Add(drCh["NroCuenta"].ToString(), drCh["NroCheque"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("CCuentas: " + ex.Message);
            }

        }
        public void Graficar(int cuenta, Chart cht)
        {
            try
            {
                cht.Visible = true;
                // crea un gráfico para una determinada localidad
                cht.Series.Clear();
                cht.Titles.Add("Cheques por cuenta");
                // crear una tabla temporal
                DataTable tbCh = new DataTable();
                tbCh.Columns.Add("NroCuenta");
                tbCh.Columns.Add("NroCheque");
                tbCh.Columns.Add("FechaCaja");
                tbCh.Columns.Add("FechaAcreditacion");
                tbCh.Columns.Add("Importe");
                tbCh.Columns.Add("Concepto");

                foreach (DataRow dr in DS.Tables[TablaCheques].Rows)
                {
                    if (cuenta == int.Parse(dr["NroCuenta"].ToString()))
                    {
                        // se agrega el registro nuevo a la tabla temporal
                        DataRow nuevo = tbCh.NewRow();
                        nuevo["NroCuenta"] = int.Parse(dr["NroCuenta"].ToString());
                        nuevo["NroCheque"] = int.Parse(dr["NroCheque"].ToString());
                        nuevo["FechaCaja"] = dr["FechaCaja"].ToString();
                        nuevo["FechaAcreditacion"] = dr["FechaAcreditacion"].ToString();
                        nuevo["Importe"] = int.Parse(dr["Importe"].ToString());
                        nuevo["Concepto"] = dr["Concepto"];

                        tbCh.Rows.Add(nuevo);
                    }
                }
                // Crear una nueva serie en el control Chart
                Series serie = cht.Series.Add(cuenta.ToString());
                serie.ChartType = SeriesChartType.Column; // tipo de grafico = columnas
                serie.YValueMembers = "Importe"; // Establecer los valores en el eje Y de la serie
                serie.XValueMember = "NroCheque"; // Establecer los valores en el eje X de la serie
                cht.Series[0].IsValueShownAsLabel = true;
               
                                                          // Enlazar la tabla temporal al control Chart
                cht.DataSource = tbCh.DefaultView;
                
                // Establecer título del eje Y
                cht.ChartAreas[0].AxisY.Title = "Importes ($)";
                // Establecer título del eje X
                cht.ChartAreas[0].AxisX.Title = "Cheques";
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public DataTable GetCuentas()
        {
            if (DS.Tables.Count == 2)
            {
                return DS.Tables["Cuentas"];
            }
            else
            {
                throw new Exception("La tabla no existe");
            }
        }
        public void Dispose()
        {
            DS.Dispose();
        }
    }
}
