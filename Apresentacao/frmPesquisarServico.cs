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
    public partial class frmPesquisarServico : Form
    {
        IServicoRepository servicoRepository = new ServicoRepository(new SalaoContext());

        public frmPesquisarServico()
        {
            InitializeComponent();
        }

        private void frmPesquisarServico_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridViewServicos.DataSource = servicoRepository.ListarTodos();

            } catch(Exception ex)
            {
                MessageBox.Show("Algo deu errado ao tentar abrir a nova janela. Tente novamente ou contate o administrador do sistema. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPesquisar.Text == "")
                {
                    dataGridViewServicos.DataSource = servicoRepository.ListarTodos();

                } else
                {
                    dataGridViewServicos.DataSource = servicoRepository.BuscarPorNome(txtPesquisar.Text);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente ou contate o administrador do sistema. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dataGridViewServicos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = (int)dataGridViewServicos.Rows[e.RowIndex].Cells[0].Value;
                string descricao = dataGridViewServicos.Rows[e.RowIndex].Cells[1].Value.ToString();
                double valor = (double)dataGridViewServicos.Rows[e.RowIndex].Cells[2].Value;
                //string email = dataGridViewServicos.Rows[e.RowIndex].Cells[3].Value.ToString();

                frmEditarServico editarServico = new frmEditarServico(id, descricao, valor);
                editarServico.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente ou contate o administrador do sistema. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
