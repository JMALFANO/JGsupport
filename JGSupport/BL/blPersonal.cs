using DAL;
using Entidades;
using System.Collections.Generic;

namespace BL
{
    public class blPersonal
    {
        public List<Personal> Listar()
        {
            return new dalPersonal().Listar();
        }

        public List<Personal> ListarClientes()
        {
            return new dalPersonal().ListarClientes();
        }

        public List<Personal> ListarTecnicos()
        {
            return new dalPersonal().ListarTecnicos();
        }

        public List<Personal> ListarPorCategoria(int id_privilegio)
            {
                return new dalPersonal().ListarPorCategoria(id_privilegio);
            }
           

        public Personal ObtenerPorId(int personalId)
        {
            return new dalPersonal().ObtenerPorId(personalId);
        }

        public int ValidarUsuario(string mail, string contraseña)
        {
            return new dalPersonal().ValidarUsuario(mail, contraseña);
        }

        public int ObtenerIdUsuario(string mail, string contraseña)
        {
            return new dalPersonal().ObtenerIdUsuario(mail, contraseña);
        }

        public void Guardar(Personal personal)
        {
            if (personal.PersonalId != null)
                new dalPersonal().Modificar(personal);
            else
                new dalPersonal().Insertar(personal);

        }

    }
}