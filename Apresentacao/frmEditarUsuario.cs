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
    public partial class frmEditarUsuario : Form
    {
        IUsuarioRepository usuarioRepository = new UsuarioRepository(new SalaoContext());
        Usuario usuario;        
        List<Usuario> listaUsuarios = new List<Usuario>();

        public frmEditarUsuario()
        {
            InitializeComponent();
        }

        public frmEditarUsuario(int pId, string pNomeUsuario, string pEmail, string pSenha)
        {
            InitializeComponent();

            usuario = new Usuario();
            usuario.Id = pId;
            usuario.nomeUsuario = pNomeUsuario;
            usuario.email = pEmail;
            usuario.Senha = pSenha;

            listaUsuarios.Add(usuario);

        }

        private void frmEditarUsuario_Load(object sender, EventArgs e)
        {
            Usuario usuario = listaUsuarios[0];

            lblId.Text = usuario.Id.ToString();
            txtUsuario.Text = usuario.nomeUsuario;
            txtSenha.Text = usuario.Senha;
            txtEmail.Text = usuario.email; 
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
                        usuarioRepository.ExcluirPorId(id);
                        usuarioRepository.Salvar();

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
                usuario = new Usuario();
                usuario.Id = Convert.ToInt16(lblId.Text);
                usuario.nomeUsuario = txtUsuario.Text;
                usuario.Senha = txtSenha.Text;
                usuario.email = txtEmail.Text;

                usuarioRepository.Atualizar(usuario);
                usuarioRepository.Salvar();

                MessageBox.Show("As alterações foram salvas com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente mais tarde ou contate o administrador. \n\n\nDetalhes: \n" + ex.Message, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
