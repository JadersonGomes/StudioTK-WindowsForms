using AcessoBancoDados;
using Negocio.Implementation;
using Negocio.Models;
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
        private SalaoContext contexto = new SalaoContext();
        private Validacao validacao;
        private Movimentacao movimentacao;
        public MovimentacaoRepository movimentacaoRepository;
        
        

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
                validacao = new Validacao();
                bool resultadoValidacao = validacao.ValidarAgendamento(this.panel1);

                if (!resultadoValidacao)
                {
                    movimentacao = new Movimentacao(contexto);
                    movimentacaoRepository = new MovimentacaoRepository(contexto);

                    movimentacao.nomeColaborador = txtNome.Text;
                    movimentacao.Data = dtpData.Value;
                    movimentacao.Valor = Convert.ToDouble(txtValor.Text);
                    movimentacao.Descricao = txtDescricao.Text;

                    movimentacaoRepository.Adicionar(movimentacao);
                    movimentacaoRepository.Salvar();



                } else
                {
                    MessageBox.Show("Por gentileza, preencha todos os campos.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente ou contate o administrador do sistema. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
