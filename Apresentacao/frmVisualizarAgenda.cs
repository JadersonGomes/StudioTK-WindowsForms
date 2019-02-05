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
    public partial class frmVisualizarAgenda : Form
    {
        SalaoContext contexto = new SalaoContext();
        AgendarRepository agendarRepository;
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
                //panel1.Top = (lblAgendamento.Height - panel1.Height) / 2;
                //panel1.Left = (lblAgendamento.Width - panel1.Width) / 2;

                lblAgendamento.Top = (panel1.Height - lblAgendamento.Height) / 2;
                lblAgendamento.Left = (panel1.Width - lblAgendamento.Width) / 2;

                agendarRepository = new AgendarRepository(contexto);
                // Perguntar p Karol como ela prefere que a Agenda seja exibida (Agenda de todos ou Agenda do colaborador selecionado)
                dataGridView1.DataSource = agendarRepository.ListarPorDataColaborador(data, colaborador);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente ou contate o administrador do sistema. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
