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
    public partial class frmPesquisarProduto : Form
    {
        IProdutoRepository produtoRepository = new ProdutoRepository(new SalaoContext());             

        public frmPesquisarProduto()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {           

            if (txtPesquisar.Text == "")
            {
                dataGridViewProdutos.DataSource = produtoRepository.ListarTodos();
            } else
            {                
                dataGridViewProdutos.DataSource = produtoRepository.ListarPorNome(txtPesquisar.Text);

            }
        }

        private void frmPesquisarProduto_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridViewProdutos.DataSource = produtoRepository.PopulaGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado ao tentar abrir a nova janela. Tente novamente ou contate o administrador do sistema. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            

        }

        private void dataGridViewProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dataGridViewProdutos.Rows[e.RowIndex].Cells[0].Value;
            string descricao = dataGridViewProdutos.Rows[e.RowIndex].Cells[1].Value.ToString();
            int quantidade = (int)dataGridViewProdutos.Rows[e.RowIndex].Cells[2].Value;
            Fornecedor fornecedor = (Fornecedor)dataGridViewProdutos.Rows[e.RowIndex].Cells[3].Value; 
            double valor = (double)dataGridViewProdutos.Rows[e.RowIndex].Cells[4].Value;

            frmEditarProduto editarProduto = new frmEditarProduto(id, descricao, quantidade, valor, fornecedor);
            editarProduto.Show();
        }
    }
}
