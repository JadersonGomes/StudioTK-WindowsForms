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
    public partial class frmEditarColaborador : Form
    {
        IFuncionarioRepository funcionarioRepository = new FuncionarioRepository(new SalaoContext());
        IEnderecoRepository enderecoRepository = new EnderecoRepository(new SalaoContext());
        Funcionario funcionario;
        Endereco endereco;        
        List<Funcionario> listaFuncionarios = new List<Funcionario>();


        public frmEditarColaborador()
        {
            InitializeComponent();
        }

        public frmEditarColaborador(int id, string nome, string telefone, string comissao, Endereco endereco)
        {
            InitializeComponent();

            funcionario = new Funcionario();
            funcionario.Id = id;
            funcionario.Nome = nome;
            funcionario.Telefone = telefone;
            funcionario.Comissao = comissao;
            funcionario.Endereco = endereco;

            listaFuncionarios.Add(funcionario);
        }

        private void frmEditarColaborador_Load(object sender, EventArgs e)
        {
            Funcionario func = listaFuncionarios[0];

            lblId.Text = func.Id.ToString();
            txtNome.Text = func.Nome;
            txtTelefone.Text = func.Telefone;
            cboComissao.Text = func.Comissao.ToString();

            txtCep.Text = func.Endereco.Cep;
            cboEstados.Text = func.Endereco.Estado;
            txtCidade.Text = func.Endereco.Cidade;
            txtBairro.Text = func.Endereco.Bairro;
            txtRua.Text = func.Endereco.Rua;
            txtNumero.Text = func.Endereco.Numero;

            // ************* TERMINAR OS BOTOES DA TELA FRM EDITAR COLABORADOR ************* //
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
                        funcionarioRepository.ExcluirPorId(id);
                        funcionarioRepository.Salvar();

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
                string cepSemMascara = RemoverFormatacaoMascara(txtCep.Text);
                string telefoneSemMascara = RemoverFormatacaoMascara(txtTelefone.Text);

                endereco = new Endereco();
                //endereco.Id = ((Endereco)enderecoRepository.BuscarPorCep(cepSemMascara)).Id;
                endereco.Cep = cepSemMascara;
                endereco.Estado = cboEstados.Text;
                endereco.Cidade = txtCidade.Text;
                endereco.Bairro = txtBairro.Text;
                endereco.Rua = txtRua.Text;
                endereco.Numero = txtNumero.Text;

                funcionario = new Funcionario();
                funcionario.Id = Convert.ToInt16(lblId.Text);
                funcionario.Nome = txtNome.Text;
                funcionario.Telefone = telefoneSemMascara;
                funcionario.Comissao = cboComissao.Text;
                funcionario.Endereco = endereco;

                funcionarioRepository.Atualizar(funcionario);
                funcionarioRepository.Salvar();

                MessageBox.Show("As alterações foram salvas com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente mais tarde ou contate o administrador. \n\n\nDetalhes: \n" + ex.Message, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        public string RemoverFormatacaoMascara(string texto)
        {
            txtTelefone.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            string textoSemMascara = txtTelefone.Text;
            txtTelefone.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

            return textoSemMascara;

        }
    }
}
