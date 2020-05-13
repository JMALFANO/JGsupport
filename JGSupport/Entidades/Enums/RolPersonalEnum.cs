using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Enums
{
    //4:Administrador - 3:Coordinador - 2:Tecnico - 1:Cliente
    public enum RolPersonalEnum
        {
            Pendiente = 1,
            Cliente = 2,
            Tecnico = 3,
            Coordinador = 4,
            Administrador = 5,
        }
}
