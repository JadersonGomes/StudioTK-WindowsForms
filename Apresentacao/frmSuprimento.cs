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
    public partial class frmSuprimento : Form
    {
        IMovimentacaoRepository movimentacaoRepository = new MovimentacaoRepository(new SalaoContext());
        Movimentacao movimentacao;


        public frmSuprimento()
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

                movimentacao.Valor = Convert.ToDouble(txtValor.Text);
                movimentacao.Data = DateTime.Now;
                movimentacao.FormaPagMovimentacao = cboForma.SelectedItem.ToString();
                movimentacao.Descricao = txtDescricao.Text;

                movimentacaoRepository.Adicionar(movimentacao);
                movimentacaoRepository.Salvar();

                MessageBox.Show("Salvo com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente ou contate o administrador do sistema. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
