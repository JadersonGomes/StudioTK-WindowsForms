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
    public partial class frmEditarServico : Form
    {
        IFuncionarioRepository funcionarioRepository = new FuncionarioRepository(new SalaoContext());
        IServicoRepository servicoRepository = new ServicoRepository(new SalaoContext());
        Servico servico;

        List<Servico> listaServicos = new List<Servico>();
        List<Funcionario> listaFuncionarios = new List<Funcionario>();

        public frmEditarServico()
        {
            InitializeComponent();
        }

        public frmEditarServico(int pId, string pNome, double pValor)
        {
            InitializeComponent();

            // Cria um Objeto do tipo Servico e usa o mesmo como objeto de transferência para receber os dados que vieram das linhas do DataGridView.
            servico = new Servico();
            servico.Id = pId;
            servico.Nome = pNome;
            servico.Valor = pValor;            
            
            // Consulta LinQ utilizando o Join para pegar somente os Funcionarios que estão relacionados com Servico
            var list = (from lista in funcionarioRepository.ListarTodos()
                                   join lista2 in servicoRepository.ListarTodos()
                                   on lista.Id equals lista2.Id
                                   select new
                                   {
                                       lista,
                                       lista2

                                   }).ToList();

            // Percorre toda a lista para adicionar cada funcionario dentro do atributo do objeto de transferência.
            foreach (var item in list)
            {
                // Busca o Funcionario para depois adicioná-lo na tabela de Join
                var func = funcionarioRepository.BuscarPorId(item.lista.Id);
                servico.Funcionarios.Add(new FuncionarioServico() { Funcionario = func });

            }

            // Salva o Servico numa lista para que o seu estado seja recuperado no próximo método
            listaServicos.Add(servico);          



        }

        private void frmEditarServico_Load(object sender, EventArgs e)
        {
            lblId.Text = (listaServicos[0].Id).ToString();
            txtDescricao.Text = listaServicos[0].Nome;
            txtValor.Text = (listaServicos[0].Valor).ToString();
            cboFuncionarios.DataSource = listaServicos[0].Funcionarios;

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Funcionario funcionario = new Funcionario();
                Servico servico = new Servico();
                servico.Id = Convert.ToInt32(lblId.Text);
                servico.Nome = txtDescricao.Text;
                servico.Valor = Convert.ToDouble(txtValor.Text);

                foreach (var item in cboFuncionarios.Items)
                {
                    funcionario = (Funcionario)item;
                    servico.Funcionarios.Add(new FuncionarioServico() { Funcionario = funcionario });

                }

                servicoRepository.Atualizar(servico);
                servicoRepository.Salvar();

                MessageBox.Show("Alterações realizadas com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente mais tarde ou contate o administrador. \n\n\nDetalhes: \n" + ex.Message, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
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
                        servicoRepository.ExcluirPorId(id);
                        servicoRepository.Salvar();

                    }
                    else if (resultadoEscolha == DialogResult.No)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente mais tarde ou contate o administrador. \n\n\nDetalhes: \n" + ex.Message, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtAtrelarServicoAoFuncionario_Click(object sender, EventArgs e)
        {
            Funcionario funcionario = (Funcionario)cboFuncionarios.SelectedItem;
            listaFuncionarios.Add(funcionario);
        }

        private void RemoverFuncionarioServico_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(lblId.Text);

            if (id > 0)
            {
                DialogResult resultadoEscolha = MessageBox.Show("Tem certeza que deseja remover este Colaborador da lista?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (resultadoEscolha == DialogResult.Yes)
                {
                    cboFuncionarios.Items.Remove(cboFuncionarios.SelectedIndex);

                }
                else if (resultadoEscolha == DialogResult.No)
                {

                }
            }
        }
    }
}
