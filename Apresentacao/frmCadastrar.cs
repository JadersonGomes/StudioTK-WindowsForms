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
    public partial class frmCadastrar : Form
    {
        public frmCadastrar()
        {
            InitializeComponent();
        }

        private void btnCadastrarProduto_Click(object sender, EventArgs e)
        {
            frmCadastrarProduto cadastrarProduto = new frmCadastrarProduto();
            this.Hide();
            cadastrarProduto.Show();
        }

        private void btnCadasatrarColaborador_Click(object sender, EventArgs e)
        {
            frmCadastrarColaborador cadastrarColaborador = new frmCadastrarColaborador();
            this.Hide();
            cadastrarColaborador.Show();
        }

        private void btnCadastrarFornecedor_Click(object sender, EventArgs e)
        {
            frmCadastrarFornecedor cadastrarFornecedor = new frmCadastrarFornecedor();
            this.Hide();
            cadastrarFornecedor.Show();
        }

        private void btnCadastrarCliente_Click(object sender, EventArgs e)
        {
            frmCadastrarCliente cadastrarCliente = new frmCadastrarCliente();
            this.Hide();
            cadastrarCliente.Show();
        }

        private void btnCadastrarUsuario_Click(object sender, EventArgs e)
        {
            frmCadastrarUsuario cadastrarUsuario = new frmCadastrarUsuario();
            this.Hide();
            cadastrarUsuario.Show();
        }
    }
}
