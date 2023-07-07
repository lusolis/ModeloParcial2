namespace ModeloParcial2
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "1000500",
            "10/09/2020",
            "1000",
            "Varios"}, -1);
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("1000500");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("1000510");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("1000550");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("500359 Banco Cordoba", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("600890 Banco Nacion");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Cuentas", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            this.btnCerrar = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.lvwDetalle = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tvwCheques = new System.Windows.Forms.TreeView();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(702, 366);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(86, 32);
            this.btnCerrar.TabIndex = 13;
            this.btnCerrar.Text = "&Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(367, 362);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(100, 20);
            this.txtTotal.TabIndex = 12;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(292, 365);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(69, 13);
            this.Label3.TabIndex = 11;
            this.Label3.Text = "Importe Total";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(291, 9);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(40, 13);
            this.Label2.TabIndex = 10;
            this.Label2.Text = "Detalle";
            // 
            // lvwDetalle
            // 
            this.lvwDetalle.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2,
            this.ColumnHeader3,
            this.ColumnHeader4});
            this.lvwDetalle.HideSelection = false;
            this.lvwDetalle.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lvwDetalle.Location = new System.Drawing.Point(294, 25);
            this.lvwDetalle.Name = "lvwDetalle";
            this.lvwDetalle.Size = new System.Drawing.Size(494, 327);
            this.lvwDetalle.TabIndex = 9;
            this.lvwDetalle.UseCompatibleStateImageBehavior = false;
            this.lvwDetalle.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Cheque";
            this.ColumnHeader1.Width = 100;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Fecha Caja";
            this.ColumnHeader2.Width = 120;
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "Importe";
            this.ColumnHeader3.Width = 100;
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Text = "Concepto";
            this.ColumnHeader4.Width = 150;
            // 
            // tvwCheques
            // 
            this.tvwCheques.Location = new System.Drawing.Point(12, 25);
            this.tvwCheques.Name = "tvwCheques";
            treeNode1.Name = "Nodo2";
            treeNode1.Text = "1000500";
            treeNode2.Name = "Nodo3";
            treeNode2.Text = "1000510";
            treeNode3.Name = "Nodo4";
            treeNode3.Text = "1000550";
            treeNode4.Name = "500359";
            treeNode4.Text = "500359 Banco Cordoba";
            treeNode5.Name = "600890";
            treeNode5.Text = "600890 Banco Nacion";
            treeNode6.Name = "Nodo0";
            treeNode6.Text = "Cuentas";
            this.tvwCheques.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6});
            this.tvwCheques.Size = new System.Drawing.Size(266, 364);
            this.tvwCheques.TabIndex = 8;
            this.tvwCheques.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwCheques_AfterSelect);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(91, 13);
            this.Label1.TabIndex = 7;
            this.Label1.Text = "Cheques Emitidos";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 417);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.lvwDetalle);
            this.Controls.Add(this.tvwCheques);
            this.Controls.Add(this.Label1);
            this.Name = "Form2";
            this.Text = "Consulta Detallada";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnCerrar;
        internal System.Windows.Forms.TextBox txtTotal;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ListView lvwDetalle;
        internal System.Windows.Forms.ColumnHeader ColumnHeader1;
        internal System.Windows.Forms.ColumnHeader ColumnHeader2;
        internal System.Windows.Forms.ColumnHeader ColumnHeader3;
        internal System.Windows.Forms.ColumnHeader ColumnHeader4;
        internal System.Windows.Forms.TreeView tvwCheques;
        internal System.Windows.Forms.Label Label1;
    }
}