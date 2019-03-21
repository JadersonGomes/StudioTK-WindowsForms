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
            cadastrarProduto.Show();
        }

        private void btnCadasatrarColaborador_Click(object sender, EventArgs e)
        {
            frmCadastrarColaborador cadastrarColaborador = new frmCadastrarColaborador();            
            cadastrarColaborador.Show();
        }

        private void btnCadastrarFornecedor_Click(object sender, EventArgs e)
        {
            frmCadastrarFornecedor cadastrarFornecedor = new frmCadastrarFornecedor();            
            cadastrarFornecedor.Show();
        }

        private void btnCadastrarCliente_Click(object sender, EventArgs e)
        {
            frmCadastrarCliente cadastrarCliente = new frmCadastrarCliente();            
            cadastrarCliente.Show();
        }

        private void btnCadastrarUsuario_Click(object sender, EventArgs e)
        {
            frmCadastrarUsuario cadastrarUsuario = new frmCadastrarUsuario();            
            cadastrarUsuario.Show();
        }

        private void btnCadastrarServico_Click(object sender, EventArgs e)
        {
            frmCadastrarServico cadastrarServico = new frmCadastrarServico();
            cadastrarServico.Show();
        }
    }
}
