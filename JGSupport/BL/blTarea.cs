using Entidades;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class blTarea
    {

        public List<Tarea> Listar()
        {
            return new dalTarea().Listar();
        }

        public List<Tarea> ListarPorTecnico(int id_tecnico)
        {
            return new dalTarea().ListarPorTecnico(id_tecnico);
        }

        public List<Tarea> ObtenerPorSolicitudId(int solicitudId)
        {
            return new dalTarea().ObtenerPorSolicitudId(solicitudId);
        }

        public Tarea ObtenerPorId(int TareaId)
        {
            return new dalTarea().ObtenerPorId(TareaId);
        }

        public void Guardar(Tarea tarea)
        {
            if (tarea.TareaId != null)
                new dalTarea().Modificar(tarea);
            else
                new dalTarea().Insertar(tarea);
        }


    }
}
