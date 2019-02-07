namespace Apresentacao
{
    partial class frmPagamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPagamento));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdicionarNaLista = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnReagendar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtNomeCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboDesconto = new System.Windows.Forms.ComboBox();
            this.ckbDesconto = new System.Windows.Forms.CheckBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.lblValor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblForma = new System.Windows.Forms.Label();
            this.cboServico = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboProdutos = new System.Windows.Forms.ComboBox();
            this.lblProduto = new System.Windows.Forms.Label();
            this.txtQntd = new System.Windows.Forms.TextBox();
            this.lblQntd = new System.Windows.Forms.Label();
            this.cboFormaPagamento = new System.Windows.Forms.ComboBox();
            this.cboFuncionario = new System.Windows.Forms.ComboBox();
            this.listViewServicos = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAdicionarNaLista);
            this.panel1.Controls.Add(this.btnSalvar);
            this.panel1.Controls.Add(this.btnReagendar);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.txtNomeCliente);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(14, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(799, 451);
            this.panel1.TabIndex = 0;
            // 
            // btnAdicionarNaLista
            // 
            this.btnAdicionarNaLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionarNaLista.ForeColor = System.Drawing.Color.Gray;
            this.btnAdicionarNaLista.Location = new System.Drawing.Point(230, 389);
            this.btnAdicionarNaLista.Name = "btnAdicionarNaLista";
            this.btnAdicionarNaLista.Size = new System.Drawing.Size(155, 30);
            this.btnAdicionarNaLista.TabIndex = 51;
            this.btnAdicionarNaLista.Text = "Adicionar";
            this.btnAdicionarNaLista.UseVisualStyleBackColor = true;
            this.btnAdicionarNaLista.Click += new System.EventHandler(this.btnAdicionarNaLista_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.ForeColor = System.Drawing.Color.Gray;
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.Location = new System.Drawing.Point(47, 389);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(155, 30);
            this.btnSalvar.TabIndex = 44;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnReagendar
            // 
            this.btnReagendar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReagendar.ForeColor = System.Drawing.Color.Gray;
            this.btnReagendar.Location = new System.Drawing.Point(413, 389);
            this.btnReagendar.Name = "btnReagendar";
            this.btnReagendar.Size = new System.Drawing.Size(155, 30);
            this.btnReagendar.TabIndex = 43;
            this.btnReagendar.Text = "Novo agendamento";
            this.btnReagendar.UseVisualStyleBackColor = true;
            this.btnReagendar.Click += new System.EventHandler(this.btnReagendar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.Gray;
            this.btnCancelar.Location = new System.Drawing.Point(596, 389);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(155, 30);
            this.btnCancelar.TabIndex = 42;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtNomeCliente
            // 
            this.txtNomeCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNomeCliente.Location = new System.Drawing.Point(42, 50);
            this.txtNomeCliente.Multiline = true;
            this.txtNomeCliente.Name = "txtNomeCliente";
            this.txtNomeCliente.Size = new System.Drawing.Size(728, 23);
            this.txtNomeCliente.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(38, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 30;
            this.label1.Text = "Nome do cliente";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboDesconto);
            this.groupBox1.Controls.Add(this.ckbDesconto);
            this.groupBox1.Controls.Add(this.txtValor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpData);
            this.groupBox1.Controls.Add(this.lblValor);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblForma);
            this.groupBox1.Controls.Add(this.cboServico);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cboProdutos);
            this.groupBox1.Controls.Add(this.lblProduto);
            this.groupBox1.Controls.Add(this.txtQntd);
            this.groupBox1.Controls.Add(this.lblQntd);
            this.groupBox1.Controls.Add(this.cboFormaPagamento);
            this.groupBox1.Controls.Add(this.cboFuncionario);
            this.groupBox1.Location = new System.Drawing.Point(17, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(765, 351);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            // 
            // cboDesconto
            // 
            this.cboDesconto.FormattingEnabled = true;
            this.cboDesconto.Items.AddRange(new object[] {
            "5%",
            "10%",
            "15%",
            "20%",
            "25%",
            "30%",
            "35%",
            "40%",
            "45%",
            "50%"});
            this.cboDesconto.Location = new System.Drawing.Point(24, 304);
            this.cboDesconto.Name = "cboDesconto";
            this.cboDesconto.Size = new System.Drawing.Size(377, 23);
            this.cboDesconto.TabIndex = 52;
            this.cboDesconto.Visible = false;
            this.cboDesconto.SelectedIndexChanged += new System.EventHandler(this.cboDesconto_SelectedIndexChanged);
            // 
            // ckbDesconto
            // 
            this.ckbDesconto.AutoSize = true;
            this.ckbDesconto.Location = new System.Drawing.Point(23, 279);
            this.ckbDesconto.Name = "ckbDesconto";
            this.ckbDesconto.Size = new System.Drawing.Size(117, 19);
            this.ckbDesconto.TabIndex = 51;
            this.ckbDesconto.Text = "Aplicar desconto";
            this.ckbDesconto.UseVisualStyleBackColor = true;
            this.ckbDesconto.CheckedChanged += new System.EventHandler(this.ckbDesconto_CheckedChanged);
            // 
            // txtValor
            // 
            this.txtValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtValor.Location = new System.Drawing.Point(25, 230);
            this.txtValor.Multiline = true;
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(225, 23);
            this.txtValor.TabIndex = 41;
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(21, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 15);
            this.label2.TabIndex = 31;
            this.label2.Text = "Colaborador";
            // 
            // dtpData
            // 
            this.dtpData.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtpData.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtpData.Location = new System.Drawing.Point(520, 230);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(233, 21);
            this.dtpData.TabIndex = 39;
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblValor.Location = new System.Drawing.Point(21, 211);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(79, 15);
            this.lblValor.TabIndex = 34;
            this.lblValor.Text = "Total a Pagar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(23, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 32;
            this.label3.Text = "Serviço";
            // 
            // lblForma
            // 
            this.lblForma.AutoSize = true;
            this.lblForma.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForma.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblForma.Location = new System.Drawing.Point(265, 212);
            this.lblForma.Name = "lblForma";
            this.lblForma.Size = new System.Drawing.Size(126, 15);
            this.lblForma.TabIndex = 33;
            this.lblForma.Text = "Forma de pagamento";
            // 
            // cboServico
            // 
            this.cboServico.DisplayMember = "Nome";
            this.cboServico.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboServico.FormattingEnabled = true;
            this.cboServico.Location = new System.Drawing.Point(25, 170);
            this.cboServico.Name = "cboServico";
            this.cboServico.Size = new System.Drawing.Size(470, 23);
            this.cboServico.TabIndex = 38;
            this.cboServico.SelectedIndexChanged += new System.EventHandler(this.cboServico_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(516, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 15);
            this.label6.TabIndex = 35;
            this.label6.Text = "Data pagamento";
            // 
            // cboProdutos
            // 
            this.cboProdutos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboProdutos.FormattingEnabled = true;
            this.cboProdutos.Location = new System.Drawing.Point(23, 230);
            this.cboProdutos.Name = "cboProdutos";
            this.cboProdutos.Size = new System.Drawing.Size(482, 23);
            this.cboProdutos.TabIndex = 48;
            this.cboProdutos.Visible = false;
            this.cboProdutos.SelectedIndexChanged += new System.EventHandler(this.cboProdutos_SelectedIndexChanged);
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Location = new System.Drawing.Point(20, 212);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(50, 15);
            this.lblProduto.TabIndex = 0;
            this.lblProduto.Text = "Produto";
            this.lblProduto.Visible = false;
            // 
            // txtQntd
            // 
            this.txtQntd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtQntd.Location = new System.Drawing.Point(519, 170);
            this.txtQntd.Multiline = true;
            this.txtQntd.Name = "txtQntd";
            this.txtQntd.Size = new System.Drawing.Size(233, 23);
            this.txtQntd.TabIndex = 49;
            this.txtQntd.TextChanged += new System.EventHandler(this.txtQntd_TextChanged);
            this.txtQntd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQntd_KeyPress);
            // 
            // lblQntd
            // 
            this.lblQntd.AutoSize = true;
            this.lblQntd.Location = new System.Drawing.Point(518, 152);
            this.lblQntd.Name = "lblQntd";
            this.lblQntd.Size = new System.Drawing.Size(71, 15);
            this.lblQntd.TabIndex = 50;
            this.lblQntd.Text = "Quantidade";
            // 
            // cboFormaPagamento
            // 
            this.cboFormaPagamento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboFormaPagamento.FormattingEnabled = true;
            this.cboFormaPagamento.Items.AddRange(new object[] {
            "Dinheiro",
            "Débito",
            "Crédito",
            "Boleto",
            "Cheque"});
            this.cboFormaPagamento.Location = new System.Drawing.Point(268, 230);
            this.cboFormaPagamento.Name = "cboFormaPagamento";
            this.cboFormaPagamento.Size = new System.Drawing.Size(237, 23);
            this.cboFormaPagamento.TabIndex = 40;
            // 
            // cboFuncionario
            // 
            this.cboFuncionario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboFuncionario.FormattingEnabled = true;
            this.cboFuncionario.Items.AddRange(new object[] {
            "Teste",
            "Teste",
            "Teste"});
            this.cboFuncionario.Location = new System.Drawing.Point(25, 102);
            this.cboFuncionario.Name = "cboFuncionario";
            this.cboFuncionario.Size = new System.Drawing.Size(728, 23);
            this.cboFuncionario.TabIndex = 45;
            // 
            // listViewServicos
            // 
            this.listViewServicos.BackColor = System.Drawing.Color.White;
            this.listViewServicos.Location = new System.Drawing.Point(819, 15);
            this.listViewServicos.Name = "listViewServicos";
            this.listViewServicos.Size = new System.Drawing.Size(371, 451);
            this.listViewServicos.TabIndex = 1;
            this.listViewServicos.UseCompatibleStateImageBehavior = false;
            this.listViewServicos.View = System.Windows.Forms.View.List;
            // 
            // frmPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1202, 492);
            this.Controls.Add(this.listViewServicos);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmPagamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagamento";
            this.Load += new System.EventHandler(this.frmPagamento_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnReagendar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cboFormaPagamento;
        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.ComboBox cboServico;
        private System.Windows.Forms.TextBox txtNomeCliente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label lblForma;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboFuncionario;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.ComboBox cboProdutos;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.Label lblQntd;
        private System.Windows.Forms.TextBox txtQntd;
        private System.Windows.Forms.Button btnAdicionarNaLista;
        private System.Windows.Forms.ListView listViewServicos;
        private System.Windows.Forms.ComboBox cboDesconto;
        private System.Windows.Forms.CheckBox ckbDesconto;
    }
}