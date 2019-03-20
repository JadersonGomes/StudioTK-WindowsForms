using AcessoBancoDados;
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
    public partial class frmVisualizarAgenda : Form
    {        
        IAgendaRepository agendaRepository = new AgendaRepository(new SalaoContext());

        // As variáveis abaixo servem para recuperar parametros passados pelo construtor
        private DateTime data;
        private string colaborador;

        public frmVisualizarAgenda()
        {
            InitializeComponent();
        }

        public frmVisualizarAgenda(DateTime pData, string pColaborador)
        {
            InitializeComponent();
            this.data = pData;
            this.colaborador = pColaborador;
        }

        private void frmVisualizarAgenda_Load(object sender, EventArgs e)
        {
            try
            {
                // O código abaixo traduz o dia da semana recuperado para português
                var culture = new System.Globalization.CultureInfo("pt-PT");
                var diaSemana = culture.DateTimeFormat.GetDayName(data.DayOfWeek);

                lblAgendamento.Text = "AGENDA DIA " + data.Date.ToShortDateString() + " - " + diaSemana.ToUpper();

                // O código abaixo serve para centralizar o Label dinamicamente
                lblAgendamento.Top = (panel1.Height - lblAgendamento.Height) / 2;
                lblAgendamento.Left = (panel1.Width - lblAgendamento.Width) / 2;
                
                // Perguntar p Karol como ela prefere que a Agenda seja exibida (Agenda de todos ou Agenda do colaborador selecionado)
                dataGridView1.DataSource = agendaRepository.ListarPorDataColaborador(data, colaborador);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente ou contate o administrador do sistema. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
