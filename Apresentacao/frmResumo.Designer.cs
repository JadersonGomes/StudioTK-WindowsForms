namespace Apresentacao
{
    partial class frmResumo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResumo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFecharCaixa = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpInicial = new System.Windows.Forms.DateTimePicker();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.dataGridViewResumo = new System.Windows.Forms.DataGridView();
            this.lblUltimoFechamento = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResumo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblUltimoFechamento);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnFecharCaixa);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.dtpFinal);
            this.panel1.Controls.Add(this.dtpInicial);
            this.panel1.Controls.Add(this.btnPesquisar);
            this.panel1.Controls.Add(this.txtPesquisar);
            this.panel1.Controls.Add(this.dataGridViewResumo);
            this.panel1.Location = new System.Drawing.Point(14, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1203, 605);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(755, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "ATÉ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(508, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "DE:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Colaborador";
            // 
            // btnFecharCaixa
            // 
            this.btnFecharCaixa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFecharCaixa.ForeColor = System.Drawing.Color.Gray;
            this.btnFecharCaixa.Image = ((System.Drawing.Image)(resources.GetObject("btnFecharCaixa.Image")));
            this.btnFecharCaixa.Location = new System.Drawing.Point(792, 560);
            this.btnFecharCaixa.Name = "btnFecharCaixa";
            this.btnFecharCaixa.Size = new System.Drawing.Size(189, 27);
            this.btnFecharCaixa.TabIndex = 6;
            this.btnFecharCaixa.Text = "Fechar caixa";
            this.btnFecharCaixa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFecharCaixa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFecharCaixa.UseVisualStyleBackColor = true;
            this.btnFecharCaixa.Click += new System.EventHandler(this.btnFecharCaixa_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.Gray;
            this.btnCancelar.Location = new System.Drawing.Point(999, 560);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(189, 27);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // dtpFinal
            // 
            this.dtpFinal.CalendarForeColor = System.Drawing.Color.Gray;
            this.dtpFinal.CalendarTitleForeColor = System.Drawing.Color.Gray;
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFinal.Location = new System.Drawing.Point(792, 28);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(208, 21);
            this.dtpFinal.TabIndex = 4;
            // 
            // dtpInicial
            // 
            this.dtpInicial.CalendarForeColor = System.Drawing.Color.Gray;
            this.dtpInicial.CalendarTitleForeColor = System.Drawing.Color.Gray;
            this.dtpInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInicial.Location = new System.Drawing.Point(541, 28);
            this.dtpInicial.Name = "dtpInicial";
            this.dtpInicial.Size = new System.Drawing.Size(208, 21);
            this.dtpInicial.TabIndex = 3;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.ForeColor = System.Drawing.Color.Gray;
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPesquisar.Location = new System.Drawing.Point(1023, 25);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(165, 27);
            this.btnPesquisar.TabIndex = 2;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPesquisar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPesquisar.Location = new System.Drawing.Point(14, 28);
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(444, 21);
            this.txtPesquisar.TabIndex = 1;
            // 
            // dataGridViewResumo
            // 
            this.dataGridViewResumo.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewResumo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResumo.Location = new System.Drawing.Point(14, 58);
            this.dataGridViewResumo.Name = "dataGridViewResumo";
            this.dataGridViewResumo.Size = new System.Drawing.Size(1174, 496);
            this.dataGridViewResumo.TabIndex = 0;
            // 
            // lblUltimoFechamento
            // 
            this.lblUltimoFechamento.AutoSize = true;
            this.lblUltimoFechamento.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUltimoFechamento.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblUltimoFechamento.Location = new System.Drawing.Point(21, 572);
            this.lblUltimoFechamento.Name = "lblUltimoFechamento";
            this.lblUltimoFechamento.Size = new System.Drawing.Size(199, 20);
            this.lblUltimoFechamento.TabIndex = 11;
            this.lblUltimoFechamento.Text = "DATA ÚLTIMO FECHAMENTO: ";
            // 
            // frmResumo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1229, 632);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmResumo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resumo";
            this.Load += new System.EventHandler(this.frmResumo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResumo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewResumo;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.DateTimePicker dtpInicial;
        private System.Windows.Forms.Button btnFecharCaixa;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUltimoFechamento;
    }
}