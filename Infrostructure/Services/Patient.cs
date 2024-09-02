using Infrostructure.Models;
using Infrostructure.Services.Interfaces;
using Npgsql;

namespace Infrostructure.Services
{
    public class PatientService : IPatientService
    {
        public bool CreatePatient(Patient patient)
        {
            using (var connection = new NpgsqlConnection(SqlCommands.connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(SqlCommands.insertPatient, connection))
                {
                    command.Parameters.AddWithValue("age", patient.Age);
                    command.Parameters.AddWithValue("first_name", patient.FirstName);
                    command.Parameters.AddWithValue("last_name", patient.LastName);
                    command.Parameters.AddWithValue("email", patient.Email);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeletePatient(int id)
        {
            using (var connection = new NpgsqlConnection(SqlCommands.connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(SqlCommands.deleteParient, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdatePatient(Patient patient)
        {
            using (var connection = new NpgsqlConnection(SqlCommands.connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(SqlCommands.updateParient, connection))
                {
                    command.Parameters.AddWithValue("id", patient.Id);
                    command.Parameters.AddWithValue("age", patient.Age);
                    command.Parameters.AddWithValue("first_name", patient.FirstName);
                    command.Parameters.AddWithValue("last_name", patient.LastName);
                    command.Parameters.AddWithValue("email", patient.Email);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public Patient GetPatientById(int id)
        {
            try
            {
                Patient patient = new();
                using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.connectionString))
                {
                    connection.Open();
                    using (NpgsqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = SqlCommands.getParientById;
                        command.Parameters.AddWithValue("@id", id);

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                patient.Id = reader.GetInt32(0);
                                patient.Age = reader.GetInt32(1);
                                patient.FirstName = reader.GetString(2);
                                patient.LastName = reader.GetString(3);
                                patient.Email = reader.GetString(4);
                            }

                            return patient;
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

        public List<Patient> GetPatients()
        {
            try
            {
                List<Patient> patients = new();
                using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.connectionString))
                {
                    connection.Open();
                    using (NpgsqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = SqlCommands.getAllParients;

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Patient patient = new Patient();
                                patient.Id = reader.GetInt32(0);
                                patient.Age = reader.GetInt32(1);
                                patient.FirstName = reader.GetString(2);
                                patient.LastName = reader.GetString(3);
                                patient.Email = reader.GetString(4);

                                patients.Add(patient);
                            }
                        }
                    }

                    return patients;
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
