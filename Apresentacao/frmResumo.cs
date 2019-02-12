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
        SalaoContext contexto = new SalaoContext();
        IVendaRepository vendaRepository = new VendaRepository(new SalaoContext());


        public frmResumo()
        {
            InitializeComponent();
        }

        private void frmResumo_Load(object sender, EventArgs e)
        {
            try
            {

                if (txtPesquisar.Text.Equals("") || txtPesquisar.Text.Equals(" "))
                {
                    if (dtpInicial.Text == dtpFinal.Text)
                    {
                        IEnumerable<Venda> lista = vendaRepository.ListAllVendas();
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
            frmFechamento fechamento = new frmFechamento();
            fechamento.Show();
        }
    }
}
