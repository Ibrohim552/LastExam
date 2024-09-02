using Infrostructure.Models;
using Infrostructure.Services.Interfaces;
using Npgsql;

namespace Infrostructure.Services
{
    public class AppointmentService : IAppointment
    {
        public bool CreateAppointment(Appointment appointment)
        {
            using (var connection = new NpgsqlConnection(SqlCommands.connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(SqlCommands.insertAppointment, connection))
                {
                    command.Parameters.AddWithValue("patient_id", appointment.PatientId);
                    command.Parameters.AddWithValue("doctor_id", appointment.DoctorsId);
                    command.Parameters.AddWithValue("appointment_day", appointment.AppointmentDay);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteAppointment(int id)
        {
            using (var connection = new NpgsqlConnection(SqlCommands.connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(SqlCommands.deleteAppointment, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateAppointment(Appointment appointment)
        {
            using (var connection = new NpgsqlConnection(SqlCommands.connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(SqlCommands.updateAppointment, connection))
                {
                    command.Parameters.AddWithValue("id", appointment.Id);
                    command.Parameters.AddWithValue("doctor_id", appointment.DoctorsId);
                    command.Parameters.AddWithValue("patient_id", appointment.PatientId);
                    command.Parameters.AddWithValue("appointment_day", appointment.AppointmentDay);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public Appointment GetAppointmentById(int id)
        {
            try
            {
                Appointment appointment = new();
                using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.connectionString))
                {
                    connection.Open();
                    using (NpgsqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = SqlCommands.getAppointmentById;
                        command.Parameters.AddWithValue("@id", id);

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                appointment.Id = reader.GetInt32(0);
                                appointment.PatientId = reader.GetInt32(1);
                                appointment.DoctorsId = reader.GetInt32(2);
                                appointment.AppointmentDay = reader.GetDateTime(3);

                            }

                            return appointment;
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

        public List<Appointment> GetAppointments()
        {
            try
            {
                List<Appointment> appointments = new();
                using (NpgsqlConnection connection = new(SqlCommands.connectionString))
                {
                    connection.Open();
                    using (NpgsqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = SqlCommands.getAllAppointments;

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Appointment appointment = new Appointment();
                                appointment.Id = reader.GetInt32(0);
                                appointment.PatientId = reader.GetInt32(1);
                                appointment.DoctorsId = reader.GetInt32(2);
                                appointment.AppointmentDay = reader.GetDateTime(3);

                               
                                appointments.Add(appointment);
                            }
                        }
                    }

                    return appointments;
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


