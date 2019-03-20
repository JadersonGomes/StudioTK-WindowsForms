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
    public partial class frmFechamento : Form
    {
        ICaixaRepository caixaRepository = new CaixaRepository(new SalaoContext());
        IFuncionarioRepository funcionarioRepository = new FuncionarioRepository(new SalaoContext());
        IVendaRepository vendaRepository = new VendaRepository(new SalaoContext());
        IFaturamentoRepository faturamentoRepository = new FaturamentoRepository(new SalaoContext());
        IMovimentacaoRepository movimentacaoRepository = new MovimentacaoRepository(new SalaoContext());

        Pagamento pagamento;
        Caixa caixa;
        Movimentacao movimentacao;
        private DateTime dataInicial, dataFinal;


        // ATENÇAÕ: IMPLEMENTAR A IDEIA DE FATURAMENTO PARA MOSTRAR TUDO O QUE O COLABORADOR FEZ NO PERÍODO SELECIONADO E O QUANTO O MESMO DEVE RECEBER.

        public frmFechamento()
        {
            InitializeComponent();
        }

        public frmFechamento(DateTime pDataInicial, DateTime pDataFinal)
        {
            InitializeComponent();

            dataInicial = pDataInicial;
            dataFinal = pDataFinal;
        }

        private void frmFechamento_Load(object sender, EventArgs e)
        {
            try
            {                
                pagamento = new Pagamento();

                // Carregar campos do comboBox de colaborador.                
                cboFuncionario.DataSource = funcionarioRepository.ListarTodos();
                cboFuncionario.SelectedIndex = -1;

                dtpInicial.Value = dataInicial;
                dtpFinal.Value = dataFinal;

                var listaFaturamento = faturamentoRepository.ListarPorPeriodo(dataInicial, dataFinal); 
                

                dataGridView1.DataSource = listaFaturamento;                                


                // Carregar dados para o dataGridView e somar o valor total para atribuir ao textBox ValorTotal
                //IEnumerable<Pagamento> lista = pagamento.ListarPorPeriodo(DateTime.Today.Date.ToString());

                //txtValorTotal.Text = Convert.ToString(pagamento.SomarValorTotal(lista));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente ou contate o administrador do sistema. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            /*try
            {
                pagamento = new Pagamento(contexto);

                if (cboFuncionario.SelectedIndex == -1)
                {
                    MessageBox.Show("Por gentileza, selecione todos os campos.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else if (dtpAbertura.Text == dtpFechamento.Text)
                {
                    IList<Pagamento> lista = pagamento.ListarFechamentoDiario(cboFuncionario.Text, dtpAbertura.Text);
                    //dataGridViewFechamento.DataSource = lista;

                    //txtValorTotal.Text = string.Format("{0:C}", 652.35/*Convert.ToString(pagamento.SomarValorTotal(lista)*//*);


                }
                else if (dtpAbertura.Value.Date < dtpFechamento.Value.Date)
                {
                    IEnumerable<Pagamento> lista = pagamento.ListarFechamentoPeriodo(cboFuncionario.Text, dtpAbertura.Text, dtpFechamento.Text);
                    //dataGridViewFechamento.DataSource = lista;

                    //txtValorTotal.Text = Convert.ToString(pagamento.SomarValorTotal(lista));


                }
                else
                {
                    MessageBox.Show("Data incorreta. Por gentileza, insira uma data final maior que a data inicial.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente ou contate o administrador do sistema. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void cboFuncionario_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var lista = faturamentoRepository.ListarPorColaboradorData(cboFuncionario.Text, dataInicial, dataFinal);
                dataGridView1.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente ou contate o administrador do sistema. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void dtpFinal_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                
                if (dtpInicial.Value <= dtpFinal.Value)
                {
                    dataGridView1.DataSource = faturamentoRepository.ListarPorPeriodo(dataInicial, dataFinal);

                }
                else
                {
                    MessageBox.Show("Por gentileza, insira uma data final maior que a data inicial.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente ou contate o administrador do sistema. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
        }

        private void btnFecharCaixa_Click(object sender, EventArgs e)
        {
            try
            {
                

                movimentacao = new Movimentacao();
                movimentacao.Data = DateTime.Today;
                movimentacao.Descricao = "Fechamento de caixa";
                movimentacao.Valor = faturamentoRepository.SomaFaturamentoTotal(faturamentoRepository.ListarPorPeriodo(dtpInicial.Value, dtpFinal.Value));

                /*movimentacaoRepository.Adicionar(movimentacao);
                movimentacaoRepository.Salvar();*/

                caixa = new Caixa();
                caixa.Status = "Fechado";
                caixa.dataAbertura = dtpInicial.Value;
                caixa.dataFechamento = dtpFinal.Value;

                foreach (var item in movimentacaoRepository.ListarPorPeriodo(dataInicial, DateTime.Today))
                {
                    caixa.Movimentacoes.Add(item);
                }
                

                /* Parte responsável por salvar os dados do fechamento de caixa no Banco de dados.
                caixaRepository.Adicionar(caixa);
                caixaRepository.Salvar();*/

                MessageBox.Show("Fechamento realizado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente ou contate o administrador do sistema. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


    }
}
