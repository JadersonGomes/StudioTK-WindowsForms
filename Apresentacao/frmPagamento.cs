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

        Pagamento pagamento;

        IPagamentoRepository pagamentoRepository = new PagamentoRepository(new SalaoContext());
        IProdutoRepository produtoRepository = new ProdutoRepository(new SalaoContext());
        IVendaRepository vendaRepository = new VendaRepository(new SalaoContext());

        Validacao validacao;
        Venda venda;
        double auxValor = 0;
        double valorTotal = 0;

        List<Produto> listaProdutos = new List<Produto>();
        List<Servico> listaServicos = new List<Servico>();
        List<Pagamento> listaPagamentos = new List<Pagamento>();


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
                    bool resultadoValidacao = validacao.ValidarAgendamento(this.panel1);

                    if (!resultadoValidacao)
                    {

                        pagamento = new Pagamento(new SalaoContext());


                        string valorPagamentoSemFormatacao = RemoverFormatacaoMoeda(txtValor.Text);
                        valorPagamentoSemFormatacao = valorPagamentoSemFormatacao.Replace(".", ",");
                        double valorRecebido = Convert.ToDouble(txtRecebido.Text);

                        pagamento.NomeCliente = txtNomeCliente.Text;
                        pagamento.NomeFuncionario = cboFuncionario.Text;
                        pagamento.FormaPagamento = cboFormaPagamento.Text;
                        pagamento.DataPagamento = Convert.ToDateTime(dtpData.Text);
                        pagamento.ValorRecebido = (Convert.ToDouble(txtRecebido.Text));
                        pagamento.ValorTotal = Convert.ToDouble(valorPagamentoSemFormatacao);



                        // TRECHO DE CÓDIGO QUE TESTA SE SERÁ REALIZADO MAIS DE UM PAGAMENTO PARA A MESMA COMPRA:
                        if (pagamento.ValorRecebido < pagamento.ValorTotal)
                        {
                            DialogResult resultadoEscolha = MessageBox.Show("Deseja realizar mais um pagamento?", "Pagamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (resultadoEscolha == DialogResult.Yes)
                            {

                                double valorPagar = (pagamento.ValorTotal - valorRecebido);
                                if (valorPagar > 0)
                                {
                                    MessageBox.Show("Pagamento registrado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    txtRecebido.Clear();
                                    cboServico.SelectedIndex = 0;
                                    txtValor.Text = valorPagar.ToString("C");

                                    listaPagamentos.Add(pagamento);

                                }

                            }
                            else
                            {

                                // Foi necessário inicializar a venda em dois pontos diferentes porque a mesma está relacionada com a quantidade de pagamentos que podem ser realizados.
                                venda = new Venda(new SalaoContext());

                                //venda.Id = 1;
                                venda.Data = Convert.ToDateTime(dtpData.Text);
                                venda.Hora = DateTime.Now.ToShortTimeString();
                                venda.Funcionario = cboFuncionario.Text; // TROCAR DEPOIS PARA RECUPERAR O FUNCIONARIO E NÃO O TEXTO DO COMBOBOX     
                                venda.ValorDesconto = auxValor;

                                // Relaciona a venda com o pagamento realizado e depois adiciona na Lista auxiliar
                                pagamento.Venda = venda;
                                listaPagamentos.Add(pagamento);

                                // Pega o primeiro item da lista de pagamentos, pois ele sempre terá o valor total da compra.
                                venda.ValorTotal = listaPagamentos[0].ValorTotal;

                                venda.Produtos = listaProdutos;
                                venda.Servicos = listaServicos;
                                venda.Pagamentos = listaPagamentos;

                                if (ckbDesconto.Checked)
                                    venda.Desconto = true;

                                // Trecho responsável por salvar a venda no banco de dados.
                                /*vendaRepository.Adicionar(venda);
                                vendaRepository.Salvar();*/

                                //Limpa todos os valores utilizados pela instância.                                
                                listaPagamentos = new List<Pagamento>();
                                listaProdutos = new List<Produto>();
                                listaServicos = new List<Servico>();
                                auxValor = 0;
                                valorTotal = 0;

                                MessageBox.Show("Pagamento registrado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LimparCampos();
                            }
                        }
                        else
                        {

                            // Foi necessário inicializar a venda em dois pontos diferentes porque a mesma está relacionada com a quantidade de pagamentos que podem ser realizados.
                            venda = new Venda(new SalaoContext());

                            //venda.Id = 1;
                            venda.Data = Convert.ToDateTime(dtpData.Text);
                            venda.Hora = DateTime.Now.ToShortTimeString();
                            venda.Funcionario = cboFuncionario.Text; // TROCAR DEPOIS PARA RECUPERAR O FUNCIONARIO E NÃO O TEXTO DO COMBOBOX
                            venda.ValorDesconto = auxValor;

                            // Relaciona a venda com o pagamento realizado e depois adiciona na Lista auxiliar
                            pagamento.Venda = venda;
                            listaPagamentos.Add(pagamento);

                            // Pega o primeiro item da lista de pagamentos, pois ele sempre terá o valor total da compra.
                            venda.ValorTotal = listaPagamentos[0].ValorTotal;


                            venda.Produtos = listaProdutos;
                            venda.Servicos = listaServicos;
                            venda.Pagamentos = listaPagamentos;

                            if (ckbDesconto.Checked)
                                venda.Desconto = true;

                            // Trecho responsável por salvar a venda no banco de dados.
                            /*vendaRepository.Adicionar(venda);
                            vendaRepository.Salvar();*/

                            //Limpa todos os valores utilizados pela instância.
                            listaPagamentos = new List<Pagamento>();
                            listaProdutos = new List<Produto>();
                            listaServicos = new List<Servico>();
                            auxValor = 0;
                            valorTotal = 0;


                            MessageBox.Show("Pagamento registrado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparCampos();
                        }


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
            listViewServicos.Items.Add(" ");
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
            txtRecebido.Clear();
            txtValor.Clear();
            txtQntd.Clear();

            cboProdutos.SelectedIndex = -1;
            cboFormaPagamento.SelectedIndex = -1;
            cboFuncionario.SelectedIndex = -1;
            cboServico.SelectedIndex = -1;
            dtpData.Value = DateTime.Today;

            lblTextoTroco.Visible = false;
            lblValorTroco.Visible = false;

            ckbDesconto.Checked = false;

            listViewServicos.Clear();

            listViewServicos.Items.Add(" ");
            listViewServicos.Items.Add("                             LISTA DE SERVIÇOS À PAGAR");
            listViewServicos.Items.Add(" ");
            listViewServicos.Items.Add(" ");
            listViewServicos.Items.Add(" ");

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
                lblTextoTroco.Location = new Point(513, 394);
                lblValorTroco.Location = new Point(590, 394);

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
                lblTextoTroco.Location = new Point(512, 337);
                lblValorTroco.Location = new Point(589, 337);

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
            try
            {
                if (!(cboServico.SelectedIndex == -1))
                {
                    Servico servico = ((Servico)cboServico.SelectedItem);

                    if(txtQntd.Text != string.Empty)
                        servico.Quantidade = Convert.ToInt32(txtQntd.Text);

                    listaServicos.Add(servico);


                    //if(!txtRecebido.Text.Equals(String.Empty))
                    // valorRecebido += (Convert.ToDouble(txtRecebido.Text));


                    if (!(servico.Nome.Equals("Venda")))
                    {
                        valorTotal += servico.Valor;                        

                        // Converte o valor do pagamento para o formato moeda
                        txtValor.Text = String.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valorTotal);

                        listViewServicos.Items.Add("+  1 " + servico.Nome + "......................." + "R$ " + servico.Valor + ",00");
                        listViewServicos.Items.Add(" ");
                    }
                    else if (!txtQntd.Text.Equals(String.Empty))
                    {
                        Produto produto = ((Produto)cboProdutos.SelectedItem);
                        listaProdutos.Add(produto);
                        int quantidade = Convert.ToInt32(txtQntd.Text);
                        double valorTotalProduto = (produto.Valor * quantidade);

                        valorTotal += valorTotalProduto;
                        //pagamento.Valor += (valorTotalProduto - valorRecebido);
                        // Converte o valor do pagamento para o formato moeda
                        txtValor.Text = String.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valorTotal);

                        listViewServicos.Items.Add("+  " + quantidade + " " + produto.Descricao + "......................." + "R$ " + valorTotalProduto + ",00");
                        listViewServicos.Items.Add(" ");
                        txtQntd.Clear();
                        cboServico.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("Por gentileza, preencha o campo 'Quantidade'.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }



                    AtualizaTroco();
                }
                else
                {
                    MessageBox.Show("Por gentileza, preencha o campo 'Serviço'.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (FormatException ex)
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente ou contate o administrador do sistema. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                txtValor.Text = String.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valorTotal);

                AtualizaTroco();

            }

        }

        private void cboDesconto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string valorSemFormatacao = RemoverFormatacaoMoeda(txtValor.Text);
                valorSemFormatacao = valorSemFormatacao.Replace(".", ",");

                double valor = Convert.ToDouble(valorSemFormatacao);
                auxValor = valorTotal;

                switch (cboDesconto.Text)
                {

                    case "5%":
                        auxValor = pagamentoRepository.calculaDesconto(auxValor, valor, 0.05);
                        txtValor.Text = auxValor.ToString("C");
                        auxValor = valorTotal - auxValor;
                        break;

                    case "10%":
                        auxValor = pagamentoRepository.calculaDesconto(auxValor, valor, 0.10);
                        txtValor.Text = auxValor.ToString("C");
                        auxValor = valorTotal - auxValor;
                        break;

                    case "15%":
                        auxValor = pagamentoRepository.calculaDesconto(auxValor, valor, 0.15);
                        txtValor.Text = auxValor.ToString("C");
                        auxValor = valorTotal - auxValor;
                        break;

                    case "20%":
                        auxValor = pagamentoRepository.calculaDesconto(auxValor, valor, 0.20);
                        txtValor.Text = auxValor.ToString("C");
                        auxValor = valorTotal - auxValor;
                        break;

                    case "25%":
                        auxValor = pagamentoRepository.calculaDesconto(auxValor, valor, 0.25);
                        txtValor.Text = auxValor.ToString("C");
                        auxValor = valorTotal - auxValor;
                        break;

                    case "30%":
                        auxValor = pagamentoRepository.calculaDesconto(auxValor, valor, 0.30);
                        txtValor.Text = auxValor.ToString("C");
                        auxValor = valorTotal - auxValor;
                        break;

                    case "35%":
                        auxValor = pagamentoRepository.calculaDesconto(auxValor, valor, 0.35);
                        txtValor.Text = auxValor.ToString("C");
                        auxValor = valorTotal - auxValor;
                        break;

                    case "40%":
                        auxValor = pagamentoRepository.calculaDesconto(auxValor, valor, 0.40);
                        txtValor.Text = auxValor.ToString("C");
                        auxValor = valorTotal - auxValor;
                        break;

                    case "45%":
                        auxValor = pagamentoRepository.calculaDesconto(auxValor, valor, 0.45);
                        txtValor.Text = auxValor.ToString("C");
                        auxValor = valorTotal - auxValor;
                        break;

                    case "50%":
                        auxValor = pagamentoRepository.calculaDesconto(auxValor, valor, 0.50);
                        txtValor.Text = auxValor.ToString("C");
                        auxValor = valorTotal - auxValor;
                        break;

                    default:
                        txtValor.Text = String.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valor);
                        break;
                }

                AtualizaTroco();

            }
            catch (FormatException ex)
            {
                MessageBox.Show("Não há nenhum valor registrado para a aplicação do desconto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente ou contate o administrador do sistema. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private void txtRecebido_TextChanged(object sender, EventArgs e)
        {
            AtualizaTroco();
        }
    }
}
