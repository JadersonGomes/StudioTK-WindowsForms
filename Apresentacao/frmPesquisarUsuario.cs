using AcessoBancoDados;
using Negocio.Implementation;
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
    public partial class frmPesquisarUsuario : Form
    {
        SalaoContext contexto = new SalaoContext();
        UsuarioRepository usuarioRepository;

        public frmPesquisarUsuario()
        {
            InitializeComponent();
        }

        private void frmPesquisarUsuario_Load(object sender, EventArgs e)
        {
            usuarioRepository = new UsuarioRepository(contexto);
            dataGridViewClientes.DataSource = usuarioRepository.PopulaDataGrid();
        }

        private void dataGridViewClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmEditarUsuario editarUsuario = new frmEditarUsuario();
            editarUsuario.Show();
        }
    }
}
