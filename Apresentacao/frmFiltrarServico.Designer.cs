namespace Apresentacao
{
    partial class frmFiltrarServico
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
            this.label4 = new System.Windows.Forms.Label();
            this.cboServico = new System.Windows.Forms.ComboBox();
            this.btnFecharCauxa = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboColaborador = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.datagridVendas = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridVendas)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(524, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Serviço";
            // 
            // cboServico
            // 
            this.cboServico.FormattingEnabled = true;
            this.cboServico.Items.AddRange(new object[] {
            "Teste",
            "Teste",
            "Teste"});
            this.cboServico.Location = new System.Drawing.Point(578, 70);
            this.cboServico.Name = "cboServico";
            this.cboServico.Size = new System.Drawing.Size(177, 21);
            this.cboServico.TabIndex = 22;
            this.cboServico.SelectedIndexChanged += new System.EventHandler(this.cboServico_SelectedIndexChanged);
            // 
            // btnFecharCauxa
            // 
            this.btnFecharCauxa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFecharCauxa.Location = new System.Drawing.Point(653, 596);
            this.btnFecharCauxa.Name = "btnFecharCauxa";
            this.btnFecharCauxa.Size = new System.Drawing.Size(131, 28);
            this.btnFecharCauxa.TabIndex = 24;
            this.btnFecharCauxa.Text = "Fechar caixa";
            this.btnFecharCauxa.UseVisualStyleBackColor = true;
            this.btnFecharCauxa.Click += new System.EventHandler(this.btnFecharCauxa_Click);
            // 
            // btnSair
            // 
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSair.Location = new System.Drawing.Point(805, 596);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(131, 28);
            this.btnSair.TabIndex = 23;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(261, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Colaborador";
            // 
            // cboColaborador
            // 
            this.cboColaborador.FormattingEnabled = true;
            this.cboColaborador.Items.AddRange(new object[] {
            "Teste",
            "Teste",
            "Teste"});
            this.cboColaborador.Location = new System.Drawing.Point(336, 70);
            this.cboColaborador.Name = "cboColaborador";
            this.cboColaborador.Size = new System.Drawing.Size(177, 21);
            this.cboColaborador.TabIndex = 21;
            this.cboColaborador.SelectedIndexChanged += new System.EventHandler(this.cboColaborador_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Filtre a sua busca";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Data";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.datagridVendas);
            this.panel1.Location = new System.Drawing.Point(17, 97);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(922, 484);
            this.panel1.TabIndex = 25;
            // 
            // datagridVendas
            // 
            this.datagridVendas.BackgroundColor = System.Drawing.Color.White;
            this.datagridVendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridVendas.Location = new System.Drawing.Point(3, 3);
            this.datagridVendas.Name = "datagridVendas";
            this.datagridVendas.Size = new System.Drawing.Size(916, 478);
            this.datagridVendas.TabIndex = 0;
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscar.Location = new System.Drawing.Point(771, 67);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(165, 24);
            this.btnBuscar.TabIndex = 30;
            this.btnBuscar.Text = "Pesquisar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dtpData
            // 
            this.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpData.Location = new System.Drawing.Point(53, 70);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(194, 20);
            this.dtpData.TabIndex = 31;
            // 
            // frmFiltrarServico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 646);
            this.Controls.Add(this.dtpData);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboServico);
            this.Controls.Add(this.btnFecharCauxa);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboColaborador);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "frmFiltrarServico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmFiltrarServico";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagridVendas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboServico;
        private System.Windows.Forms.Button btnFecharCauxa;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboColaborador;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView datagridVendas;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DateTimePicker dtpData;
    }
}