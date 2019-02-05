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
    public partial class frmCadastrarColaborador : Form
    {
        SalaoContext contexto = new SalaoContext();
        Validacao validacao;
        Funcionario funcionario;
        FuncionarioRepository funcionarioRepository;

        public frmCadastrarColaborador()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            frmCadastrar cadastrar = new frmCadastrar();
            cadastrar.Show();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                validacao = new Validacao();
                bool resultadoValidacao = validacao.ValidarColaboradorOuFornecedor(this.groupBox1, this.groupBox2);

                if (!resultadoValidacao)
                {
                    
                    funcionario = new Funcionario(contexto);
                    funcionarioRepository = new FuncionarioRepository(contexto);

                    Endereco endereco = new Endereco(contexto);

                    funcionario.Nome = txtNome.Text;
                    funcionario.Telefone = txtTelefone.Text;
                    //funcionario.Comissao = Convert.ToDouble(cboComissao.SelectedValue);

                    endereco.Cep = txtCep.Text;
                    endereco.Estado = txtEstado.Text;
                    endereco.Cidade = txtCidade.Text;
                    endereco.Bairro = txtBairro.Text;
                    endereco.Rua = txtRua.Text;
                    endereco.Numero = txtNumero.Text;

                    //funcionario.Endereco = endereco;

                    funcionarioRepository.Adicionar(funcionario);
                    funcionarioRepository.Salvar();

                    MessageBox.Show("Salvo com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Por gentileza, preencha todos os campos.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente mais tarde ou contate o administrador. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        public void LimparCampos()
        {
            txtNome.Clear();
            txtTelefone.Clear();
            txtRua.Clear(); ;
            txtNumero.Clear();
            txtEstado.Clear();
            txtCidade.Clear();
            txtCep.Clear();
            txtBairro.Clear();
            cboComissao.SelectedIndex = -1;
        }

    }
}
