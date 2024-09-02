using Infrostructure.Models;
using Infrostructure.Services.Interfaces;
using Npgsql;

namespace Infrostructure.Services
{
    public class DoctorService : IDoctorService
    {
        public bool CreateDoctor(Doctor doctor)
        {
            using (var connection = new NpgsqlConnection(SqlCommands.connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(SqlCommands.insertDoctor, connection))
                {
                    command.Parameters.AddWithValue("age", doctor.Age);
                    command.Parameters.AddWithValue("fullname", doctor.FullName);
                    command.Parameters.AddWithValue("experience", doctor.Experience);
                    command.Parameters.AddWithValue("email", doctor.Email);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteDoctor(int id)
        {
            using (var connection = new NpgsqlConnection(SqlCommands.connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(SqlCommands.deleteDoctor, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateDoctor(Doctor doctor)
        {
            using (var connection = new NpgsqlConnection(SqlCommands.connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(SqlCommands.updateDoctor, connection))
                {
                    command.Parameters.AddWithValue("id", doctor.Id);
                    command.Parameters.AddWithValue("age", doctor.Age);
                    command.Parameters.AddWithValue("fullname", doctor.FullName);
                    command.Parameters.AddWithValue("experience", doctor.Experience);
                    command.Parameters.AddWithValue("email", doctor.Email);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public Doctor GetDoctorById(int id)
        {
            try
            {
                Doctor doctor = new();
                using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.connectionString))
                {
                    connection.Open();
                    using (NpgsqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = SqlCommands.getDoctorById;
                        command.Parameters.AddWithValue("@id", id);

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                doctor.Id = reader.GetInt32(0);
                                doctor.Age = reader.GetInt32(1);
                                doctor.FullName = reader.GetString(2);
                                doctor.Experience = reader.GetInt32(3);
                                doctor.Email = reader.GetString(4);
                            }

                            return doctor;
                        }
                    }
                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public List<Doctor> GetDoctors()
        {
            try
            {
                List<Doctor> doctors = new();
                using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.connectionString))
                {
                    connection.Open();
                    using (NpgsqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = SqlCommands.getAllDoctors;

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Doctor doctor = new Doctor();
                                doctor.Id = reader.GetInt32(0);
                                doctor.Age = reader.GetInt32(1);
                                doctor.FullName = reader.GetString(2);
                                doctor.Experience = reader.GetInt32(3);
                                doctor.Email = reader.GetString(4);

                                doctors.Add(doctor);
                            }
                        }
                    }

                    return doctors;
                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
