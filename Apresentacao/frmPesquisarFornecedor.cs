using AcessoBancoDados;
using Negocio.Implementation;
using Negocio.Interfaces;
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
    public partial class frmPesquisarFornecedor : Form
    {
        IFornecedorRepository fornecedorRepository = new FornecedorRepository(new SalaoContext());
        Fornecedor fornecedor;
        

        public frmPesquisarFornecedor()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {            
            if (txtPesquisar.Text == "")
            {
                dataGridViewFornecedores.DataSource = fornecedorRepository.ListarTodos();
            }
            else
            {
                try
                {
                    var telefone = Convert.ToInt64(txtPesquisar.Text);
                    dataGridViewFornecedores.DataSource = fornecedorRepository.ListarPorTelefone(txtPesquisar.Text);
                }
                catch (Exception ex)
                {
                    dataGridViewFornecedores.DataSource = fornecedorRepository.ListarPorNome(txtPesquisar.Text);
                    
                }

            }
        }

        private void frmPesquisarFornecedor_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridViewFornecedores.DataSource = fornecedorRepository.PopulaGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado ao tentar abrir a nova janela. Tente novamente ou contate o administrador do sistema. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            

        }

        private void dataGridViewFornecedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dataGridViewFornecedores.Rows[e.RowIndex].Cells[0].Value;
            string nome = dataGridViewFornecedores.Rows[e.RowIndex].Cells[1].Value.ToString();
            string telefone = dataGridViewFornecedores.Rows[e.RowIndex].Cells[2].Value.ToString();
            string email = dataGridViewFornecedores.Rows[e.RowIndex].Cells[3].Value.ToString();
            string especialidade = dataGridViewFornecedores.Rows[e.RowIndex].Cells[4].Value.ToString();
            Endereco endereco = (Endereco)dataGridViewFornecedores.Rows[e.RowIndex].Cells[5].Value;

            frmEditarFornecedor editarFornecedor = new frmEditarFornecedor(id, nome, email, telefone, especialidade, endereco);
            editarFornecedor.Show();

        }
    }
}
