using AcessoBancoDados;
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
        Pagamento pagamento;
        Caixa caixa;
        SalaoContext contexto = new SalaoContext();


        public frmResumo()
        {
            InitializeComponent();
        }

        private void frmResumo_Load(object sender, EventArgs e)
        {
            try
            {
                pagamento = new Pagamento(contexto);

                if (txtPesquisar.Text.Equals("") || txtPesquisar.Text.Equals(" "))
                {
                    if (dtpInicial.Text == dtpFinal.Text)
                    {
                        IEnumerable<Pagamento> lista = pagamento.ListarPorPeriodo(dtpInicial.Text);
                        dataGridViewResumo.DataSource = lista;

                        //txtValorTotal.Text = string.Format("{0:C}", 652.35/*Convert.ToString(pagamento.SomarValorTotal(lista)*/);

                    }
                    else if (dtpInicial.Value.Date < dtpFinal.Value.Date)
                    {
                        IEnumerable<Pagamento> lista = pagamento.ListarPorIntervaloPeriodo(dtpInicial.Text, dtpFinal.Text);
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
                    dataGridViewResumo.DataSource = pagamento.ListarPorColaborador(txtPesquisar.Text);
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
                        IEnumerable<Pagamento> lista = pagamento.ListarPorPeriodo(dtpInicial.Text);
                        dataGridViewResumo.DataSource = lista;

                        //txtValorTotal.Text = string.Format("{0:C}", 652.35/*Convert.ToString(pagamento.SomarValorTotal(lista)*/);

                    }
                    else if (dtpInicial.Value.Date < dtpFinal.Value.Date)
                    {
                        IEnumerable<Pagamento> lista = pagamento.ListarPorIntervaloPeriodo(dtpInicial.Text, dtpFinal.Text);
                        dataGridViewResumo.DataSource = lista;

                        //txtValorTotal.Text = Convert.ToString(pagamento.SomarValorTotal(lista));

                    }
                    else
                    {
                        MessageBox.Show("Data incorreta. Por gentileza, insira uma data final maior que a data inicial.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }


                } else
                {

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
