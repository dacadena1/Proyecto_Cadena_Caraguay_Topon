using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    public class UserRepository
    {
        private readonly string _connectionString;

        public UserRepository()
        {
        }

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Método para insertar un usuario
        public void CreateUser(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"INSERT INTO Users (Username, PasswordHash, Salt, Email, Role, IsActive)
                              VALUES (@Username, @PasswordHash, @Salt, @Email, @Role, @IsActive)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                    command.Parameters.AddWithValue("@Salt", user.Salt);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Role", user.Role);
                    command.Parameters.AddWithValue("@IsActive", user.IsActive);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        // Método para obtener un usuario por su nombre de usuario
        public User GetUserByUsername(string username)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = @"SELECT * FROM Users WHERE Username = @Username";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                UserID = (int)reader["UserID"],
                                Username = reader["Username"].ToString(),
                                PasswordHash = reader["PasswordHash"].ToString(),
                                Salt = reader["Salt"].ToString(),
                                Email = reader["Email"].ToString(),
                                Role = reader["Role"].ToString(),
                                IsActive = (bool)reader["IsActive"]
                            };
                        }
                    }
                }
            }

            return null;
        }
    }
}
