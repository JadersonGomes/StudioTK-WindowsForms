using AcessoBancoDados;
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
    public partial class frmCadastrarCliente : Form
    {
        IClienteRepository clienteRepository = new ClienteRepository(new SalaoContext());
        Validacao validacao;
        Cliente cliente;
        

        public frmCadastrarCliente()
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
                bool resultadoValidacaoEmail = validacao.ValidarEmail(txtEmail.Text);

                if (!resultadoValidacaoEmail)
                {
                    
                    cliente = new Cliente();                    

                    cliente.Nome = txtNome.Text;
                    cliente.Email = txtEmail.Text;
                    cliente.Telefone = txtTelefone.Text;

                    clienteRepository.Adicionar(cliente);
                    clienteRepository.Salvar();

                    MessageBox.Show("Salvo com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();

                } else
                {
                    MessageBox.Show("E-mail inválido.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente mais tarde ou contate o administrador. \n\n\nDetalhes: \n" + ex.Message, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            txtNome.MaxLength = 40;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            txtEmail.MaxLength = 30;
        }

        private void txtTelefone_TextChanged(object sender, EventArgs e)
        {
            txtTelefone.MaxLength = 20;
        }

        public void LimparCampos()
        {
            txtNome.Clear();
            txtEmail.Clear();
            txtTelefone.Clear();
        }

       
    }
}
