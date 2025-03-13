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
        public Computador ConsultarProcesador(int numeroProcesadores)
        {
            if (numeroProcesadores <= 0)
            {
                throw new ArgumentException("El número de procesadores debe ser mayor a 0.");
            }

            Computador computador = dbVentas.Computadores.FirstOrDefault(e => e.NumeroProcesadores == numeroProcesadores);

            if (computador == null)
            {
                throw new KeyNotFoundException("No se encontró un computador con ese número de procesadores.");
            }

            return computador;
        }


        //public Computador ConsultarProcesador (int numeroProcesadores)
        //{
        //    return dbVentas.Computadores.FirstOrDefault(e => e.NumeroProcesadores == numeroProcesadores);
        //}   

        public List<Computador> ConsultarTodos()
        {
            return dbVentas.Computadores.ToList(); //devuelve una lista de Computadors
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
        }
}