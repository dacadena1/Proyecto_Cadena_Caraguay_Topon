using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BLL
{
    public class UserLogic
    {
        private readonly UserRepository _userRepository;

        public UserLogic(string connectionString)
        {
            _userRepository = new UserRepository(connectionString);
        }

        public void RegisterUser(User user)
        {
            // Aquí puedes agregar lógica de negocio, como validaciones, antes de insertar al usuario
            _userRepository.CreateUser(user);
        }

        public User Login(string username, string password)
        {
            var user = _userRepository.GetUserByUsername(username);
            if (user != null && ValidatePassword(password, user.PasswordHash, user.Salt))
            {
                return user; // Usuario autenticado
            }

            throw new Exception("Credenciales inválidas");
        }

        private bool ValidatePassword(string password, string hash, string salt)
        {
            // Lógica para validar el hash con el salt
            return true; // Implementar validación real
        }
    }
}
