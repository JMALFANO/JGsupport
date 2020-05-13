using Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Privilegio
    {
        public int id_privilegio { get; set; }
        public string privilegio_Desc { get; set; }
      //  public RolPersonalEnum Rol { get; set; } //4:Administrador - 3:Coordinador - 2:Tecnico - 1:Cliente

        public Privilegio()
        {  

        }
    }
}
