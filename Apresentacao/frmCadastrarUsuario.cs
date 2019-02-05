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
    public partial class frmCadastrarUsuario : Form
    {
        SalaoContext contexto = new SalaoContext();
        Validacao validacao;
        Usuario usuario;
        UsuarioRepository usuarioRepository;

        public frmCadastrarUsuario()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                validacao = new Validacao();
                bool campoVazio = validacao.ValidarUsuario(this.panel1);
                bool emailValido = validacao.ValidarEmail(txtEmail.Text);

                // O método validarUsuario retorna um booleano informando se o mesmo possui algum campo vazio. Vazio = true, preenchido = false
                if (!campoVazio && emailValido)
                {
                    
                    usuario = new Usuario(contexto);
                    usuarioRepository = new UsuarioRepository(contexto);

                    usuario.nomeUsuario = txtUsuario.Text;
                    //usuario.Senha = txtSenha.Text;
                    usuario.email = txtEmail.Text;

                    usuarioRepository.Adicionar(usuario);
                    usuarioRepository.Salvar();

                    MessageBox.Show("Salvo com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (campoVazio)
                    {
                        MessageBox.Show("Por gentileza, preencha todos os campos.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                    

            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente mais tarde ou contate o administrador. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            frmCadastrar cadastrar = new frmCadastrar();
            cadastrar.Show();
        }
    }
}
