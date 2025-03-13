using ParcialServWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using System.Web;

namespace ParcialServWeb.Clases
{
    public class clsGestionComputador
    {
        private ItmVentasEntities dbVentas = new ItmVentasEntities();
        public Computador computador { get; set; }

        public string Insertar()
        {
            try
            {
                dbVentas.Computadores.Add(computador);
                dbVentas.SaveChanges();
                return "Computador insertado correctamente";

            }
            catch (Exception ex)
            {
                return "Error al insertar el Computador: " + ex.Message;

            }
        }
        public string Actualizar()
        {
            try
            {
                Computador comp = Consultar(computador.IdComputador);
                if (comp == null)
                {
                    return "Computador no existe";
                }
                dbVentas.Computadores.AddOrUpdate(computador);
                dbVentas.SaveChanges();
                return "Computador actualizado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al actualizar el Computador: " + ex.Message;
            }

        }

        public List<Computador> ConsultarTodos()
        {
            return dbVentas.Computadores.ToList(); 
        }

        public Computador Consultar(int idComputador)
        {
            return dbVentas.Computadores.FirstOrDefault(e => e.IdComputador == idComputador);
        }

        public string EliminarIdComputador(int idComputador)
        {
            try
            {
                Computador comp = Consultar(idComputador);
                if (comp == null)
                {
                    return "Computador no existe";
                }
                dbVentas.Computadores.Remove(comp);
                dbVentas.SaveChanges();
                return "Computador eliminado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al eliminar el Computador: " + ex.Message;
            }


        }


        //METODOS ADICIONALES PARA EL PARCIAL

        public List<Computador> ConsultarPorProcesador(int numeroProcesadores)
        {
            return dbVentas.Computadores
                .Where(c => c.NumeroProcesadores == numeroProcesadores)
                .ToList();
        }

        public List<Computador> ConsultarPorTipo(string nombreTipo)
        {
            try
            {
                var computadores = (from c in dbVentas.Computadores
                                    join t in dbVentas.TipoComputadores on c.IdTipoComputador equals t.IdTipoComputador
                                    where t.Descripcion == nombreTipo
                                    select c).ToList();

                if (computadores == null)
                {
                    throw new KeyNotFoundException("No se encontraron computadores con el tipo especificado.");
                }

                return computadores;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar computadores por tipo: " + ex.Message);
            }
        }
    }
}

    