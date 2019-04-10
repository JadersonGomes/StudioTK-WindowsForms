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
    public partial class frmResumoCaixa : Form
    {
        ICaixaRepository caixaRepository = new CaixaRepository(new SalaoContext());
        IMovimentacaoRepository movimentacaoRepository = new MovimentacaoRepository(new SalaoContext());

        public frmResumoCaixa()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHistoricoCaixa_Click(object sender, EventArgs e)
        {
            frmHistoricoCaixa historicoCaixa = new frmHistoricoCaixa();
            historicoCaixa.Show();
        }

        private void frmResumoCaixa_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime dataInicial = caixaRepository.BuscarUltimoFechamento();            
                dataGridView.DataSource = movimentacaoRepository.ListarPorPeriodo(dataInicial.Date, DateTime.Today.Date);

                dtpInicial.Value = dataInicial;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado ao tentar abrir a nova janela. Tente novamente ou contate o administrador do sistema. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpInicial.Value < dtpFinal.Value)
                {
                    dataGridView.DataSource = movimentacaoRepository.ListarPorPeriodo(dtpInicial.Value, dtpFinal.Value);

                }
                else
                {
                    MessageBox.Show("A data final deve ser maior que a data inicial. \n\n\nDetalhes: \n", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado ao tentar abrir a nova janela. Tente novamente ou contate o administrador do sistema. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
