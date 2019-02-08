using AcessoBancoDados;
using Negocio.Implementation;
using Negocio.Interfaces;
using Negocio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
                    string valorPagamentoSemFormatacao = RemoverFormatacaoMoeda(txtValor.Text);
                    pagamento.NomeCliente = txtNomeCliente.Text;
                    pagamento.NomeFuncionario = cboFuncionario.SelectedText;
                    pagamento.ServicoRealizado = (Servico)cboServico.SelectedItem;
                    pagamento.FormaPagamento = cboFormaPagamento.SelectedText;
                    pagamento.DataPagamento = Convert.ToDateTime(dtpData.Text);
                    pagamento.Valor = Convert.ToDouble(valorPagamentoSemFormatacao);

                    // Verifica se o Produto está nulo e recupera o Id do item selecionado e busca na lista de produtos através desse Id, caso não esteja
                    if (((Produto)cboProdutos.SelectedItem) != null)
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
                // Carrega o combobox de Produtos
                cboProdutos.DataSource = pagamentoRepository.PopulaProduto();

                // visible

                cboProdutos.Visible = true;
                txtQntd.Visible = true;
                lblProduto.Visible = true;
                lblQntd.Visible = true;


                // size

                groupBox1.Height = 441;
                groupBox1.Width = 765;

                listViewServicos.Height = 531;
                listViewServicos.Width = 371;

                this.Height = 592;
                this.Width = 1218;

                panel1.Height = 592;
                panel1.Width = 799;


                // LOCATION

                cboDesconto.Location = new Point(23, 364);
                ckbDesconto.Location = new Point(23, 339);
                lblRecebido.Location = new Point(21, 277);
                lblForma.Location = new Point(266, 277);
                txtRecebido.Location = new Point(25, 298);
                //txtValor.Location = new Point(527, 297);
                cboFormaPagamento.Location = new Point(269, 298);
                btnSalvar.Location = new Point(47, 477);
                btnAdicionarNaLista.Location = new Point(230, 477);
                btnReagendar.Location = new Point(413, 477);
                btnCancelar.Location = new Point(596, 477);
            }
            else
            {
                // visible

                cboProdutos.Visible = false;
                txtQntd.Visible = false;
                lblProduto.Visible = false;
                lblQntd.Visible = false;


                // size

                groupBox1.Height = 348;
                groupBox1.Width = 765;

                panel1.Height = 442;
                panel1.Width = 799;

                listViewServicos.Height = 415;
                listViewServicos.Width = 371;

                this.Height = 510;
                this.Width = 1218;



                // LOCATION

                cboDesconto.Location = new Point(23, 297);
                ckbDesconto.Location = new Point(23, 272);
                lblRecebido.Location = new Point(21, 211);
                lblForma.Location = new Point(265, 212);
                txtRecebido.Location = new Point(25, 230);
                cboFormaPagamento.Location = new Point(268, 230);
                btnSalvar.Location = new Point(47, 385);
                btnAdicionarNaLista.Location = new Point(230, 385);
                btnReagendar.Location = new Point(413, 385);
                btnCancelar.Location = new Point(596, 385);
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

                // Converte o valor do pagamento para o formato moeda
                txtValor.Text = String.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", pagamento.Valor);

                listViewServicos.Items.Add("+  1 " + servico.Nome + "......................." + "R$ " + servico.Valor + ",00");
                listViewServicos.Items.Add(" ");
            }
            else
            {

                if (!txtQntd.Text.Equals(String.Empty))
                {
                    int quantidade = Convert.ToInt32(txtQntd.Text);
                    double valorTotalProduto = (produto.Valor * quantidade);

                    pagamento.Valor += valorTotalProduto;

                    // Converte o valor do pagamento para o formato moeda
                    txtValor.Text = String.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", pagamento.Valor);

                    listViewServicos.Items.Add("+  " + txtQntd.Text + " " + produto.Descricao + "......................." + "R$ " + valorTotalProduto + ",00");
                    listViewServicos.Items.Add(" ");
                    txtQntd.Clear();
                }
                else
                {
                    MessageBox.Show("Por gentileza, preencha o campo 'Quantidade'.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }




        }



        private void ckbDesconto_CheckedChanged(object sender, EventArgs e)
        {

            if (ckbDesconto.Checked)
            {
                cboDesconto.Visible = true;

            }
            else
            {
                cboDesconto.Visible = false;
                // Converte o valor do pagamento para o formato moeda
                txtValor.Text = String.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", pagamento.Valor);

            }

        }

        private void cboDesconto_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valorSemFormatacao = RemoverFormatacaoMoeda(txtValor.Text);

            double valor = Convert.ToDouble((valorSemFormatacao));
            double auxValor = pagamento.Valor;
            double desconto = 0;


            switch (cboDesconto.Text)
            {

                case "5%":
                    desconto = auxValor * 0.05;
                    valor = auxValor - desconto;
                    txtValor.Text = String.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valor);
                    break;

                case "10%":
                    desconto = auxValor * 0.10;
                    valor = auxValor - desconto;
                    txtValor.Text = String.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valor);
                    break;

                case "15%":
                    desconto = auxValor * 0.15;
                    valor = auxValor - desconto;
                    txtValor.Text = String.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valor);
                    break;

                case "20%":
                    desconto = auxValor * 0.20;
                    valor = auxValor - desconto;
                    txtValor.Text = String.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valor);
                    break;

                case "25%":
                    desconto = auxValor * 0.25;
                    valor = auxValor - desconto;
                    txtValor.Text = String.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valor);
                    break;

                case "30%":
                    desconto = auxValor * 0.30;
                    valor = auxValor - desconto;
                    txtValor.Text = String.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valor);
                    break;

                case "35%":
                    desconto = auxValor * 0.35;
                    valor = auxValor - desconto;
                    txtValor.Text = String.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valor);
                    break;

                case "40%":
                    desconto = auxValor * 0.40;
                    valor = auxValor - desconto;
                    txtValor.Text = String.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valor);
                    break;

                case "45%":
                    desconto = auxValor * 0.45;
                    valor = auxValor - desconto;
                    txtValor.Text = String.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valor);
                    break;

                case "50%":
                    desconto = auxValor * 0.50;
                    valor = auxValor - desconto;
                    txtValor.Text = String.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valor);
                    break;

                default:
                    txtValor.Text = String.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valor);
                    break;
            }
        }

        private string RemoverFormatacaoMoeda(string texto)
        {

            texto = texto.Replace("R$", "");
            texto = texto.Replace(",00", "");
            texto = texto.Replace(",", ".");
            //texto = texto.Replace("0", "");

            return texto;


        }

        private void txtRecebido_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double valorPagar = Convert.ToDouble(RemoverFormatacaoMoeda(txtValor.Text));
                double valorRecebido = Convert.ToDouble(txtRecebido.Text);

                if (Convert.ToDouble(lblValorTroco.Text) > 0)
                {
                    lblValorTroco.Visible = true;
                    lblTextoTroco.Visible = true;
                    lblValorTroco.Text = (valorRecebido - valorPagar).ToString("C");

                    // VERIFICAR A PARTE DO TROCO
                }
                
            }
            catch (FormatException ex)
            {
                
            }

        }
    }
}
