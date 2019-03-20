using AcessoBancoDados;
using AcessoBancoDados.Models;
using Negocio.Implementation;
using Negocio.Interfaces;
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
        IPagamentoRepository pagamentoRepository = new PagamentoRepository(new SalaoContext());
        IProdutoRepository produtoRepository = new ProdutoRepository(new SalaoContext());
        IVendaRepository vendaRepository = new VendaRepository(new SalaoContext());
        IFaturamentoRepository faturamentoRepository = new FaturamentoRepository(new SalaoContext());

        Venda venda;
        Pagamento pagamento;
        Faturamento faturamento = new Faturamento();

        // Variável que auxilia no calculo de desconto e ao final, traz o desconto total que foi concedido ao cliente para que seja salvo na Venda.
        double auxValor = 0;

        // Variável responsável por acumular o valor total da Venda conforme o usuário adiciona serviços/ produtos.
        double valorTotal = 0;

        // Listas auxiliares que guardam objetos que podem ser adicionados na Venda.
        List<Produto> listaProdutos = new List<Produto>();
        List<Servico> listaServicos = new List<Servico>();
        List<Pagamento> listaPagamentos = new List<Pagamento>();
        List<Servico> listaServicosFaturamento = new List<Servico>();


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


                    pagamento = new Pagamento();

                    double valorPagamentoSemFormatacao = RemoverFormatacaoMoeda(txtValor.Text);
                    double valorRecebidoSemFormatacao = RemoverFormatacaoMoeda(txtRecebido.Text);

                    pagamento.NomeCliente = txtNomeCliente.Text;                    
                    pagamento.FormaPagamento = cboFormaPagamento.Text;
                    pagamento.DataPagamento = Convert.ToDateTime(dtpData.Text);
                    pagamento.ValorRecebido = valorRecebidoSemFormatacao;
                    pagamento.ValorTotal = valorPagamentoSemFormatacao;



                    // TRECHO DE CÓDIGO QUE TESTA SE SERÁ REALIZADO MAIS DE UM PAGAMENTO PARA A MESMA COMPRA:
                    if (pagamento.ValorRecebido < pagamento.ValorTotal)
                    {
                        DialogResult resultadoEscolha = MessageBox.Show("Deseja realizar mais um pagamento?", "Pagamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (resultadoEscolha == DialogResult.Yes)
                        {
                            double valorPagar = (pagamento.ValorTotal - pagamento.ValorRecebido);

                            txtRecebido.Clear();
                            cboServico.SelectedIndex = 0;
                            ckbDesconto.Visible = false;
                            cboDesconto.Visible = false;
                            txtValor.Text = valorPagar.ToString("C");

                            listaPagamentos.Add(pagamento);

                            MessageBox.Show("Pagamento registrado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {

                            // Foi necessário inicializar a venda em dois pontos diferentes porque a mesma está relacionada com a quantidade de pagamentos que podem ser realizados.
                            venda = new Venda();

                            //venda.Id = 1;
                            venda.Data = Convert.ToDateTime(dtpData.Text);
                            venda.Hora = DateTime.Now.ToShortTimeString();
                            venda.Funcionario = ((Funcionario)cboFuncionario.SelectedItem); // TROCAR DEPOIS PARA RECUPERAR O FUNCIONARIO E NÃO O TEXTO DO COMBOBOX     
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


                            // Torna a opção de desconto visível novamente após a finalização da Venda.
                            ckbDesconto.Visible = true;

                            MessageBox.Show("Pagamento registrado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparCampos();
                        }
                    }
                    else
                    {

                        // Foi necessário inicializar a venda em dois pontos diferentes porque a mesma está relacionada com a quantidade de pagamentos que podem ser realizados.
                        venda = new Venda();

                        //venda.Id = 1;
                        venda.Data = Convert.ToDateTime(dtpData.Text);
                        venda.Hora = DateTime.Now.ToShortTimeString();
                        venda.Funcionario = ((Funcionario)cboFuncionario.SelectedItem); // TROCAR DEPOIS PARA RECUPERAR O FUNCIONARIO E NÃO O TEXTO DO COMBOBOX
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


                        // Torna a opção de desconto visível novamente após a finalização da Venda.
                        ckbDesconto.Visible = true;

                        // Cria uma nova instancia do Faturamento para salvar novos dados.
                        faturamento = new Faturamento();


                        MessageBox.Show("Pagamento registrado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
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
            // Montagem da ListView
            listViewServicos.View = View.Details;
            listViewServicos.Columns.Add("Descrição", 270);
            listViewServicos.Columns.Add("Valor", 100);
            listViewServicos.Items.Add(" ");

            cboServico.DataSource = pagamentoRepository.PopulaServico();


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

            //Limpa todos os valores utilizados pela instância.    
            listaPagamentos = new List<Pagamento>();
            listaProdutos = new List<Produto>();
            listaServicos = new List<Servico>();
            auxValor = 0;
            valorTotal = 0;

            listViewServicos.Clear();

            // Montagem da ListView
            listViewServicos.View = View.Details;
            listViewServicos.Columns.Add("Descrição", 270);
            listViewServicos.Columns.Add("Valor", 100);

            listViewServicos.Items.Add(" ");



        }


        private void cboServico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboServico.Text.Equals("Venda"))
            {
                // Carrega o combobox de Produtos
                cboProdutos.DataSource = pagamentoRepository.PopulaProduto();

                // ---------------------- TRECHO RESPONSÁVEL POR POSICIONAR OS ELEMENTOS NA POSIÇÃO CORRETA DE ACORDO COM O SERVIÇO SELECIONADO
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
                lblTextoTroco.Location = new Point(514, 394);
                lblValorTroco.Location = new Point(591, 394);

                cboDesconto.Location = new Point(23, 364);
                ckbDesconto.Location = new Point(23, 339);

                lblRecebido.Location = new Point(21, 277);
                txtRecebido.Location = new Point(25, 298);

                lblForma.Location = new Point(266, 277);
                cboFormaPagamento.Location = new Point(269, 298);

                btnSalvar.Location = new Point(47, 477);
                btnAdicionarNaLista.Location = new Point(230, 477);
                btnLimpar.Location = new Point(486, 364);
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
                lblTextoTroco.Location = new Point(514, 337);
                lblValorTroco.Location = new Point(591, 337);

                cboDesconto.Location = new Point(23, 297);
                ckbDesconto.Location = new Point(23, 272);

                txtRecebido.Location = new Point(25, 230);
                lblRecebido.Location = new Point(21, 211);

                lblForma.Location = new Point(265, 212);
                cboFormaPagamento.Location = new Point(268, 230);

                btnSalvar.Location = new Point(47, 421);
                btnAdicionarNaLista.Location = new Point(230, 421);
                btnLimpar.Location = new Point(486, 297);
                btnReagendar.Location = new Point(413, 421);
                btnCancelar.Location = new Point(596, 421);

            }
        }
        // ---------------------- FIM TRECHO RESPONSÁVEL POR POSICIONAR OS ELEMENTOS NA POSIÇÃO CORRETA DE ACORDO COM O SERVIÇO SELECIONADO --------

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
                    if (!(cboFuncionario.SelectedIndex == -1))
                    {
                        // Recupera o Servico do ComboBox e depois adiciona na lista auxiliar para salvar no Faturamento.
                        Servico servico = ((Servico)cboServico.SelectedItem);
                        listaServicosFaturamento.Add(servico);                        

                        listaServicos.Add(servico);


                        if (!(servico.Nome.Equals("Venda")))
                        {
                            valorTotal += servico.Valor;

                            // Monta os dados e insere na ListView
                            string[] row = { "+  1 " + servico.Nome, "R$ " + servico.Valor + ",00" };
                            ListViewItem item = new ListViewItem(row);
                            listViewServicos.Items.Add(item);

                            // Converte o valor do pagamento para o formato moeda
                            txtValor.Text = String.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valorTotal);


                        }
                        else if (!txtQntd.Text.Equals(String.Empty))
                        {
                            Produto produto = ((Produto)cboProdutos.SelectedItem);
                                                       

                            listaProdutos.Add(produto);

                            int quantidade = Convert.ToInt32(txtQntd.Text);
                            double valorTotalProduto = (produto.Valor * quantidade);

                            valorTotal += valorTotalProduto;

                            // Monta os dados e insere na ListView
                            String[] row = { "+  " + quantidade + " " + produto.Descricao, "R$ " + valorTotalProduto + ",00" };
                            ListViewItem item = new ListViewItem(row);
                            listViewServicos.Items.Add(item);

                            txtQntd.Clear();
                            cboServico.SelectedIndex = 0;

                            // Converte o valor total da venda para o formato moeda
                            txtValor.Text = String.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valorTotal);

                            Funcionario funcionario = (Funcionario)cboFuncionario.SelectedItem;
                            faturamento.Funcionario = funcionario;                            
                            faturamento.ValorTotal = servico.Valor;
                            faturamento.Data = DateTime.Today;                            

                            faturamentoRepository.Adicionar(faturamento);
                            faturamentoRepository.Salvar();

                        }
                        else
                        {
                            MessageBox.Show("Por gentileza, preencha o campo 'Quantidade'.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                        AtualizaTroco();

                    }
                    else
                    {
                        MessageBox.Show("Por gentileza, preencha o campo 'Colaborador'.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
                else
                {
                    MessageBox.Show("Por gentileza, preencha o campo 'Serviço'.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }



            }
            catch (FormatException ex)
            {
                // Entrará aqui e não fará nada caso o programa não consiga converter algum valor recebido da caixa de texto.
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

                // Converte o valor total da venda para o formato moeda
                txtValor.Text = String.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valorTotal);

                AtualizaTroco();

            }

        }

        private void cboDesconto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Remove a formatação do Valor Total para que sejam realizados alguns cálculos.
                double valorSemFormatacao = RemoverFormatacaoMoeda(txtValor.Text);
                auxValor = valorTotal;

                switch (cboDesconto.Text)
                {

                    case "5%":
                        // Método devolve valor total da compra já com o desconto.
                        auxValor = pagamentoRepository.calculaDesconto(auxValor, valorSemFormatacao, 0.05);
                        txtValor.Text = auxValor.ToString("C");
                        // Variável 'auxValor' recebe o desconto para que o mesmo seja salvo na Venda posteriormente
                        auxValor = valorTotal - auxValor;
                        break;

                    case "10%":
                        auxValor = pagamentoRepository.calculaDesconto(auxValor, valorSemFormatacao, 0.10);
                        txtValor.Text = auxValor.ToString("C");
                        auxValor = valorTotal - auxValor;
                        break;

                    case "15%":
                        auxValor = pagamentoRepository.calculaDesconto(auxValor, valorSemFormatacao, 0.15);
                        txtValor.Text = auxValor.ToString("C");
                        auxValor = valorTotal - auxValor;
                        break;

                    case "20%":
                        auxValor = pagamentoRepository.calculaDesconto(auxValor, valorSemFormatacao, 0.20);
                        txtValor.Text = auxValor.ToString("C");
                        auxValor = valorTotal - auxValor;
                        break;

                    case "25%":
                        auxValor = pagamentoRepository.calculaDesconto(auxValor, valorSemFormatacao, 0.25);
                        txtValor.Text = auxValor.ToString("C");
                        auxValor = valorTotal - auxValor;
                        break;

                    case "30%":
                        auxValor = pagamentoRepository.calculaDesconto(auxValor, valorSemFormatacao, 0.30);
                        txtValor.Text = auxValor.ToString("C");
                        auxValor = valorTotal - auxValor;
                        break;

                    case "35%":
                        auxValor = pagamentoRepository.calculaDesconto(auxValor, valorSemFormatacao, 0.35);
                        txtValor.Text = auxValor.ToString("C");
                        auxValor = valorTotal - auxValor;
                        break;

                    case "40%":
                        auxValor = pagamentoRepository.calculaDesconto(auxValor, valorSemFormatacao, 0.40);
                        txtValor.Text = auxValor.ToString("C");
                        auxValor = valorTotal - auxValor;
                        break;

                    case "45%":
                        auxValor = pagamentoRepository.calculaDesconto(auxValor, valorSemFormatacao, 0.45);
                        txtValor.Text = auxValor.ToString("C");
                        auxValor = valorTotal - auxValor;
                        break;

                    case "50%":
                        auxValor = pagamentoRepository.calculaDesconto(auxValor, valorSemFormatacao, 0.50);
                        txtValor.Text = auxValor.ToString("C");
                        auxValor = valorTotal - auxValor;
                        break;

                    default:
                        txtValor.Text = String.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valorSemFormatacao);
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


        private double RemoverFormatacaoMoeda(string texto)
        {
            double valorSemFormatacao = 0;

            texto = texto.Replace("R$", "");
            texto = texto.Replace(",00", "");

            valorSemFormatacao = Convert.ToDouble(texto);

            return valorSemFormatacao;

        }

        public void AtualizaTroco()
        {
            try
            {
                double valorPagarSemFormatacao = RemoverFormatacaoMoeda(txtValor.Text);

                double valorRecebido = Convert.ToDouble(txtRecebido.Text);
                double result = (valorRecebido - valorPagarSemFormatacao);

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
                // Não fará nada pois na maioria das vezes o usuário adicionará um serviço sem adicionar um valor recebido. Isso impede que o programa trave caso não tenha nada no txtRecebido.
            }
        }


        private void txtRecebido_TextChanged(object sender, EventArgs e)
        {
            AtualizaTroco();
        }

        private void txtRecebido_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                double texto = Convert.ToDouble(txtRecebido.Text);
                txtRecebido.Text = texto.ToString("C");
            }
            catch (FormatException ex)
            {
                // Cairá aqui toda vez que o usuário não inserir valor no txtRecebido
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo deu errado. Tente novamente ou contate o administrador do sistema. \n\n\nDetalhes: \n" + ex.Message, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtRecebido_MouseClick(object sender, MouseEventArgs e)
        {
            txtRecebido.Clear();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }
    }
}
