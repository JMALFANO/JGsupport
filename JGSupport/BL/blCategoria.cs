using DAL;
using Entidades;
using System.Collections.Generic;

namespace BL
{
    public class blCategoria
    {
        public List<Privilegio> Listar()
        {
            return new dalCategoria().Listar();
        }
    }
}
