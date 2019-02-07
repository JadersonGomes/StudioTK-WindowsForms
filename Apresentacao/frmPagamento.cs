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
    public partial class frmPagamento : Form
    {
        //SalaoContext contexto = new SalaoContext();
        
        Pagamento pagamento = new Pagamento(new SalaoContext());
        IPagamentoRepository pagamentoRepository = new PagamentoRepository(new SalaoContext());
        IProdutoRepository produtoRepository = new ProdutoRepository(new SalaoContext());
        Validacao validacao;

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

        private void frmPagamento_Load(object sender, EventArgs e)
        {
            //Servico servico = new Servico(contexto);
            //pagamento = new Pagamento(contexto);            

            //servico.ListarTodos();

            listViewServicos.Items.Add("                             LISTA DE SERVIÇOS À PAGAR");
            listViewServicos.Items.Add(" ");
            listViewServicos.Items.Add(" ");
            listViewServicos.Items.Add(" ");           


            cboServico.DataSource = pagamentoRepository.PopulaServico();
            cboProdutos.DataSource = pagamentoRepository.PopulaProduto();
            //cboServico.Text = "[ Selecione ]";           


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


        private void cboServico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboServico.Text.Equals("Venda"))
            {
                // visible

                cboProdutos.Visible = true;
                //txtQntd.Visible = true;
                lblProduto.Visible = true;
                //lblQntd.Visible = true;


                // size

                /*groupBox1.Height = 360;
                //groupBox1.Width = 765;

                this.Height = 497;
                this.Width = 845;

                panel1.Height = 436;
                panel1.Width = 799;*/


                // LOCATION

                lblValor.Location = new Point(21, 277);
                lblForma.Location = new Point(266, 277);
                txtValor.Location = new Point(25, 298);
                cboFormaPagamento.Location = new Point(269, 298);
                btnSalvar.Location = new Point(47, 387);
                btnAdicionarNaLista.Location = new Point(230, 387);
                btnReagendar.Location = new Point(413, 387);
                btnCancelar.Location = new Point(596, 387);
            }
            else
            {
                // visible

                cboProdutos.Visible = false;
                //txtQntd.Visible = false;
                lblProduto.Visible = false;
                //lblQntd.Visible = false;


                // size

                /*groupBox1.Height = 293;
                /groupBox1.Width = 765;

                this.Height = 454;
                this.Width = 845;
            
                panel1.Height = 388;
               /panel1.Width = 799;*/


                // LOCATION

                lblValor.Location = new Point(21, 211);
                lblForma.Location = new Point(265, 212);
                txtValor.Location = new Point(25, 230);
                cboFormaPagamento.Location = new Point(268, 230);
                btnSalvar.Location = new Point(47, 389);
                btnAdicionarNaLista.Location = new Point(230, 389);
                btnReagendar.Location = new Point(413, 389);
                btnCancelar.Location = new Point(596, 389);
            }


        }

        private void txtQntd_TextChanged(object sender, EventArgs e)
        {

            /*try
            {
                if (!cboProdutos.Text.Equals(String.Empty) && !txtQntd.Text.Equals(String.Empty))
                {
                    double valorProduto = ((Produto)cboProdutos.SelectedItem).Valor;
                    int quantidade = Convert.ToInt32(txtQntd.Text);

                    pagamento.Valor += (valorProduto * quantidade);
                    txtValor.Text = pagamento.Valor.ToString();
                }
                else if (cboProdutos.Text.Equals(String.Empty))
                {
                    MessageBox.Show("Por gentileza, selecione um produto.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtQntd.Clear();
                }
                else
                {
                    txtValor.Clear();
                }
            }
            catch (OverflowException ex)
            {
                // Cairá nessa exceção caso o número digitado na caixa de texto seja grande demais.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente ou contate o administrador do sistema. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/


        }

        private void txtQntd_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número e se for diferente da tecla "BackSpace"
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número e se for diferente da tecla "BackSpace"
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }

        private void btnAdicionarNaLista_Click(object sender, EventArgs e)
        {
            Servico servico = ((Servico)cboServico.SelectedItem);
            Produto produto = ((Produto)cboProdutos.SelectedItem);


            if (!servico.Nome.Equals("Venda"))
            {                
                pagamento.Valor += servico.Valor;
                txtValor.Text = pagamento.Valor.ToString();

                listViewServicos.Items.Add("+  " + servico.Nome + "......................." + "R$ " + servico.Valor + ",00");
                listViewServicos.Items.Add(" ");
            }
            else
            {
                int quantidade = Convert.ToInt32(txtQntd.Text);
                double valorTotalProduto = (produto.Valor * quantidade);                

                pagamento.Valor += valorTotalProduto;                
                txtValor.Text = pagamento.Valor.ToString();

                listViewServicos.Items.Add("+  " + produto.Descricao + "......................." + "R$ " + valorTotalProduto + ",00");
                listViewServicos.Items.Add(" ");
            }



        }

        private void cboProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ckbDesconto_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbDesconto.Checked)
            {
                cboDesconto.Visible = true;

            } else
            {
                cboDesconto.Visible = false;
            }
            
        }

        private void cboDesconto_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            double valor = pagamento.Valor;
            double desconto = 0;

            switch (cboDesconto.Text)
            {               

                case "5%":
                    desconto = valor * 0.05;
                    pagamento.Valor -= desconto;
                    txtValor.Text = pagamento.Valor.ToString();                    
                    break;

                case "10%":
                    desconto = valor * 0.10;
                    pagamento.Valor -= desconto;
                    txtValor.Text = pagamento.Valor.ToString();
                    break;

                case "15%":
                    desconto = valor * 0.15;
                    pagamento.Valor -= desconto;
                    txtValor.Text = pagamento.Valor.ToString();
                    break;

                case "20%":
                    desconto = valor * 0.20;
                    pagamento.Valor -= desconto;
                    txtValor.Text = pagamento.Valor.ToString();
                    break;

                case "25%":
                    desconto = valor * 0.25;
                    pagamento.Valor -= desconto;
                    txtValor.Text = pagamento.Valor.ToString();
                    break;

                case "30%":
                    desconto = valor * 0.30;
                    pagamento.Valor -= desconto;
                    txtValor.Text = pagamento.Valor.ToString();
                    break;

                case "35%":
                    desconto = valor * 0.35;
                    pagamento.Valor -= desconto;
                    txtValor.Text = pagamento.Valor.ToString();
                    break;

                case "40%":
                    desconto = valor * 0.40;
                    pagamento.Valor -= desconto;
                    txtValor.Text = pagamento.Valor.ToString();
                    break;

                case "45%":
                    desconto = valor * 0.45;
                    pagamento.Valor -= desconto;
                    txtValor.Text = pagamento.Valor.ToString();
                    break;

                case "50%":
                    desconto = valor * 0.50;
                    pagamento.Valor -= desconto;
                    txtValor.Text = pagamento.Valor.ToString();
                    break;

                default:
                    txtValor.Text = pagamento.Valor.ToString();
                    break;
            }
        }
    }
}
