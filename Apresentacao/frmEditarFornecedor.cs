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
    public partial class frmEditarFornecedor : Form
    {
        IFornecedorRepository fornecedorRepository = new FornecedorRepository(new SalaoContext());        
        Fornecedor fornecedor;
        Endereco endereco;        
        List<Fornecedor> listaFornecedores = new List<Fornecedor>();

        public frmEditarFornecedor()
        {
            InitializeComponent();
        }

        public frmEditarFornecedor(int id, string nome, string email, string telefone, string especialidade, Endereco endereco)
        {
            InitializeComponent();

            fornecedor = new Fornecedor();
            fornecedor.Id = id;
            fornecedor.Nome = nome;
            fornecedor.Email = email;
            fornecedor.Telefone = telefone;            
            fornecedor.Especialidade = especialidade;
            fornecedor.Endereco = endereco;

            listaFornecedores.Add(fornecedor);

        }

        private void frmEditarFornecedor_Load(object sender, EventArgs e)
        {
            Fornecedor fornecedor = listaFornecedores[0];
            lblId.Text = fornecedor.Id.ToString();
            txtNome.Text = fornecedor.Nome;
            txtTelefone.Text = fornecedor.Telefone;
            txtEmail.Text = fornecedor.Email;
            txtEspecialidade.Text = fornecedor.Especialidade;

            txtCep.Text = fornecedor.Endereco.Cep;
            cboEstados.Text = fornecedor.Endereco.Estado;
            txtCidade.Text = fornecedor.Endereco.Cidade;
            txtBairro.Text = fornecedor.Endereco.Bairro;
            txtRua.Text = fornecedor.Endereco.Logradouro;
            txtNumero.Text = (fornecedor.Endereco.Numero).ToString();


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
                        fornecedorRepository.ExcluirPorId(id);
                        fornecedorRepository.Salvar();

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
                string cepSemMascara = RemoverFormatacaoMascara(txtCep);
                string telefoneSemMascara = RemoverFormatacaoMascara(txtTelefone);

                endereco = new Endereco();
                //endereco.Id = ((Endereco)enderecoRepository.BuscarPorCep(cepSemMascara)).Id;
                endereco.Cep = cepSemMascara;
                endereco.Estado = cboEstados.Text;
                endereco.Cidade = txtCidade.Text;
                endereco.Bairro = txtBairro.Text;
                endereco.Logradouro = txtRua.Text;
                endereco.Numero = Convert.ToInt16(txtNumero.Text);

                fornecedor = new Fornecedor();
                fornecedor.Id = Convert.ToInt16(lblId.Text);
                fornecedor.Nome = txtNome.Text;
                fornecedor.Telefone = telefoneSemMascara;
                fornecedor.Especialidade = txtEspecialidade.Text;
                fornecedor.Endereco = endereco;

                fornecedorRepository.Atualizar(fornecedor);
                fornecedorRepository.Salvar();

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
