using AcessoBancoDados;
using Negocio.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Models
{
    public class Agenda : AgendaRepository
    {

        public Agenda(SalaoContext _contexto) : base(_contexto)
        {
        }

        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public DateTime Data { get; set; }
        public string Horario { get; set; }        
        public Servico Servico { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}
