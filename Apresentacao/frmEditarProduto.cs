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
    public partial class frmEditarProduto : Form
    {
        IProdutoRepository produtoRepository = new ProdutoRepository(new SalaoContext());
        Produto produto;        
        List<Produto> listaProdutos = new List<Produto>(); 

        public frmEditarProduto()
        {
            InitializeComponent();
        }
        public frmEditarProduto(int id, string descricao, int quantidade, double valor, Fornecedor fornecedor)
        {
            InitializeComponent();

            produto = new Produto();
            produto.Id = id;
            produto.Descricao = descricao;
            produto.QntdEstoque = quantidade;
            produto.Valor = valor;
            produto.Fornecedor = fornecedor;

            listaProdutos.Add(produto);
        }

        private void frmEditarProduto_Load(object sender, EventArgs e)
        {
            Produto produto = listaProdutos[0];

            lblId.Text = produto.Id.ToString();
            txtDescricao.Text = produto.Descricao;
            txtQuantidade.Text = Convert.ToString(produto.QntdEstoque);
            txtValor.Text = Convert.ToString(produto.Valor);
            cboFornecedor.Text = produto.Fornecedor.Nome;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt16(lblId.Text);

                if (id > 0)
                {
                    DialogResult resultadoEscolha = MessageBox.Show("Tem certeza que deseja excluir este item?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                    if (resultadoEscolha == DialogResult.Yes)
                    {
                        produtoRepository.ExcluirPorId(id);
                        produtoRepository.Salvar();

                    }
                    else if (resultadoEscolha == DialogResult.No)
                    {

                    }

                }
                else
                {
                    MessageBox.Show("Nenhum item foi selecionado. Por favor, tente novamente mais tarde.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente mais tarde ou contate o administrador. \n\n\nDetalhes: \n" + ex.Message, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }
        

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Fornecedor fornecedor = (Fornecedor)cboFornecedor.SelectedItem;
                fornecedor.Nome = cboFornecedor.Text;                  

                produto = new Produto();
                produto.Id = Convert.ToInt16(lblId.Text);
                produto.Descricao = txtDescricao.Text;
                produto.QntdEstoque = Convert.ToInt32(txtQuantidade.Text);
                produto.Valor = Convert.ToDouble(txtValor.Text);
                produto.Fornecedor = fornecedor;

                produtoRepository.Atualizar(produto);
                produtoRepository.Salvar();

                MessageBox.Show("As alterações foram salvas com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente mais tarde ou contate o administrador. \n\n\nDetalhes: \n" + ex.Message, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public string RemoverFormatacaoMascara(MaskedTextBox txtMask)
        {
            txtMask.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            string textoSemMascara = txtMask.Text;
            txtMask.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

            return textoSemMascara;

        }
    }
}
