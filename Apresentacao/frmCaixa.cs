using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apresentacao
{
    public partial class frmCaixa : Form
    {
        public frmCaixa()
        {
            InitializeComponent();
        }

        private void btnResumo_Click(object sender, EventArgs e)
        {
            frmResumo resumo = new frmResumo();
            this.Hide();
            resumo.Show();
        }

        private void btnSuprimento_Click(object sender, EventArgs e)
        {
            frmSuprimento suprimento = new frmSuprimento();
            this.Hide();
            suprimento.Show();
        }

        private void btnDespesa_Click(object sender, EventArgs e)
        {
            frmDespesa despesa = new frmDespesa();
            this.Hide();
            despesa.Show();
        }

        private void btnVale_Click(object sender, EventArgs e)
        {
            frmVale vale = new frmVale();
            this.Hide();
            vale.Show();
        }

        private void btnAbrirCaixa_Click(object sender, EventArgs e)
        {
            DialogResult resultadoEscolha = MessageBox.Show("Você deseja adicionar um valor inicial ao caixa?", "Suprimento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultadoEscolha == DialogResult.Yes)
            {
                frmSuprimento suprimento = new frmSuprimento();
                this.Hide();
                suprimento.Show();                

            } else if (resultadoEscolha == DialogResult.No)
            {
                MessageBox.Show("Caixa aberto com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnFecharCaixa_Click(object sender, EventArgs e)
        {
            frmResumo resumo = new frmResumo();
            this.Hide();
            resumo.Show();
        }

        
    }
}
