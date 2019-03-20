using AcessoBancoDados;
using AcessoBancoDados.Models;
using Negocio.Implementation;
using Negocio.Interfaces;
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
    public partial class frmVale : Form
    {
        public IMovimentacaoRepository movimentacaoRepository = new MovimentacaoRepository(new SalaoContext());
        private Movimentacao movimentacao;

        public frmVale()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                movimentacao = new Movimentacao();
                
                movimentacao.Data = dtpData.Value;
                movimentacao.Valor = Convert.ToDouble(txtValor.Text);
                movimentacao.Descricao = txtDescricao.Text;

                movimentacaoRepository.Adicionar(movimentacao);
                movimentacaoRepository.Salvar();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente ou contate o administrador do sistema. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
