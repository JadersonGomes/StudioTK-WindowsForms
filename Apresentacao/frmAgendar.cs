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
    public partial class frmAgendar : Form
    {
        SalaoContext contexto = new SalaoContext();
        Agendar agendamento;
        AgendarRepository agendarRepository;
        Validacao validacao;
        List<string> lista;
        List<Agendar> listaAgendamento = new List<Agendar>();


        bool selecionouData = false;

        public frmAgendar()
        {
            InitializeComponent();
        }

        

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            try
            {
                validacao = new Validacao();

                if (validacao.ValidarAgendamento(this.panel1))
                {                    
                    agendamento = new Agendar(contexto);
                    agendarRepository = new AgendarRepository(contexto);

                    /* agendamento.NomeCliente = txtNomeCliente.Text;
                     agendamento.Data = Convert.ToDateTime(dtpDataAgendamento.Value);
                     agendamento.HorarioInicial = cboHorarioInicial.SelectedValue.ToString();
                     agendamento.HorarioFinal = cboHorarioFinal.SelectedValue.ToString();
                     agendamento.Servico = (Servico)cboServico.SelectedItem;
                     agendamento.Funcionario = (Funcionario)cboColaborador.SelectedItem;

                     agendarRepository.Adicionar(agendamento);
                     agendarRepository.Salvar();*/

                    //agendarRepository.AtualizarHorario(lista, cboHorarioInicial.Text, cboHorarioFinal.Text);

                    MessageBox.Show("Agendado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Por gentileza, preencha todos os campos.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
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
            //agendamento = new Agendar(contexto);
            cboServico.DataSource = agendamento.PopulaServico();
            cboColaborador.DataSource = agendamento.PopulaColaborador();

            

        }        

        private void dtpDataAgendamento_ValueChanged(object sender, EventArgs e)
        {
            agendamento = new Agendar(contexto);
            
            lista = agendamento.PopulaComboHora(dtpDataAgendamento.Value, cboHorarioInicial.Text/*, cboHorarioFinal.Text*/);           
            
            cboHorarioInicial.DataSource = lista;
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

        public void LimparCampos()
        {
            txtNomeCliente.Clear();
            cboColaborador.SelectedIndex = 0;
            //cboHorarioFinal.SelectedIndex = 0;
            cboServico.SelectedIndex = 0;
            dtpDataAgendamento.Value = DateTime.Now.Date;
        }

        private void btnVisualizarAgenda_Click(object sender, EventArgs e)
        {
            if (selecionouData)
            {
                frmVisualizarAgenda visualizarAgenda = new frmVisualizarAgenda(dtpDataAgendamento.Value, cboColaborador.SelectedText);
                visualizarAgenda.Show();
            }
            else
            {
                MessageBox.Show("Por gentileza, selecione uma data.", "Observação.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}
