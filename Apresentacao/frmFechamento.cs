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
    public partial class frmFechamento : Form
    {
        SalaoContext contexto = new SalaoContext();
        Validacao validacao;
        Pagamento pagamento;        
        Caixa caixa;
        CaixaRepository caixaRepository;

        public frmFechamento()
        {
            InitializeComponent();
        }

        private void frmFechamento_Load(object sender, EventArgs e)
        {
            try
            {
                pagamento = new Pagamento(contexto);

                // Carregar campos do comboBox de colaborador.
                Funcionario funcionario = new Funcionario(contexto);
                cboFuncionario.DataSource = funcionario.ListarTodos();

                // Carregar dados para o dataGridView e somar o valor total para atribuir ao textBox ValorTotal
                IEnumerable<Pagamento> lista = pagamento.ListarPorPeriodo(DateTime.Today.Date.ToString());

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
            try
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

                    //txtValorTotal.Text = string.Format("{0:C}", 652.35/*Convert.ToString(pagamento.SomarValorTotal(lista)*/);


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
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                validacao = new Validacao();
                bool campoVazio = validacao.ValidarPadrao(this.panel1);

                if (!campoVazio)
                {
                    caixa = new Caixa(contexto);
                    caixaRepository = new CaixaRepository(contexto);

                    caixa.Status = "Fechado";
                    caixa.dataAbertura = dtpAbertura.Value;
                    caixa.dataFechamento = dtpFechamento.Value;

                    caixaRepository.Adicionar(caixa);
                    caixaRepository.Salvar();


                    MessageBox.Show("Fechamento realizado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
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
