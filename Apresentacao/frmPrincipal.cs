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
    public partial class frmPrincipal : Form
    {

        SalaoContext contexto = new SalaoContext();        
        AgendarRepository agendarRepository;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            frmAgendar agendar = new frmAgendar();
            agendar.Show();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            frmCadastrar cadastrar = new frmCadastrar();
            cadastrar.Show();
        }

        private void btnCalculadora_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void btnInternet_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.google.com");
        }

        private void btnFechamento_Click(object sender, EventArgs e)
        {
            frmCaixa caixa = new frmCaixa();
            caixa.Show();
        }

        private void btnPesquisarCadastros_Click(object sender, EventArgs e)
        {
            frmPesquisar pesquisar = new frmPesquisar();
            pesquisar.Show();
        }

        private void btnPagamento_Click(object sender, EventArgs e)
        {
            frmPagamento pagamento = new frmPagamento();
            pagamento.Show();
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            frmRelatorioVendas relatorioVendas = new frmRelatorioVendas();
            relatorioVendas.Show();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                agendarRepository = new AgendarRepository(contexto);

                /*var listaAgendamentos = from agendamento in agendarRepository.ListarTodos()
                                        where agendamento.Data.Equals(DateTime.Today)
                                        orderby agendamento.Data
                                        select new
                                        {
                                            Data = agendamento.Data,
                                            Colaborador = agendamento.Funcionario.Nome,
                                            Cliente = agendamento.NomeCliente,
                                            Serviço = agendamento.Servico.Nome,
                                            Horário = agendamento.Horario
                                        };*/

                
                
                dataGridViewPrincipal.DataSource = agendarRepository.PopulaDataGrid();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente ou contate o administrador do sistema. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            


        }

        private void btnPesquisarAgendamento_Click(object sender, EventArgs e)
        {
            try
            {
                agendarRepository = new AgendarRepository(contexto);
                dataGridViewPrincipal.DataSource = agendarRepository.BuscarPorNomeCliente(txtPesquisar.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente ou contate o administrador do sistema. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewPrincipal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = Convert.ToString(dataGridViewPrincipal.Rows[e.RowIndex].Cells[0].Value);
            string cliente = Convert.ToString(dataGridViewPrincipal.Rows[e.RowIndex].Cells[1].Value);
            string data = (string)dataGridViewPrincipal.Rows[e.RowIndex].Cells[2].Value;
            string horario = (string)dataGridViewPrincipal.Rows[e.RowIndex].Cells[3].Value;
            Servico servico = (Servico)dataGridViewPrincipal.Rows[e.RowIndex].Cells[4].Value;
            Funcionario funcionario = (Funcionario)dataGridViewPrincipal.Rows[e.RowIndex].Cells[5].Value;
            

            frmEditarAgendamento agendar = new frmEditarAgendamento(id, data, funcionario, cliente, horario, servico);
            agendar.Show();
        }
    }
}
