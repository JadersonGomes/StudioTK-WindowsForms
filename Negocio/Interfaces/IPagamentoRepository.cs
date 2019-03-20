using AcessoBancoDados.Models;
using System.Collections.Generic;

namespace Negocio.Interfaces
{
    public interface IPagamentoRepository: IRepository<Pagamento>
    {
        /*IEnumerable<Pagamento> ListarPorPeriodo(string data);
        IEnumerable<Pagamento> ListarPorColaborador(string colaborador);
        IEnumerable<Pagamento> ListarPorServico(string servico);
        IEnumerable<Pagamento> ListarPorPeriodoServico(string servico, string data);
        IEnumerable<Pagamento> ListarPorPeriodoColaborador(string data, string colaborador);
        IEnumerable<Pagamento> ListarPorColaboradorServico(string servico, string colaborador);
        IEnumerable<Pagamento> ListarPorPeriodoColaboradorServico(string data, string colaborador, string servico);
        IList<Pagamento> ListarFechamentoDiario(string funcionario, string dataInicial);
        IList<Pagamento> ListarFechamentoPeriodo(string funcionario, string dataInicial, string dataFinal);*/
        double SomarValorTotal(IEnumerable<Pagamento> lista);
        List<Servico> PopulaServico();
        List<Produto> PopulaProduto();
        double calculaDesconto(double auxValor, double valor, double porcentagem);
    }
}
