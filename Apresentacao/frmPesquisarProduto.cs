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
    public partial class frmPesquisarProduto : Form
    {
        SalaoContext contexto = new SalaoContext();
        Produto produto;
        ProdutoRepository produtoRepository;

        public frmPesquisarProduto()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            produto = new Produto(contexto);

            if (txtPesquisar.Text == "")
            {
                dataGridViewProdutos.DataSource = produto.ListarTodos();
            } else
            {                
                dataGridViewProdutos.DataSource = produto.ListarPorNome(txtPesquisar.Text);

            }
        }

        private void frmPesquisarProduto_Load(object sender, EventArgs e)
        {
            produtoRepository = new ProdutoRepository(contexto);
            dataGridViewProdutos.DataSource = produtoRepository.PopulaDataGrid();
        }

        private void dataGridViewProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dataGridViewProdutos.Rows[e.RowIndex].Cells[0].Value;
            string descricao = dataGridViewProdutos.Rows[e.RowIndex].Cells[1].Value.ToString();
            int quantidade = (int)dataGridViewProdutos.Rows[e.RowIndex].Cells[2].Value;
            double valor = (double)dataGridViewProdutos.Rows[e.RowIndex].Cells[3].Value; // ESTA LINHA ESTA VINDO NULA - VERIFICAR DEPOIS
            Fornecedor fornecedor = (Fornecedor)dataGridViewProdutos.Rows[e.RowIndex].Cells[4].Value;
            
            // TESTE PARA VER SE O GIT CONECTOU CORRETAMENTE               

            frmEditarProduto editarProduto = new frmEditarProduto(id, descricao, quantidade, valor, fornecedor);
            editarProduto.Show();
        }
    }
}
