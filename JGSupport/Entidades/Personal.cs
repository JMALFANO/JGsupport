namespace Entidades
{

    public class Personal
    {
        public int? PersonalId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public string Contraseña { get; set; }
        public bool Activo { get; set; }
       // public RolPersonalEnum Rol { get; set; } 
        public Privilegio Privilegio { get; set; }

        public Personal()
        {
            this.Privilegio = new Privilegio();      
        }
    }    
}
