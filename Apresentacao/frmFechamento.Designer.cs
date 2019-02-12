namespace Apresentacao
{
    partial class frmFechamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFechamento));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFecharCaixa = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpAbertura = new System.Windows.Forms.DateTimePicker();
            this.dtpFechamento = new System.Windows.Forms.DateTimePicker();
            this.cboFuncionario = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnFecharCaixa);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(14, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(623, 327);
            this.panel1.TabIndex = 0;
            // 
            // btnFecharCaixa
            // 
            this.btnFecharCaixa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFecharCaixa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFecharCaixa.Image = ((System.Drawing.Image)(resources.GetObject("btnFecharCaixa.Image")));
            this.btnFecharCaixa.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFecharCaixa.Location = new System.Drawing.Point(302, 277);
            this.btnFecharCaixa.Name = "btnFecharCaixa";
            this.btnFecharCaixa.Size = new System.Drawing.Size(138, 27);
            this.btnFecharCaixa.TabIndex = 13;
            this.btnFecharCaixa.Text = "Fechar";
            this.btnFecharCaixa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFecharCaixa.UseVisualStyleBackColor = true;
            this.btnFecharCaixa.Click += new System.EventHandler(this.btnFecharCaixa_Click);
            // 
            // btnSair
            // 
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSair.Location = new System.Drawing.Point(460, 277);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(138, 27);
            this.btnSair.TabIndex = 4;
            this.btnSair.Text = "Cancelar";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpAbertura);
            this.groupBox1.Controls.Add(this.dtpFechamento);
            this.groupBox1.Controls.Add(this.cboFuncionario);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(23, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(574, 240);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // dtpAbertura
            // 
            this.dtpAbertura.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAbertura.Location = new System.Drawing.Point(22, 105);
            this.dtpAbertura.Name = "dtpAbertura";
            this.dtpAbertura.Size = new System.Drawing.Size(530, 21);
            this.dtpAbertura.TabIndex = 10;
            // 
            // dtpFechamento
            // 
            this.dtpFechamento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechamento.Location = new System.Drawing.Point(22, 179);
            this.dtpFechamento.Name = "dtpFechamento";
            this.dtpFechamento.Size = new System.Drawing.Size(530, 21);
            this.dtpFechamento.TabIndex = 12;
            // 
            // cboFuncionario
            // 
            this.cboFuncionario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboFuncionario.FormattingEnabled = true;
            this.cboFuncionario.Items.AddRange(new object[] {
            "Karoline",
            "Josi",
            "Tiago"});
            this.cboFuncionario.Location = new System.Drawing.Point(21, 39);
            this.cboFuncionario.Name = "cboFuncionario";
            this.cboFuncionario.Size = new System.Drawing.Size(531, 23);
            this.cboFuncionario.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(19, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Data fechamento";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(16, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Colaborador";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(19, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Data abertura";
            // 
            // frmFechamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(644, 351);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmFechamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fechamento Caixa";
            this.Load += new System.EventHandler(this.frmFechamento_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.ComboBox cboFuncionario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechamento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpAbertura;
        private System.Windows.Forms.Button btnFecharCaixa;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}