﻿using AcessoBancoDados;
using AcessoBancoDados.Generics;
using Negocio.Interfaces;
using Negocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Implementation
{
    public class FuncionarioServicoRepository : AcessoDadosEntityFramework<FuncionarioServico>, IFuncionarioServicoRepository
    {
        public FuncionarioServicoRepository(SalaoContext _contexto) : base(_contexto)
        {
        }

        
    }
}
