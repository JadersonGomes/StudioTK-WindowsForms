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
    public partial class frmPesquisar : Form
    {
        public frmPesquisar()
        {
            InitializeComponent();
        }

        private void btnCadastrarServico_Click(object sender, EventArgs e)
        {
            frmFiltrarServico filtrarServico = new frmFiltrarServico();
            filtrarServico.Show();
        }

        private void btnCadastrarCliente_Click(object sender, EventArgs e)
        {
            frmPesquisarCliente pesquisarCliente = new frmPesquisarCliente();
            pesquisarCliente.Show();
        }

        private void btnCadastrarProduto_Click(object sender, EventArgs e)
        {
            frmPesquisarProduto pesquisarProduto = new frmPesquisarProduto();
            pesquisarProduto.Show();
        }

        private void btnCadasatrarColaborador_Click(object sender, EventArgs e)
        {
            frmPesquisarFuncionario pesquisarFuncionario = new frmPesquisarFuncionario();
            pesquisarFuncionario.Show();
        }

        private void btnCadastrarFornecedor_Click(object sender, EventArgs e)
        {
            frmPesquisarFornecedor pesquisarFornecedor = new frmPesquisarFornecedor();
            pesquisarFornecedor.Show();
        }

        private void btnCadastrarUsuario_Click(object sender, EventArgs e)
        {
            frmPesquisarUsuario pesquisarUsuario = new frmPesquisarUsuario();
            pesquisarUsuario.Show();
        }
    }
}
