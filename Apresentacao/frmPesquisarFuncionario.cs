using AcessoBancoDados;
using Negocio.Implementation;
using Negocio.Interfaces;
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
    public partial class frmPesquisarFuncionario : Form
    {
        SalaoContext contexto = new SalaoContext();
        Funcionario funcionario;
        IFuncionarioRepository funcionarioRepository = new FuncionarioRepository(new SalaoContext());

        public frmPesquisarFuncionario()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            funcionario = new Funcionario(contexto);

            if (txtPesquisar.Text == "")
            {
                dataGridViewFuncionarios.DataSource = funcionario.ListarTodos();
            }
            else
            {
                try
                {
                    var t = Convert.ToInt64(txtPesquisar.Text);
                    dataGridViewFuncionarios.DataSource = funcionario.ListarPorTelefone(txtPesquisar.Text);
                }
                catch (Exception ex)
                {
                    dataGridViewFuncionarios.DataSource = funcionario.ListarPorNome(txtPesquisar.Text);

                }

            }
        }

        private void frmPesquisarFuncionario_Load(object sender, EventArgs e)
        {            
            dataGridViewFuncionarios.DataSource = funcionarioRepository.PopulaDataGrid();
        }

        private void dataGridViewFuncionarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dataGridViewFuncionarios.Rows[e.RowIndex].Cells[0].Value;
            string nome = dataGridViewFuncionarios.Rows[e.RowIndex].Cells[1].Value.ToString();            
            string telefone = dataGridViewFuncionarios.Rows[e.RowIndex].Cells[2].Value.ToString();
            string comissao = dataGridViewFuncionarios.Rows[e.RowIndex].Cells[3].Value.ToString();
            Endereco endereco = (Endereco)dataGridViewFuncionarios.Rows[e.RowIndex].Cells[4].Value;


            frmEditarColaborador editarColaborador = new frmEditarColaborador(id, nome, telefone, comissao, endereco);
            editarColaborador.Show();
        }
    }
}
