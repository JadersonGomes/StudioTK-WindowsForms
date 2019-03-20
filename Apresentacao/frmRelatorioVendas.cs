using AcessoBancoDados;
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
    public partial class frmRelatorioVendas : Form
    {
        SalaoContext contexto = new SalaoContext();

        public frmRelatorioVendas()
        {
            InitializeComponent();
        }

        private void frmRelatorioVendas_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Venda venda = new Venda(contexto);
            //venda.

        }

        
    }
}
