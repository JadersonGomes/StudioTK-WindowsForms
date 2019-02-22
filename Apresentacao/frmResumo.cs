using AcessoBancoDados;
using Negocio.Implementation;
using Negocio.Interfaces;
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
    public partial class frmResumo : Form
    {                   
        IVendaRepository vendaRepository = new VendaRepository(new SalaoContext());
        ICaixaRepository caixaRepository = new CaixaRepository(new SalaoContext());


        public frmResumo()
        {
            InitializeComponent();
        }

        private void frmResumo_Load(object sender, EventArgs e)
        {
            try
            {

                DateTime dataUltimoFechamento = caixaRepository.BuscarUltimoFechamento();
                lblDataUltimoFechamento.Text = dataUltimoFechamento.ToShortDateString();

                if (txtPesquisar.Text.Equals("") || txtPesquisar.Text.Equals(" "))
                {
                    if (dtpInicial.Text == dtpFinal.Text)
                    {
                        IEnumerable<Venda> lista = vendaRepository.ListarPorData(dtpInicial.Text);
                        dataGridViewResumo.DataSource = lista;

                        //txtValorTotal.Text = string.Format("{0:C}", 652.35/*Convert.ToString(pagamento.SomarValorTotal(lista)*/);

                    }
                    else if (dtpInicial.Value.Date < dtpFinal.Value.Date)
                    {
                        IEnumerable<Venda> lista = vendaRepository.ListarPorIntervaloPeriodo(dtpInicial.Text, dtpFinal.Text);
                        dataGridViewResumo.DataSource = lista;

                        //txtValorTotal.Text = Convert.ToString(pagamento.SomarValorTotal(lista));

                    }
                    else
                    {
                        MessageBox.Show("Data incorreta. Por gentileza, insira uma data final maior que a data inicial.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }

                }
                else
                {
                    IEnumerable<Venda> lista = vendaRepository.ListarPorFuncionario(txtPesquisar.Text);
                    dataGridViewResumo.DataSource = lista;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente ou contate o administrador do sistema. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPesquisar.Text.Length <= 0)
                {
                    if (dtpInicial.Text == dtpFinal.Text)
                    {
                        IEnumerable<Venda> lista = vendaRepository.ListarPorData(dtpInicial.Text);
                        dataGridViewResumo.DataSource = lista;

                        //txtValorTotal.Text = string.Format("{0:C}", 652.35/*Convert.ToString(pagamento.SomarValorTotal(lista)*/);

                    }
                    else if (dtpInicial.Value.Date < dtpFinal.Value.Date)
                    {
                        IEnumerable<Venda> lista = vendaRepository.ListarPorIntervaloPeriodo(dtpInicial.Text, dtpFinal.Text);
                        dataGridViewResumo.DataSource = lista;

                        //txtValorTotal.Text = Convert.ToString(pagamento.SomarValorTotal(lista));

                    }
                    else
                    {
                        MessageBox.Show("Data incorreta. Por gentileza, insira uma data final maior que a data inicial.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }


                }
                else
                {
                    dataGridViewResumo.DataSource = vendaRepository.ListarPorFuncionario(txtPesquisar.Text);
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
                DateTime dataInicial = Convert.ToDateTime(lblDataUltimoFechamento.Text);
                frmFechamento fechamento = new frmFechamento(dataInicial, DateTime.Today);
                fechamento.Show();

            }
            catch (FormatException ex)
            {
                MessageBox.Show("Data incorreta na Tela Resumo. Por gentileza, insira uma data válida. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente ou contate o administrador do sistema. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnHistoricoCaixa_Click(object sender, EventArgs e)
        {

        }
    }
}
