using Infrostructure.Models;

namespace Infrostructure.Services.Interfaces;
using Npgsql;
public class Database
{
    #region CreateDb
    public static void CreateDB()
    {
        try
        {
            using (NpgsqlConnection connection = new(SqlCommands.defualtConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand cmd = new())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = SqlCommands.createDataBase;
                    cmd.ExecuteNonQuery();
                }

            }
        }
        catch (NpgsqlException e)
        {
            System.Console.WriteLine(e.Message);
        }
    }

    #endregion

    #region  DropDB
    public static void DropDB()
    {
        try
        {

            using (NpgsqlConnection connection = new(SqlCommands.defualtConnectionString))
            {
                connection.Open();
                using (NpgsqlCommand cmd = new(SqlCommands.dropDataBase, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (NpgsqlException e)
        {
            System.Console.WriteLine(e.Message);
        }
    }
    #endregion
    
    #region Create and Drop Table

    public static void CreateTablePatient()
    {
        try
        {
            using(NpgsqlConnection connection = new(SqlCommands.connectionString))
            {
                connection.Open();
                using(NpgsqlCommand command = new(SqlCommands.createTablePatient,connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Table 'Patient' created successfully.");
                }
            }
        }
        catch (NpgsqlException e)
        {
            System.Console.WriteLine(e.Message);
        }
    }

    public static void DropTablePatient()
    
    {
        try
        {
            using(NpgsqlConnection connection = new(SqlCommands.connectionString))
            {
                connection.Open();
                using(NpgsqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = SqlCommands.dropTablePatient;
                    command.ExecuteNonQuery();
                    Console.WriteLine("Table 'Patient' dropped successfully.");
                }
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
        }  
    }

        public static void CreateTableDoctor()
    {
        try
        {
            using (NpgsqlConnection connection = new(SqlCommands.connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new(SqlCommands.createTabledoctor, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Table 'Students' created successfully.");
                }
            }
        }
        catch (NpgsqlException e)
        {
            System.Console.WriteLine(e.Message);
        }
    }

    public static void CreateTableCassa()
    {
        try
        {
            using (NpgsqlConnection connection = new(SqlCommands.connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = new(SqlCommands.createTablecassa, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Table 'Cassa' created successfully.");
                }
            }
        }
        catch (NpgsqlException e)
        {
            System.Console.WriteLine(e.Message);
        }
    }

        
        
    public static void DropTableCassa() 
    {
         try
        {
            using (NpgsqlConnection connection = new(SqlCommands.connectionString))
            {
                connection.Open();
                using (NpgsqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = SqlCommands.dropTableCassa;
                    command.ExecuteNonQuery();
                    Console.WriteLine("Table 'Students' dropped successfully.");
                }
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public static void CreateTableAppointment()
    {
          try
        {
            using(NpgsqlConnection connection = new(SqlCommands.connectionString))
            {
                connection.Open();
                using(NpgsqlCommand command = new(SqlCommands.createTableAppointment,connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Table 'Appointment' created successfully.");
                }
            }
        }
        catch (NpgsqlException e)
        {
            System.Console.WriteLine(e.Message);
        }
    }
    public static void DropTableAppointment()
    {
        try
        {
            using(NpgsqlConnection connection = new(SqlCommands.connectionString))
            {
                connection.Open();
                using(NpgsqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = SqlCommands.dropTableAppointment;
                    command.ExecuteNonQuery();
                    Console.WriteLine("Table 'Parents' dropped successfully.");
                }
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
        }  
    }
 
  #endregion

}