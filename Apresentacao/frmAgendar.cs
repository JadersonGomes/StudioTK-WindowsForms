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
    public partial class frmAgendar : Form
    {
        IAgendaRepository agendarRepository = new AgendaRepository(new SalaoContext());

        Agenda agendamento;
        Validacao validacao;
        List<string> lista;

        bool selecionouData = false;

        public frmAgendar()
        {
            InitializeComponent();
        }


        private void btnAgendar_Click(object sender, EventArgs e)
        {
            try
            {
                agendamento = new Agenda(new SalaoContext());

                agendamento.NomeCliente = txtNomeCliente.Text;
                agendamento.Data = Convert.ToDateTime(dtpDataAgendamento.Value);
                agendamento.Horario = cboHorario.Text;
                agendamento.Servico = (Servico)cboServico.SelectedItem;
                agendamento.Funcionario = (Funcionario)cboColaborador.SelectedItem;

                // Trecho responsável por salvar o agendamento no Banco de dados.
                /*agendarRepository.Adicionar(agendamento);
                agendarRepository.Salvar();*/
                

                MessageBox.Show("Agendado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente ou contate o administrador do sistema. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAgendar_Load(object sender, EventArgs e)
        {            
            cboServico.DataSource = agendarRepository.PopulaServico();
            cboColaborador.DataSource = agendarRepository.PopulaColaborador();

        }

        private void dtpDataAgendamento_ValueChanged(object sender, EventArgs e)
        {
            agendamento = new Agenda(new SalaoContext());

            lista = agendarRepository.PopulaComboHora(dtpDataAgendamento.Value, cboHorario.Text);

            cboHorario.DataSource = lista;            

            selecionouData = true;

        }


        private void cboHorario_MouseClick(object sender, MouseEventArgs e)
        {
            if (!selecionouData)
            {
                MessageBox.Show("Por gentileza, selecione uma data.", "Observação.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }
                

        private void btnVisualizarAgenda_Click(object sender, EventArgs e)
        {
            if (selecionouData && cboColaborador.Text != String.Empty)
            {
                frmVisualizarAgenda visualizarAgenda = new frmVisualizarAgenda(dtpDataAgendamento.Value, cboColaborador.SelectedText);
                visualizarAgenda.Show();

            }
            else
            {
                MessageBox.Show("Por gentileza, selecione a Data e um Colaborador.", "Observação.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
        }

        public void LimparCampos()
        {
            txtNomeCliente.Clear();
            cboColaborador.SelectedIndex = -1;
            cboServico.SelectedIndex = -1;
            cboHorario.SelectedIndex = -1;
            dtpDataAgendamento.Value = DateTime.Now.Date;

        }
    }
}
