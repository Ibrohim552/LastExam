using Infrostructure.Models;
using Infrostructure.Services.Interfaces;
using Npgsql;
using System;
using System.Collections.Generic;

namespace Infrostructure.Services
{
    public class CassaService : ICassa
    {
        public bool CreateCassa(Cassa cassa)
        {
            using (var connection = new NpgsqlConnection(SqlCommands.connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(SqlCommands.insertCassa, connection))
                {
                    command.Parameters.AddWithValue("patient_id", cassa.PatientId);
                    command.Parameters.AddWithValue("doctor_id", cassa.DoctorsId);
                    command.Parameters.AddWithValue("date", cassa.Date);
                    command.Parameters.AddWithValue("total_price", cassa.TotalPrice);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteCassa(int id)
        {
            using (var connection = new NpgsqlConnection(SqlCommands.connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(SqlCommands.deleteCassa, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateCassa(Cassa cassa)
        {
            using (var connection = new NpgsqlConnection(SqlCommands.connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(SqlCommands.updateCassa, connection))
                {
                    command.Parameters.AddWithValue("id", cassa.Id);
                    command.Parameters.AddWithValue("patient_id", cassa.PatientId);
                    command.Parameters.AddWithValue("doctor_id", cassa.DoctorsId);
                    command.Parameters.AddWithValue("date", cassa.Date);
                    command.Parameters.AddWithValue("total_price", cassa.TotalPrice);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public Cassa GetCassaById(int id)
        {
            try
            {
                Cassa cassa = new();
                using (var connection = new NpgsqlConnection(SqlCommands.connectionString))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = SqlCommands.getCassaById;
                        command.Parameters.AddWithValue("@id", id);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cassa.Id = reader.GetInt32(0);
                                cassa.PatientId = reader.GetInt32(1);
                                cassa.DoctorsId = reader.GetInt32(2);
                                cassa.Date = reader.GetDateTime(3);
                                cassa.TotalPrice = reader.GetDouble(4);
                            }

                            return cassa;
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

        public List<Cassa> GetCassa()
        {
            try
            {
                List<Cassa> cassaList = new();
                using (var connection = new NpgsqlConnection(SqlCommands.connectionString))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = SqlCommands.getAllCassa;

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Cassa cassa = new Cassa
                                {
                                    Id = reader.GetInt32(0),
                                    PatientId = reader.GetInt32(1),
                                    DoctorsId = reader.GetInt32(2),
                                    Date = reader.GetDateTime(3),
                                    TotalPrice = reader.GetDouble(4)
                                };

                                cassaList.Add(cassa);
                            }
                        }
                    }

                    return cassaList;
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


