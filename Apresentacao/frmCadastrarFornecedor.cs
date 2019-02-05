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
    public partial class frmCadastrarFornecedor : Form
    {

        SalaoContext contexto = new SalaoContext();
        Validacao validacao;
        Fornecedor fornecedor;
        FornecedorRepository fornecedorRepository;

        public frmCadastrarFornecedor()
        {
            InitializeComponent();
        }
        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                validacao = new Validacao();
                bool resultadoValidacao = validacao.ValidarColaboradorOuFornecedor(this.groupBox1, this.groupBox2);
                bool resultadoValidacaoEmail = validacao.ValidarEmail(txtEmail.Text);

                if (!resultadoValidacao && resultadoValidacaoEmail)
                {
                    
                    fornecedor = new Fornecedor(contexto);
                    fornecedorRepository = new FornecedorRepository(contexto);

                    Endereco endereco = new Endereco(contexto);                    

                    fornecedor.Nome = txtNome.Text;
                    fornecedor.Email = txtEmail.Text;
                    fornecedor.Telefone = txtTelefone.Text;
                    fornecedor.Especialidade = txtEspecialidade.Text;

                    endereco.Cep = txtCep.Text;
                    endereco.Estado = txtEstado.Text;
                    endereco.Cidade = txtCidade.Text;
                    endereco.Bairro = txtBairro.Text;
                    endereco.Rua = txtRua.Text;
                    endereco.Numero = txtNumero.Text;

                    //fornecedor.Endereco = endereco;

                    fornecedorRepository.Adicionar(fornecedor);
                    fornecedorRepository.Salvar();

                    MessageBox.Show("Salvo com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();

                } else
                {
                    MessageBox.Show("Por gentileza, preencha todos os campos.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente mais tarde ou contate o administrador. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtTelefone.Clear();
            txtRua.Clear(); ;
            txtNumero.Clear();
            txtEstado.Clear();
            txtCidade.Clear();
            txtCep.Clear();
            txtBairro.Clear();
            txtEspecialidade.Clear();
            txtEmail.Clear();            
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
            frmCadastrar cadastrar = new frmCadastrar();
            cadastrar.Show();
        }
    }
}
