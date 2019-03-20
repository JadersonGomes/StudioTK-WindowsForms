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
        SalaoContext contexto = new SalaoContext();
        IUsuarioRepository usuarioRepository = new UsuarioRepository(new SalaoContext());

        public frmPesquisarUsuario()
        {
            InitializeComponent();
        }

        private void frmPesquisarUsuario_Load(object sender, EventArgs e)
        {
            usuarioRepository = new UsuarioRepository(contexto);
            dataGridViewUsuarios.DataSource = usuarioRepository.PopulaDataGrid();
        }

        private void dataGridViewClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dataGridViewUsuarios.Rows[e.RowIndex].Cells[0].Value;
            string nomeUsuario = dataGridViewUsuarios.Rows[e.RowIndex].Cells[1].Value.ToString();
            string senha = dataGridViewUsuarios.Rows[e.RowIndex].Cells[2].Value.ToString();
            string email = dataGridViewUsuarios.Rows[e.RowIndex].Cells[3].Value.ToString();            

            frmEditarUsuario editarUsuario = new frmEditarUsuario(id, nomeUsuario, email, senha);
            editarUsuario.Show();
        }
    }
}
