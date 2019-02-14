using AcessoBancoDados;
using Negocio.Implementation;
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
    public partial class frmPesquisarCliente : Form
    {
        SalaoContext contexto = new SalaoContext();
        Cliente cliente;
        ClienteRepository clienteRepository;
        public frmPesquisarCliente()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            cliente = new Cliente(contexto);            

            if (txtPesquisar.Text == "")
            {
                dataGridViewClientes.DataSource = cliente.ListarTodos();
            }
            else
            {
                try
                {
                    var t = Convert.ToInt64(txtPesquisar.Text);
                    dataGridViewClientes.DataSource = cliente.ListarPorTelefone(txtPesquisar.Text); 
                }
                catch (Exception ex)
                {                    
                    dataGridViewClientes.DataSource = cliente.ListarPorNome(txtPesquisar.Text);

                }
                
            }
        }

        private void frmPesquisarCliente_Load(object sender, EventArgs e)
        {
            clienteRepository = new ClienteRepository(contexto);

            dataGridViewClientes.DataSource = clienteRepository.PopulaDataGrid();
        }

        private void dataGridViewClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dataGridViewClientes.Rows[e.RowIndex].Cells[0].Value;
            string nome = dataGridViewClientes.Rows[e.RowIndex].Cells[1].Value.ToString();
            string email = dataGridViewClientes.Rows[e.RowIndex].Cells[2].Value.ToString();
            string telefone = dataGridViewClientes.Rows[e.RowIndex].Cells[3].Value.ToString();


            frmEditarCliente editarCliente = new frmEditarCliente(id, nome, email, telefone);
            editarCliente.Show();
            
        }
    }
}
