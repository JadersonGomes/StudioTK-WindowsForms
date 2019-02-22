using Negocio.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcessoBancoDados;

namespace Negocio.Models
{
    public class Faturamento 
    {
        public int Id { get; set; }
        public Funcionario Colaborador { get; set; }
        public DateTime Data { get; set; }
        public int QntdServicos { get; set; }
        public double faturamentoTotal { get; set; }
        public Servico Servico { get; set; }
        

    }
}
