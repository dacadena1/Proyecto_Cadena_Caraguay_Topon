using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public int UserID { get; set; } // Identificador único del usuario
        public string Username { get; set; } // Nombre de usuario único
        public string PasswordHash { get; set; } // Hash seguro de la contraseña
        public string Salt { get; set; } // Salt usado para el hash de la contraseña
        public string Email { get; set; } // Correo electrónico del usuario
        public string Role { get; set; } // Rol del usuario (ej. Admin, Editor, Viewer)
        public bool IsActive { get; set; } // Estado del usuario (activo/inactivo)

       
    }


}


