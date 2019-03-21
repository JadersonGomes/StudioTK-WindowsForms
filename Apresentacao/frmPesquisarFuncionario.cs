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
    public partial class frmPesquisarFuncionario : Form
    {
        IFuncionarioRepository funcionarioRepository = new FuncionarioRepository(new SalaoContext());
        Funcionario funcionario;
        

        public frmPesquisarFuncionario()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (txtPesquisar.Text == "")
            {
                dataGridViewFuncionarios.DataSource = funcionarioRepository.ListarTodos();
            }
            else
            {
                try
                {                    
                    dataGridViewFuncionarios.DataSource = funcionarioRepository.ListarPorTelefone(txtPesquisar.Text);

                }
                catch (Exception ex)
                {
                    dataGridViewFuncionarios.DataSource = funcionarioRepository.ListarPorNome(txtPesquisar.Text);

                }

            }
        }

        private void frmPesquisarFuncionario_Load(object sender, EventArgs e)
        {            
            dataGridViewFuncionarios.DataSource = funcionarioRepository.PopulaGrid();

        }

        private void dataGridViewFuncionarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dataGridViewFuncionarios.Rows[e.RowIndex].Cells[0].Value;
            string nome = dataGridViewFuncionarios.Rows[e.RowIndex].Cells[1].Value.ToString();            
            string telefone = dataGridViewFuncionarios.Rows[e.RowIndex].Cells[2].Value.ToString();
            double comissao = (double)dataGridViewFuncionarios.Rows[e.RowIndex].Cells[3].Value;
            Endereco endereco = (Endereco)dataGridViewFuncionarios.Rows[e.RowIndex].Cells[4].Value;

            frmEditarColaborador editarColaborador = new frmEditarColaborador(id, nome, telefone, comissao, endereco);
            editarColaborador.Show();

        }
    }
}
