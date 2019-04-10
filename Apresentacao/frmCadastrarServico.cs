using AcessoBancoDados.Models;
using Negocio.Implementation;
using Negocio.Interfaces;
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
    public partial class frmCadastrarServico : Form
    {
        IServicoRepository servicoRepository = new ServicoRepository(new SalaoContext());
        IFuncionarioRepository funcionarioRepository = new FuncionarioRepository(new SalaoContext());
        List<Funcionario> listaFuncionarios = new List<Funcionario>();
        Servico servico;

        public frmCadastrarServico()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAtrelarServicoAoUsuario_Click(object sender, EventArgs e)
        {
            Funcionario funcionario = (Funcionario)cboFuncionarios.SelectedItem;
            listaFuncionarios.Add(funcionario);
            // Verificar depois se realmente será excluído do combo após a execução da linha de baixo
            cboFuncionarios.Items.Remove(this);      

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                servico = new Servico();
                servico.Nome = txtDescricao.Text;
                servico.Valor = Convert.ToDouble(txtValor.Text);                

                foreach (var item in listaFuncionarios)
                {                    
                    servico.Funcionarios.Add(new FuncionarioServico() { Funcionario = item });

                }

                servicoRepository.Adicionar(servico);
                servicoRepository.Salvar();

                MessageBox.Show("Salvo com sucesso!", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();



            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente mais tarde ou contate o administrador. \n\n\nDetalhes: \n" + ex.Message, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            txtDescricao.Clear();
            txtValor.Clear();
            cboFuncionarios.SelectedIndex = -1;
        }
    }
}
