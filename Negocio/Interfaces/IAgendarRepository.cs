using AcessoBancoDados.Generics;
using Negocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    public interface IAgendarRepository : IRepository<Agendar>
    {
        List<string> PreencheListaHorarios(int inicio);
        List<string> PopulaComboHora(DateTime diaSelecionado, string horaInicial/*, string horaFinal*/);
        List<Servico> PopulaServico();        
        List<Funcionario> PopulaColaborador();
        List<string> AtualizarHorario(string horaInicial, string horaFinal);
        IEnumerable<Agendar> BuscarPorNomeCliente(string nomeCliente);
        List<Agendar> ListarPorDataColaborador(DateTime dataAgendamento, string colaborador);
        List<Agendar> PopulaDataGrid();




    }
}
