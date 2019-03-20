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
    public partial class frmEditarAgendamento : Form
    {       
        
        IAgendaRepository agendarRepository = new AgendaRepository(new SalaoContext());
        Agenda agendamento;
        List<Agenda> listaAgendamento = new List<Agenda>();
        bool selecionouData = false;

        public frmEditarAgendamento()
        {
            InitializeComponent();
        }

        public frmEditarAgendamento(string id, string data, Funcionario funcionario, string nomeCliente, string horario, Servico servico)
        {
            InitializeComponent();
            agendamento = new Agenda();
            agendamento.Id = Convert.ToInt16(id);
            agendamento.NomeCliente = nomeCliente;
            agendamento.Data = Convert.ToDateTime(data);
            agendamento.Horario = horario;
            agendamento.Servico = servico;
            agendamento.Funcionario = funcionario;

            listaAgendamento.Add(agendamento);
        }

        private void frmEditarAgendamento_Load(object sender, EventArgs e)
        {
            Agenda agenda = listaAgendamento[0];

            lblId.Text = agenda.Id.ToString();
            txtNomeCliente.Text = agenda.NomeCliente;
            dtpDataAgendamento.Text = agenda.Data.ToShortDateString();
            //cboHorarioInicial.Text = agenda.Horario;
            cboServico.Text = agenda.Servico.Nome;
            cboColaborador.Text = agenda.Funcionario.Nome;
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
                        agendarRepository.ExcluirPorId(id);
                        agendarRepository.Salvar();                       

                    }
                    else if (resultadoEscolha == DialogResult.No)
                    {
                        
                    }

                    

                } else
                {
                    MessageBox.Show("Nenhum item foi selecionado. Por favor, tente novamente mais tarde.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente mais tarde ou contate o administrador. \n\n\nDetalhes: \n" + ex.Message, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            try
            {

                Agenda agenda = new Agenda();

                agenda.Id = Convert.ToInt16(lblId.Text);
                agenda.NomeCliente = txtNomeCliente.Text;
                agenda.Data = dtpDataAgendamento.Value;
                agenda.Horario = cboHorarioInicial.Text;
                agenda.Servico = ((Servico)cboServico.SelectedItem);
                agenda.Funcionario = ((Funcionario)cboColaborador.SelectedItem);

                
                agendarRepository.Atualizar(agenda);
                agendarRepository.Salvar();

                MessageBox.Show("As alterações foram salvas com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente mais tarde ou contate o administrador. \n\n\nDetalhes: \n" + ex.Message, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpDataAgendamento_ValueChanged(object sender, EventArgs e)
        {
            Agenda agenda = listaAgendamento[0];
            var lista = agendarRepository.PopulaComboHora(dtpDataAgendamento.Value, cboHorarioInicial.Text/*, cboHorarioFinal.Text*/);

            cboHorarioInicial.DataSource = lista;
            cboHorarioInicial.Text = listaAgendamento[0].Horario;
            //cboHorarioFinal.DataSource = cboHorarioInicial.Items;

            selecionouData = true;
        }

        private void cboHorarioInicial_MouseClick(object sender, MouseEventArgs e)
        {
            if (!selecionouData)
            {
                MessageBox.Show("Por gentileza, selecione uma data.", "Observação.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}
