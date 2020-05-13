using Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Solicitud
    {
        public int? SolicitudId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int TecnicoAsignado { get; set; }
        public string nombreTecnico { get; set; }
        public string clienteNombre { get; set; }
        public int Cliente { get; set; }
        public string DescripcionTarea {get; set; }
        public EstadoSolicitudEnum Estado { get; set; } //1: Sin ver - 2:Pendiente - 3:Finalizado
        public PrioridadSolicitudEnum Prioridad { get; set; } //1: Urgente - 2:Moderado - 3:Sin apuro
        public ComplejidadSolicitudEnum Complejidad { get; set; } //3:Muy complejo - 2:Complejo - 1:Simple
    }
}
