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
    public partial class frmCadastrarProduto : Form
    {
        IProdutoRepository produtoRepository = new ProdutoRepository(new SalaoContext());
        Produto produto;


        public frmCadastrarProduto()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                produto = new Produto();

                Fornecedor fornecedor = new Fornecedor();

                var fornecedorSelecionado = (Fornecedor)cboFornecedor.SelectedValue;

                produto.Descricao = txtDescricao.Text;
                produto.Quantidade = Convert.ToInt16(txtQuantidade.Text);
                produto.Valor = Convert.ToDouble(txtValor.Text);
                //produto.Fornecedor = fornecedor.BuscarPorId(fornecedorSelecionado.Id);

                produtoRepository.Adicionar(produto);
                produtoRepository.Salvar();

                MessageBox.Show("Salvo com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente mais tarde ou contate o administrador. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void LimparCampos()
        {
            txtDescricao.Clear();
            txtQuantidade.Clear();
            txtValor.Clear();
            cboFornecedor.SelectedIndex = -1;
        }

        private void frmCadastrarProduto_Load(object sender, EventArgs e)
        {
            cboFornecedor.DataSource = produtoRepository.ListarTodos();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            frmCadastrar cadastrar = new frmCadastrar();
            cadastrar.Show();
        }


    }
}
