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
    public partial class frmPesquisarCliente : Form
    {
        IClienteRepository clienteRepository = new ClienteRepository(new SalaoContext());
        Cliente cliente;
        
        public frmPesquisarCliente()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
                  

            if (txtPesquisar.Text == "")
            {
                dataGridViewClientes.DataSource = clienteRepository.ListarTodos();
            }
            else
            {
                try
                {
                    // Duas opções de busca (Nome e Telefone). Tenta converter para inteiro o valor, caso não consiga ele busca por nome.
                    var telefone = Convert.ToInt64(txtPesquisar.Text);
                    dataGridViewClientes.DataSource = clienteRepository.ListarPorTelefone(txtPesquisar.Text); 
                }
                catch (Exception ex)
                {                    
                    dataGridViewClientes.DataSource = clienteRepository.ListarPorNome(txtPesquisar.Text);

                }
                
            }
        }

        private void frmPesquisarCliente_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridViewClientes.DataSource = clienteRepository.PopulaGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado ao tentar abrir a nova janela. Tente novamente ou contate o administrador do sistema. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            

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
