using AcessoBancoDados;
using Negocio.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Models
{
    public class Usuario 
    {       

        public int Id { get; set; }
        public string nomeUsuario { get; set; }
        public string Senha { get; set; }
        public string email { get; set; }

    }
}
