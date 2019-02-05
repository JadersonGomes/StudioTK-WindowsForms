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
    public partial class frmPagamento : Form
    {
        SalaoContext contexto = new SalaoContext();
        Validacao validacao;
        Pagamento pagamento;
        PagamentoRepository pagamentoRepository;
        ProdutoRepository produtoRepository;

        public frmPagamento()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReagendar_Click(object sender, EventArgs e)
        {
            frmAgendar agendar = new frmAgendar();
            agendar.Show();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                validacao = new Validacao();
                bool resultadoValidacao = validacao.ValidarPadrao(this.panel1);

                if (!resultadoValidacao)
                {
                    
                    pagamento = new Pagamento(contexto);
                    pagamentoRepository = new PagamentoRepository(contexto);

                    pagamento.NomeCliente = txtNomeCliente.Text;
                    pagamento.NomeFuncionario = cboFuncionario.SelectedText;
                    pagamento.ServicoRealizado = (Servico)cboServico.SelectedItem;
                    pagamento.FormaPagamento = cboFormaPagamento.SelectedText;
                    pagamento.DataPagamento = Convert.ToDateTime(dtpData.Text);
                    pagamento.Valor = Convert.ToDouble(txtValor.Text);

                    // Recupera o Id do item selecionado e busca na lista de produtos através desse Id
                    pagamento.Produto = produtoRepository.BuscarPorId(((Produto)cboProdutos.SelectedItem).Id);

                    pagamentoRepository.Adicionar(pagamento);
                    pagamentoRepository.Salvar();

                    MessageBox.Show("Pagamento registrado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();

                } else
                {
                    MessageBox.Show("Por gentileza, preencha todos os campos.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
            } catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente ou contate o administrador do sistema. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }        

        private void frmPagamento_Load(object sender, EventArgs e)
        {
            //Servico servico = new Servico(contexto);
            //pagamento = new Pagamento(contexto);            

            //servico.ListarTodos();
            pagamentoRepository = new PagamentoRepository(contexto);


            cboServico.DataSource = pagamentoRepository.PopulaServico();
            cboServico.Text = "[ Selecione ]";
            

            
        }

        public void LimparCampos()
        {
            txtNomeCliente.Clear();
            txtValor.Clear();
            cboFormaPagamento.SelectedIndex = -1;
            cboFuncionario.SelectedIndex = -1;
            cboServico.SelectedIndex = -1;
            dtpData.Value = DateTime.Today;
        }

        private void lblProduto_Click(object sender, EventArgs e)
        {

        }

        private void cboProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboServico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboServico.Text.Equals("Venda"))
            {
                // visible

                cboProdutos.Visible = true;
                lblProduto.Visible = true;


                // size

                groupBox1.Height = 360;
                groupBox1.Width = 765;

                this.Height = 497;
                this.Width = 845;

                panel1.Height = 436;
                panel1.Width = 799;


                // LOCATION

                lblValor.Location = new Point(21, 277);
                lblForma.Location = new Point(270, 275);
                txtValor.Location = new Point(25, 298);
                cboFormaPagamento.Location = new Point(273, 296);
                btnSalvar.Location = new Point(271, 387);
                btnReagendar.Location = new Point(449, 387);
                btnCancelar.Location = new Point(627, 387);
            }
            else
            {
                // visible

                cboProdutos.Visible = false;
                lblProduto.Visible = false;


                // size

                groupBox1.Height = 293;
                groupBox1.Width = 765;

                this.Height = 454;
                this.Width = 845;

                panel1.Height = 388;
                panel1.Width = 799;


                // LOCATION

                lblValor.Location = new Point(21, 211);
                lblForma.Location = new Point(273, 209);
                txtValor.Location = new Point(25, 230);
                cboFormaPagamento.Location = new Point(274, 228);
                btnSalvar.Location = new Point(271, 326);
                btnReagendar.Location = new Point(449, 326);
                btnCancelar.Location = new Point(627, 326);
            }


        }
    }
}
