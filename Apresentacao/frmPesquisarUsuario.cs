using AcessoBancoDados;
using Negocio.Implementation;
using Negocio.Interfaces;
using System;
using AcessoBancoDados.Models;
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
    public partial class frmPesquisarUsuario : Form
    {        
        IUsuarioRepository usuarioRepository = new UsuarioRepository(new SalaoContext());

        public frmPesquisarUsuario()
        {
            InitializeComponent();
        }

        private void frmPesquisarUsuario_Load(object sender, EventArgs e)
        {            
            dataGridViewUsuarios.DataSource = usuarioRepository.PopulaGrid();
        }

        private void dataGridViewClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = (int)dataGridViewUsuarios.Rows[e.RowIndex].Cells[0].Value;
                string nomeUsuario = dataGridViewUsuarios.Rows[e.RowIndex].Cells[1].Value.ToString();
                string senha = dataGridViewUsuarios.Rows[e.RowIndex].Cells[2].Value.ToString();
                string email = dataGridViewUsuarios.Rows[e.RowIndex].Cells[3].Value.ToString();

                frmEditarUsuario editarUsuario = new frmEditarUsuario(id, nomeUsuario, email, senha);
                editarUsuario.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente ou contate o administrador do sistema. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPesquisar.Text == "")
                {
                    dataGridViewUsuarios.DataSource = usuarioRepository.PopulaGrid();

                } else
                {
                    dataGridViewUsuarios.DataSource = usuarioRepository.BuscarPorNome(txtPesquisar.Text);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente ou contate o administrador do sistema. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
