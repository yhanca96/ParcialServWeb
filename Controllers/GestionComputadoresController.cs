using ParcialServWeb.Models;
using ParcialServWeb.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ParcialServWeb.Controllers
{

    [RoutePrefix("api/computadores")]
    public class GestionComputadoresController : ApiController
    {
        [HttpGet]
        [Route("consultarTodos")]  

        public List<Computador> ConsultarTodos()
        {
            clsGestionComputador Computador = new clsGestionComputador();
            return Computador.ConsultarTodos();
        }

        [HttpGet]
        [Route("consultarID")]
        public Computador ConsultarID(int idComputador)
        {
            clsGestionComputador Computador = new clsGestionComputador();
            return Computador.Consultar(idComputador);
        }

        [HttpGet]
        [Route("consultarProcesador")]
        public Computador ConsultarProcesador(int numeroProcesadores)
        {
            clsGestionComputador comp = new clsGestionComputador();
            return comp.ConsultarProcesador(numeroProcesadores);
        }


        [HttpPost]
        [Route("insertar")]
        public string Insertar([FromBody] Computador computador)
        {
            clsGestionComputador Computador = new clsGestionComputador();
            Computador.computador = computador;
            return Computador.Insertar();
        }

        [HttpPut]
        [Route("actualizar")]

        public string Actualizar([FromBody] Computador computador)
        {
            clsGestionComputador Computador = new clsGestionComputador();
            Computador.computador = computador;
            return Computador.Actualizar();
        }



        [HttpDelete]
        [Route("eliminarID")]

        public string EliminarID(int idComputador)
        {
            clsGestionComputador Computador = new clsGestionComputador();
            return Computador.EliminarIdComputador(idComputador);
        }

    }
}