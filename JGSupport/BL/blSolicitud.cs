using Entidades;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class blSolicitud
    {

        public List<Solicitud> Listar()
        {
            try
            {
                return new dalSolicitud().Listar();
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public List<Solicitud> ListarPorCliente(int id_cliente)
        {

            try
            {
                return new dalSolicitud().ListarPorCliente(id_cliente);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<Solicitud> ObtenerListaPorId(int solicitudId)
        {
            try
            {
                return new dalSolicitud().ObtenerListaPorId(solicitudId);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Solicitud ObtenerPorSolicitudId(int solicitudId)
        {

            try
            {
                return new dalSolicitud().ObtenerPorSolicitudId(solicitudId);
            }
                
            catch (Exception e)
            {
                throw;
            }
        }

        public List<Solicitud> ObtenerPorFormulario(string fechaDesde, string fechaHasta, int cliente, int filtrado)
        {
            try
            {
                return new dalSolicitud().ObtenerPorFormulario(fechaDesde, fechaHasta, cliente, filtrado);
            }

            catch (Exception e)
            {
                throw;
            }
        }

        public void FinalizarSolicitudId(Solicitud solicitudId)
        {
            try
            {
                new dalSolicitud().Finalizar(solicitudId);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void Guardar(Solicitud solicitud)
        {
            if (solicitud.SolicitudId != null)
            {
                try
                {
                    new dalSolicitud().Modificar(solicitud);
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            else
            {
                try
                {
                    new dalSolicitud().Insertar(solicitud);
                }
                catch (Exception e)
                {
                    throw;
                }
            }


        }
    }
}