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
    public partial class frmCadastrarUsuario : Form
    {
        IUsuarioRepository usuarioRepository = new UsuarioRepository(new SalaoContext());
        Validacao validacao;
        Usuario usuario;

        public frmCadastrarUsuario()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                validacao = new Validacao();
                bool emailValido = validacao.ValidarEmail(txtEmail.Text);

                // O método validarUsuario retorna um booleano informando se o mesmo possui algum campo vazio. Vazio = true, preenchido = false
                if (emailValido)
                {
                    usuario = new Usuario();

                    usuario.nomeUsuario = txtUsuario.Text;
                    //usuario.Senha = txtSenha.Text;
                    usuario.email = txtEmail.Text;

                    usuarioRepository.Adicionar(usuario);
                    usuarioRepository.Salvar();

                    MessageBox.Show("Salvo com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("E-mail inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
