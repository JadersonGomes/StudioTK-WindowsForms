using AcessoBancoDados.Generics;
using Negocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    public interface IAgendaRepository : IRepository<Agenda>
    {
        List<string> PreencheListaHorarios(int inicio);
        List<string> PopulaComboHora(DateTime diaSelecionado, string horaInicial/*, string horaFinal*/);
        List<Servico> PopulaServico();        
        List<Funcionario> PopulaColaborador();
        List<string> AtualizarHorario(string horaInicial, string horaFinal);
        IEnumerable<Agenda> BuscarPorNomeCliente(string nomeCliente);
        List<Agenda> ListarPorDataColaborador(DateTime dataAgendamento, string colaborador);
        List<Agenda> PopulaDataGrid();




    }
}
