using AcessoBancoDados;
using AcessoBancoDados.Models;
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
    public partial class frmFiltrarServico : Form
    {
        //private SalaoContext contexto = new SalaoContext();
        //Pagamento pagamento;
        //bool selecionouPeriodo = false, selecionouColaborador = false, selecionouServico = false;       

        public frmFiltrarServico()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFecharCauxa_Click(object sender, EventArgs e)
        {
            frmFechamento fechamento = new frmFechamento();
            fechamento.Show();
        }

        private void cboColaborador_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*selecionouColaborador = true;

            try
            {
                if (dtpData.Value.Equals("") && selecionouColaborador == true && cboServico.SelectedItem.Equals(""))
                {
                    datagridVendas.DataSource = pagamento.ListarPorColaborador(cboColaborador.SelectedText);

                }
                else if (selecionouPeriodo == true && selecionouColaborador == true && cboServico.SelectedItem.Equals(""))
                {
                    datagridVendas.DataSource = pagamento.ListarPorPeriodoColaborador(dtpData.Value.ToString(), cboColaborador.SelectedText);

                }
                else if (dtpData.Value.Equals("") && selecionouColaborador == true && selecionouServico == true)
                {
                    datagridVendas.DataSource = pagamento.ListarPorColaboradorServico(cboServico.SelectedText, cboColaborador.SelectedText);

                }
                else if (selecionouPeriodo == true && selecionouColaborador == true && selecionouServico == true)
                {
                    datagridVendas.DataSource = pagamento.ListarPorPeriodoColaboradorServico(dtpData.Value.ToString(), cboColaborador.SelectedText, cboServico.SelectedText);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente mais tarde ou contate o administrador. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */

        }

        private void cboServico_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*selecionouServico = true;

            try
            {
                if (dtpData.Value.Equals("") && cboColaborador.SelectedItem.Equals("") && selecionouServico == true)
                {
                    datagridVendas.DataSource = pagamento.ListarPorServico(cboServico.SelectedText);
                }
                else if (dtpData.Value.Equals("") && selecionouColaborador == true && selecionouServico == true)
                {
                    datagridVendas.DataSource = pagamento.ListarPorColaboradorServico(cboServico.SelectedText, cboColaborador.SelectedText);

                }
                else if (selecionouPeriodo == true && cboColaborador.SelectedItem.Equals("") && selecionouServico == true)
                {
                    datagridVendas.DataSource = pagamento.ListarPorPeriodoServico(cboServico.SelectedText, dtpData.Value.ToString());

                }
                else if (selecionouPeriodo == true && selecionouColaborador == true && selecionouServico == true)
                {
                    datagridVendas.DataSource = pagamento.ListarPorPeriodoColaboradorServico(dtpData.Value.ToString(), cboColaborador.SelectedText, cboServico.SelectedText);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente mais tarde ou contate o administrador. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */
        }

       

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            /*pagamento = new Pagamento(contexto);
            Agenda ag = new Agenda(contexto);

            if (dtpData.Value.Equals(DateTime.Today) && cboColaborador.SelectedItem.Equals("") && cboServico.SelectedItem.Equals(""))
            {
                datagridVendas.DataSource = pagamento.ListarTodos();                
            }    */        

        }

        private void cboPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*selecionouPeriodo = true;

            try
            {
                if (selecionouPeriodo == true && cboColaborador.SelectedItem.Equals("") && cboServico.SelectedItem.Equals(""))
                {
                    datagridVendas.DataSource = pagamento.ListarPorPeriodo(dtpData.Value.ToString());

                }
                else if (selecionouPeriodo == true && selecionouColaborador == true && cboServico.SelectedItem.Equals(""))
                {
                    datagridVendas.DataSource = pagamento.ListarPorPeriodoColaborador(dtpData.Value.ToString(), cboColaborador.SelectedText);

                }
                else if (selecionouPeriodo == true && cboColaborador.SelectedItem.Equals("") && selecionouServico == true)
                {
                    datagridVendas.DataSource = pagamento.ListarPorPeriodoServico(cboServico.SelectedText, dtpData.Value.ToString());

                }
                else if (selecionouPeriodo == true && selecionouColaborador == true && selecionouServico == true)
                {
                    datagridVendas.DataSource = pagamento.ListarPorPeriodoColaboradorServico(dtpData.Value.ToString(), cboColaborador.SelectedText, cboServico.SelectedText);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente mais tarde ou contate o administrador. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            */

        }
    }
}
