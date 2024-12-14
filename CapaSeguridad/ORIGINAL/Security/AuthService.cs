using System;
using DAL; // Acceso a datos
using Entities; // Modelos
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Security
{
    public class AuthService
    {
        public readonly UserRepository _userRepository = new UserRepository();

        public User Login(string username, string password)
        {
            var user = _userRepository.GetUserByUsername(username);

            if (user == null || !PasswordHasher.Verify(password, user.PasswordHash))
            {
                throw new Exception("Usuario o contraseña incorrectos.");
            }

            if (!user.IsActive)
            {
                throw new Exception("La cuenta está desactivada.");
            }

            return user;
        }

        public void Logout(string sessionId)
        {
            // Lógica para cerrar sesión e invalidar la sesión
        }
    }
}
