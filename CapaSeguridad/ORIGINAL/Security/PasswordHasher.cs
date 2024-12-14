using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace Security
{
    public static class PasswordHasher
    {
        // Método para hashear una contraseña
        public static string HashPassword(string plainTextPassword)
        {
            if (string.IsNullOrEmpty(plainTextPassword))
                throw new ArgumentException("La contraseña no puede estar vacía.");

            // Genera el hash utilizando bcrypt
            return BCrypt.Net.BCrypt.HashPassword(plainTextPassword);
        }

        // Método para verificar una contraseña
        public static bool VerifyPassword(string plainTextPassword, string hashedPassword)
        {
            if (string.IsNullOrEmpty(plainTextPassword) || string.IsNullOrEmpty(hashedPassword))
                throw new ArgumentException("La contraseña o el hash no pueden estar vacíos.");

            // Compara la contraseña en texto plano con el hash almacenado
            return BCrypt.Net.BCrypt.Verify(plainTextPassword, hashedPassword);
        }
    }
}
