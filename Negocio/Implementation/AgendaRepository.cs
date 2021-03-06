﻿using AcessoBancoDados.Models;
using Negocio.Generics;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Negocio.Implementation
{
    public class AgendaRepository : AcessoDadosEntityFramework<Agenda>, IAgendaRepository
    {

        List<string> listaHora = new List<string>();

        public AgendaRepository(SalaoContext _contexto) : base(_contexto)
        {
        }


        public List<Agenda> PopulaDataGrid()
        {
            List<Agenda> listaAgendamento = new List<Agenda>();

            Funcionario funcionario = new Funcionario();
            funcionario.Nome = "Tiago";

            Cliente cliente = new Cliente();
            cliente.Id = 1;
            cliente.Nome = "Jaderson";
            cliente.Telefone = "11 97664 5381";
            cliente.Email = "jaderson_goomes@hotmail.com";

            Servico servico = new Servico();
            servico.Id = 1;
            servico.Nome = "Corte Masculino";
            servico.Valor = 25;


            Agenda agenda = new Agenda();

            agenda.Id = 1;
            agenda.NomeCliente = "Jaderson";
            agenda.Data = DateTime.Today;
            agenda.Horario = "" + DateTime.Now.ToShortTimeString();
            agenda.Servico = servico;
            agenda.Funcionario = funcionario;

            Agenda agenda2 = new Agenda();

            agenda2.Id = 2;
            agenda2.NomeCliente = "Jaderson";
            agenda2.Data = DateTime.Today;
            agenda2.Horario = "" + DateTime.Now.ToShortTimeString();
            agenda2.Servico = servico;
            agenda2.Funcionario = funcionario;

            Agenda agenda3 = new Agenda();

            agenda3.Id = 3;
            agenda3.NomeCliente = "Jaderson";
            agenda3.Data = DateTime.Today;
            agenda3.Horario = "" + DateTime.Now.ToShortTimeString();
            agenda3.Servico = servico;
            agenda3.Funcionario = funcionario;

            Agenda agenda4 = new Agenda();

            agenda4.Id = 4;
            agenda4.NomeCliente = "Jaderson";
            agenda4.Data = DateTime.Today;
            agenda4.Horario = "" + DateTime.Now.ToShortTimeString();
            agenda4.Servico = servico;
            agenda4.Funcionario = funcionario;

            Agenda agenda5 = new Agenda();

            agenda5.Id = 5;
            agenda5.NomeCliente = "Jaderson";
            agenda5.Data = DateTime.Today;
            agenda5.Horario = "" + DateTime.Now.ToShortTimeString();
            agenda5.Servico = servico;
            agenda5.Funcionario = funcionario;

            listaAgendamento.Add(agenda);
            listaAgendamento.Add(agenda2);
            listaAgendamento.Add(agenda3);
            listaAgendamento.Add(agenda4);
            listaAgendamento.Add(agenda5);

            return listaAgendamento;


        }



        public List<string> PreencheListaHorarios(int inicio)
        {
            var hoje = DateTime.Now;
            var minutoHoje = hoje.Minute;
            var contadorMinutos = minutoHoje;
            var contadorHoras = inicio;

            for (int i = inicio; i < 21; i++)
            {
                if (contadorMinutos > 30)
                {
                    contadorHoras += 1;
                    listaHora.Add((contadorHoras) + ":" + "00");

                    if (contadorMinutos < 60)
                    {
                        contadorMinutos = 0;
                        contadorMinutos = 30;
                    }
                    listaHora.Add(contadorHoras + ":" + contadorMinutos);
                    contadorMinutos = minutoHoje;
                }
                else
                {
                    listaHora.Add(contadorHoras + ":" + "30");
                    contadorHoras += 1;
                    contadorMinutos = 0;
                    listaHora.Add(contadorHoras + ":" + contadorMinutos + "0");
                }
            }
            return listaHora;
        }


        public IList<string> AtualizarHorario(string horaInicial, string horaFinal)
        {
            int posHoraInicial = 0, posHoraFinal = 0;
            IList<Agenda> lista = ListarTodos().Where(a => a.Data.Equals(DateTime.Now.ToString())).ToList();

            /*for (int i = 0; i < lista.Count; i++)
            {
                if (listaHora[i].Equals(lista.agendar.HorarioInicial))
                {
                    posHoraInicial = i;
                    //listaHora[i] = "Horário indisponível";
                }
                else if (listaHora[i].Equals(agendar.HorarioFinal))
                {
                    posHoraFinal = i;
                }
            }*/

            int posRemovida = posHoraInicial;
            while (posHoraInicial <= posHoraFinal)
            {
                listaHora.RemoveAt(posRemovida);
                posHoraInicial++;
            }

            return listaHora;
        }


        public List<string> PopulaComboHora(DateTime diaSelecionado, string horaInicial/*, string horaFinal*/)
        {
            List<string> listaHora;
            if (diaSelecionado.Date == DateTime.Now.Date)
            {
                listaHora = PreencheListaHorarios(DateTime.Now.Hour);
                //listaHora = AtualizarHorario(horaInicial, horaFinal);
            }
            else
            {
                listaHora = PreencheListaHorarios(6);
            }

            return listaHora;

        }



        public List<Servico> PopulaServico()
        {
            List<Servico> listaServicos = new List<Servico>();

            Servico servico = new Servico();
            Servico servico2 = new Servico();

            servico.Nome = "Corte Masculino";
            servico2.Nome = "Unha simples";

            listaServicos.Add(servico);
            listaServicos.Add(servico2);

            return listaServicos;
        }

        public List<Funcionario> PopulaColaborador()
        {
            List<Funcionario> listaColaborador = new List<Funcionario>();

            Funcionario funcionario = new Funcionario();
            Funcionario funcionario2 = new Funcionario();
            Funcionario funcionario3 = new Funcionario();

            funcionario.Nome = "Karol";
            funcionario2.Nome = "Thiago";
            funcionario3.Nome = "Josi";

            listaColaborador.Add(funcionario);
            listaColaborador.Add(funcionario2);
            listaColaborador.Add(funcionario3);

            return listaColaborador;
        }

        public IList<Agenda> BuscarPorNomeCliente(string nomeCliente)
        {
            var lista = this.ListarTodos().Where(a => a.NomeCliente.Contains(nomeCliente));

            var listaPersonalizada = (from list in lista
                                      select new Agenda
                                      {

                                          Id = list.Id,
                                          Data = list.Data,
                                          Funcionario = list.Funcionario,
                                          NomeCliente = list.NomeCliente,
                                          Horario = list.Horario,
                                          Servico = list.Servico

                                      }).ToList();

            return listaPersonalizada;
        }

        public IList<Agenda> ListarPorDataColaborador(DateTime dataAgendamento, string colaborador)
        {
            var lista =  ListarTodos().Where(a => a.Data.Equals(dataAgendamento)).Where(a => a.Funcionario.Equals(colaborador)).ToList();

            var listaPersonalizada = (from list in lista
                                      select new Agenda {

                                          Id = list.Id,
                                          Data = list.Data,
                                          Funcionario = list.Funcionario,
                                          NomeCliente = list.NomeCliente,
                                          Horario = list.Horario,
                                          Servico = list.Servico

                                      }).ToList();

            return listaPersonalizada;

        }
    }
}
