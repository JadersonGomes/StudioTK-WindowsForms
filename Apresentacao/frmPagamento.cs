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
                if (!txtValor.Text.Equals(String.Empty))
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
                else
                {
                    MessageBox.Show("Por gentileza, adicione à lista um Produto e/ou Serviço para finalizar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

                // VISIBLE

                cboProdutos.Visible = true;
                txtQntd.Visible = true;
                lblProduto.Visible = true;
                lblQntd.Visible = true;


                // SIZE

                groupBox1.Height = 441;
                groupBox1.Width = 765;

                listViewServicos.Height = 488;
                listViewServicos.Width = 371;

                this.Height = 592;
                this.Width = 1218;

                panel1.Height = 592;
                panel1.Width = 799;


                // LOCATION

                lblValor.Location = new Point(515, 347);
                txtValor.Location = new Point(519, 364);
                lblTextoTroco.Location = new Point(516, 394);
                lblValorTroco.Location = new Point(593, 394);

                cboDesconto.Location = new Point(23, 364);
                ckbDesconto.Location = new Point(23, 339);

                lblRecebido.Location = new Point(21, 277);
                txtRecebido.Location = new Point(25, 298);

                lblForma.Location = new Point(266, 277);
                cboFormaPagamento.Location = new Point(269, 298);

                btnSalvar.Location = new Point(47, 477);
                btnAdicionarNaLista.Location = new Point(230, 477);
                btnReagendar.Location = new Point(413, 477);
                btnCancelar.Location = new Point(596, 477);
            }
            else
            {
                // VISIBLE

                cboProdutos.Visible = false;
                txtQntd.Visible = false;
                lblProduto.Visible = false;
                lblQntd.Visible = false;


                // SIZE

                groupBox1.Height = 375;
                groupBox1.Width = 765;

                panel1.Height = 477;
                panel1.Width = 799;

                listViewServicos.Height = 434;
                listViewServicos.Width = 371;

                this.Height = 541;
                this.Width = 1218;



                // LOCATION
                lblValor.Location = new Point(515, 278);
                txtValor.Location = new Point(519, 297);
                lblTextoTroco.Location = new Point(516, 327);
                lblValorTroco.Location = new Point(593, 327);

                cboDesconto.Location = new Point(23, 297);
                ckbDesconto.Location = new Point(23, 272);

                txtRecebido.Location = new Point(25, 230);
                lblRecebido.Location = new Point(21, 211);

                lblForma.Location = new Point(265, 212);
                cboFormaPagamento.Location = new Point(268, 230);

                btnSalvar.Location = new Point(47, 421);
                btnAdicionarNaLista.Location = new Point(230, 421);
                btnReagendar.Location = new Point(413, 421);
                btnCancelar.Location = new Point(596, 421);
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
            valorSemFormatacao = valorSemFormatacao.Replace(".", ",");

            double valor = Convert.ToDouble(valorSemFormatacao);
            double auxValor = pagamento.Valor;



            switch (cboDesconto.Text)
            {

                case "5%":
                    txtValor.Text = pagamentoRepository.calculaDesconto(auxValor, valor, 0.05);
                    break;

                case "10%":
                    txtValor.Text = pagamentoRepository.calculaDesconto(auxValor, valor, 0.10);
                    break;

                case "15%":
                    txtValor.Text = pagamentoRepository.calculaDesconto(auxValor, valor, 0.15);
                    break;

                case "20%":
                    txtValor.Text = pagamentoRepository.calculaDesconto(auxValor, valor, 0.20);
                    break;

                case "25%":
                    txtValor.Text = pagamentoRepository.calculaDesconto(auxValor, valor, 0.25);
                    break;

                case "30%":
                    txtValor.Text = pagamentoRepository.calculaDesconto(auxValor, valor, 0.30);
                    break;

                case "35%":
                    txtValor.Text = pagamentoRepository.calculaDesconto(auxValor, valor, 0.35);
                    break;

                case "40%":
                    txtValor.Text = pagamentoRepository.calculaDesconto(auxValor, valor, 0.40);
                    break;

                case "45%":
                    txtValor.Text = pagamentoRepository.calculaDesconto(auxValor, valor, 0.45);
                    break;

                case "50%":
                    txtValor.Text = pagamentoRepository.calculaDesconto(auxValor, valor, 0.50);
                    break;

                default:
                    txtValor.Text = String.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valor);
                    break;
            }

            AtualizaTroco();
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
            AtualizaTroco();

        }


        public void AtualizaTroco()
        {
            try
            {
                string valorSemFormatacao = RemoverFormatacaoMoeda(txtValor.Text);
                valorSemFormatacao = valorSemFormatacao.Replace(".", ",");

                double valorPagar = Convert.ToDouble(valorSemFormatacao);
                double valorRecebido = Convert.ToDouble(txtRecebido.Text);
                double result = (valorRecebido - valorPagar);
                lblValorTroco.Text = result.ToString("C");

                if (result >= 0)
                {
                    lblValorTroco.Visible = true;
                    lblTextoTroco.Visible = true;


                }
                else
                {
                    lblValorTroco.Visible = false;
                    lblTextoTroco.Visible = false;
                }

            }
            catch (FormatException ex)
            {

            }
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
