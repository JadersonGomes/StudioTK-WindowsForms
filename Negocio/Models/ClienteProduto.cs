﻿using AcessoBancoDados;
using Negocio.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Models
{
    public class ClienteProduto : ClienteProdutoRepository
    {
        public ClienteProduto(SalaoContext _contexto) : base(_contexto)
        {
        }
    }
}
