namespace Apresentacao
{
    partial class frmEditarServico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditarServico));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RemoverFuncionarioServico = new System.Windows.Forms.Button();
            this.lblId = new System.Windows.Forms.Label();
            this.txtAtrelarServicoAoFuncionario = new System.Windows.Forms.Button();
            this.cboFuncionarios = new System.Windows.Forms.ComboBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnExcluir);
            this.panel1.Controls.Add(this.btnSalvar);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 244);
            this.panel1.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.Gray;
            this.btnCancelar.Location = new System.Drawing.Point(370, 200);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(151, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.ForeColor = System.Drawing.Color.Gray;
            this.btnExcluir.Location = new System.Drawing.Point(205, 200);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(151, 23);
            this.btnExcluir.TabIndex = 2;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.ForeColor = System.Drawing.Color.Gray;
            this.btnSalvar.Location = new System.Drawing.Point(40, 200);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(151, 23);
            this.btnSalvar.TabIndex = 1;
            this.btnSalvar.Text = "Salvar alterações";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RemoverFuncionarioServico);
            this.groupBox1.Controls.Add(this.lblId);
            this.groupBox1.Controls.Add(this.txtAtrelarServicoAoFuncionario);
            this.groupBox1.Controls.Add(this.cboFuncionarios);
            this.groupBox1.Controls.Add(this.txtValor);
            this.groupBox1.Controls.Add(this.txtDescricao);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(539, 170);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // RemoverFuncionarioServico
            // 
            this.RemoverFuncionarioServico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoverFuncionarioServico.Image = ((System.Drawing.Image)(resources.GetObject("RemoverFuncionarioServico.Image")));
            this.RemoverFuncionarioServico.Location = new System.Drawing.Point(322, 105);
            this.RemoverFuncionarioServico.Name = "RemoverFuncionarioServico";
            this.RemoverFuncionarioServico.Size = new System.Drawing.Size(24, 21);
            this.RemoverFuncionarioServico.TabIndex = 9;
            this.RemoverFuncionarioServico.UseVisualStyleBackColor = true;
            this.RemoverFuncionarioServico.Click += new System.EventHandler(this.RemoverFuncionarioServico_Click);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(250, 16);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(102, 13);
            this.lblId.TabIndex = 8;
            this.lblId.Text = "Label que recebe Id";
            this.lblId.Visible = false;
            // 
            // txtAtrelarServicoAoFuncionario
            // 
            this.txtAtrelarServicoAoFuncionario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtAtrelarServicoAoFuncionario.Image = ((System.Drawing.Image)(resources.GetObject("txtAtrelarServicoAoFuncionario.Image")));
            this.txtAtrelarServicoAoFuncionario.Location = new System.Drawing.Point(300, 105);
            this.txtAtrelarServicoAoFuncionario.Name = "txtAtrelarServicoAoFuncionario";
            this.txtAtrelarServicoAoFuncionario.Size = new System.Drawing.Size(23, 21);
            this.txtAtrelarServicoAoFuncionario.TabIndex = 7;
            this.txtAtrelarServicoAoFuncionario.UseVisualStyleBackColor = true;
            this.txtAtrelarServicoAoFuncionario.Click += new System.EventHandler(this.txtAtrelarServicoAoFuncionario_Click);
            // 
            // cboFuncionarios
            // 
            this.cboFuncionarios.FormattingEnabled = true;
            this.cboFuncionarios.Location = new System.Drawing.Point(21, 105);
            this.cboFuncionarios.Name = "cboFuncionarios";
            this.cboFuncionarios.Size = new System.Drawing.Size(280, 21);
            this.cboFuncionarios.TabIndex = 6;
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(360, 105);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(154, 20);
            this.txtValor.TabIndex = 5;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(21, 43);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(493, 20);
            this.txtDescricao.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Colaboradores";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(357, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Valor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descrição";
            // 
            // frmEditarServico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(569, 251);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmEditarServico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Serviço";
            this.Load += new System.EventHandler(this.frmEditarServico_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button txtAtrelarServicoAoFuncionario;
        private System.Windows.Forms.ComboBox cboFuncionarios;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Button RemoverFuncionarioServico;
    }
}