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
    public partial class frmEditarCliente : Form
    {
        IClienteRepository clienteRepository = new ClienteRepository(new SalaoContext());
        Cliente cliente;
        
        List<Cliente> listaClientes = new List<Cliente>();

        public frmEditarCliente()
        {
            InitializeComponent();
        }

        public frmEditarCliente(int pId, string pNome, string pEmail, string pTelefone)
        {
            InitializeComponent();

            cliente = new Cliente();
            cliente.Id = pId;
            cliente.Nome = pNome;
            cliente.Email = pEmail;
            cliente.Telefone = pTelefone;

            listaClientes.Add(cliente);

        }

        private void frmEditarCliente_Load(object sender, EventArgs e)
        {
            cliente = listaClientes[0];
            lblId.Text = cliente.Id.ToString();
            txtNome.Text = cliente.Nome;
            txtTelefone.Text = cliente.Telefone;
            txtEmail.Text = cliente.Email;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt16(lblId.Text);

                if (id > 0)
                {
                    DialogResult resultadoEscolha = MessageBox.Show("Tem certeza que deseja excluir este item?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                    if (resultadoEscolha == DialogResult.Yes)
                    {
                        
                        clienteRepository.ExcluirPorId(id);
                        clienteRepository.Salvar();

                    }
                    else if (resultadoEscolha == DialogResult.No)
                    {

                    }

                }
                else
                {
                    MessageBox.Show("Nenhum item foi selecionado. Por favor, tente novamente mais tarde.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente mais tarde ou contate o administrador. \n\n\nDetalhes: \n" + ex.Message, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                cliente = new Cliente();
                cliente.Id = Convert.ToInt16(lblId.Text);
                cliente.Nome = txtNome.Text;
                cliente.Email = txtEmail.Text;
                cliente.Telefone = RemoverFormatacaoMascara(txtTelefone.Text);

                
                clienteRepository.Atualizar(cliente);
                clienteRepository.Salvar();

                MessageBox.Show("As alterações foram salvas com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente mais tarde ou contate o administrador. \n\n\nDetalhes: \n" + ex.Message, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string RemoverFormatacaoMascara(string texto)
        {
            txtTelefone.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            string textoSemMascara = txtTelefone.Text;
            txtTelefone.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

            return textoSemMascara;

        }
    }
}
