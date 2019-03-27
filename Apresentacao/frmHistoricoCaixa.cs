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
    public partial class frmHistoricoCaixa : Form
    {
        ICaixaRepository caixaRepository = new CaixaRepository(new SalaoContext());

        public frmHistoricoCaixa()
        {
            InitializeComponent();
        }

        private void frmHistoricoCaixa_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView.DataSource = caixaRepository.ListarTodosOrdenados();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado ao tentar abrir a nova janela. Tente novamente ou contate o administrador do sistema. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dataGridView.DataSource = caixaRepository.BuscarPorPeriodo(dtpInicial.Value, dtpFinal.Value);
        }
    }
}
