using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModeloParcial2
{
    public class CCheques
    {
        DataSet DS;
        String TablaCheques = "Cheques";
        String TablaCuentas = "Cuentas";
        public int Importe;
        public CCheques() 
        {
            try
            {
                OleDbConnection cnn = new OleDbConnection();
                cnn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=ChequesEmitidos.mdb";
                cnn.Open();
                DS = new DataSet();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.TableDirect;
                cmd.CommandText = TablaCheques;
                OleDbDataAdapter DA = new OleDbDataAdapter(cmd);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(DA);
                DA.Fill(DS, TablaCheques);
                DataColumn[] pk = new DataColumn[2];
                pk[0] = DS.Tables[TablaCheques].Columns["NroCuenta"];
                pk[1] = DS.Tables[TablaCheques].Columns["NroCheque"];
                DS.Tables[TablaCheques].PrimaryKey = pk;
                //
                OleDbCommand cmdCu = new OleDbCommand();
                cmdCu.Connection = cnn;
                cmdCu.CommandType = CommandType.TableDirect;
                cmdCu.CommandText = TablaCuentas;
                OleDbDataAdapter DAcu = new OleDbDataAdapter(cmdCu);
                OleDbCommandBuilder cbCu = new OleDbCommandBuilder(DAcu);
                DAcu.Fill(DS, TablaCuentas);
                DataColumn[] pkCu = new DataColumn[1];
                pkCu[0] = DS.Tables[TablaCuentas].Columns["NroCuenta"];
                DS.Tables[TablaCuentas].PrimaryKey = pkCu;
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("CCheques: " + ex.Message);
            }
        }
        public void ObtenerDetallePorCheque(string cuenta, int cheque, ListView lvw)
        {

            try
            {
                int nroCuenta = 0;
                Importe = 0; 

                lvw.Items.Clear();
                DataRow drc = DS.Tables[TablaCuentas].Rows.Find(cuenta);
                if (drc != null)
                {
                    nroCuenta = int.Parse(drc["NroCuenta"].ToString());
                }
                object[] chq = new object[2];
                chq[0] = nroCuenta;
                chq[1] = cheque;
                DataRow dr = DS.Tables[TablaCheques].Rows.Find(chq);
                if (dr != null)
                {
                    ListViewItem item = lvw.Items.Add(dr["NroCheque"].ToString());
                    item.SubItems.Add(dr["FechaCaja"].ToString());
                    item.SubItems.Add(dr["Importe"].ToString());
                    item.SubItems.Add(dr["Concepto"].ToString());
                    Importe = int.Parse(dr["Importe"].ToString());
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void ObtenerDetallePorBanco(int cuenta, ListView lvw)
        {
            try
            {
                Importe = 0; // cantidad de incendios por tipo

                lvw.Items.Clear();
                DataRow drB = DS.Tables[TablaCuentas].Rows.Find(cuenta);

                if (drB != null)
                {
                    foreach (DataRow drCuenta in DS.Tables[TablaCheques].Rows)
                    {
                        if (cuenta == int.Parse(drCuenta["NroCuenta"].ToString()))
                        {
                            ListViewItem item = lvw.Items.Add(drCuenta["NroCheque"].ToString());
                            item.SubItems.Add(drCuenta["FechaCaja"].ToString());
                            item.SubItems.Add(drCuenta["Importe"].ToString());
                            item.SubItems.Add(drCuenta["Concepto"].ToString());
                            Importe += int.Parse(drCuenta["Importe"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
            public void Dispose()
        {
            DS.Dispose();
        }

    }
}

