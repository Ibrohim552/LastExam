namespace Infrostructure.Models;

public class SqlCommands
{
    #region Connection
    public const string defualtConnectionString = "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=postgres;";
    public const string connectionString = "Server=localhost;Port=5432;Database=Clinics;User Id=postgres;Password=postgres;";
    public const string createDataBase = "Create Database Clinics";
    public const string dropDataBase = "Drop Database Clinics with(force)";
    #endregion

    #region CreateTable
    public const string createTablePatient = @"CREATE TABLE patient (
                                              id SERIAL PRIMARY KEY,
                                              first_name VARCHAR(50) NOT NULL,  
                                              last_name VARCHAR(50) NOT NULL,
                                              age INT ,
                                              doctors_id INT ,
                                              FOREIGN KEY (doctors_id) REFERENCES doctor(id),
                                          
                                              );";

    public const string createTabledoctor = @"CREATE TABLE doctor (
                                             id SERIAL PRIMARY KEY,
                                             fullname varchar(50) not null ,
                                             age INT,
                                             email VARCHAR(50) NOT NULL UNIQUE,
                                             experience int NOT NULL
                                             );";

    public const string createTablecassa = @"CREATE TABLE Cassa (
                                             id SERIAL PRIMARY KEY,
                                             patient_id INT NOT NULL,
                                             doctor_id INT NOT NULL,
                                             date DATE NOT NULL,
                                             total_price DECIMAL(10,2) NOT NULL,
                                             FOREIGN KEY (patient_id) references patient(id),
                                             FOREIGN KEY (doctor_id) REFERENCES doctor(id)
                                             ;";
                                             
    public const string createTableAppointment= @"CREATE TABLE Appointment (
                                             id SERIAL PRIMARY KEY,
                                             patient_id int,
                                             doctor_id INT,
                                             AppointmentDay DATE NOT NULL,
                                             FOREIGN KEY (patient_id) REFERENCES patient(id),
                                             FOREIGN KEY (doctor_id) REFERENCES doctor(id) 
                                                 );";
    #endregion

   

    #region dropTable 
    public const string dropTableAppointment = @"DROP TABLE Appointment";
    public const string dropTableCassa = @"DROP TABLE Cassa";
    public const string dropTableDoctor = @"DROP TABLE doctor";
    public const string dropTablePatient = @"DROP TABLE patient";

    #endregion

    #region insert
    public const string insertDoctor = @"INSERT INTO doctor (Age, Fullname,  Experience,Email) VALUES (@Age, @Fullname, @Experience, @Email)";
    public const string insertPatient = @"INSERT INTO patient (Age, FirstName, LastName, email) VALUES (@Age, @FirstName, @LastName, @email)";
    public const string insertAppointment = @"INSERT INTO Appointment (DoctorId, PatientId, Appointmentday) VALUES (@DoctorId, @PatienId, @Appointment)";
    public const string insertCassa = @"INSERT INTO Cassa (PatientId, DoctorsID,Date,TotalPrice) VALUES (@PatientId, @DoctorId,@Date,@TotalPrice)";
   #endregion


#region Update
    public const string updateCassa = @"UPDATE cassa SET patient_id=@PatientId, doctors_id=@DoctorsId, date=@Date, total_price=@TotalPrice WHERE id=@Id";
    public const string updateDoctor = @"UPDATE doctor SET age=@Age, fullname=@Fullname, experience=@Experience, email=@Email WHERE id=@Id";
    public const string updateParient = @"UPDATE parient SET age=@Age, first_name=@FirstName, last_name=@LastName, email=@Email WHERE id=@Id";
    public const string updateAppointment = @"UPDATE appointment SET doctors_id=@DoctorsId, patient_id=@PatientID, appointment_day=@AppointmentDay WHERE id=@Id";
    #endregion

    #region delete
    public const string deleteCassa = @"DELETE FROM cassa WHERE id=@Id";
    public const string deleteDoctor = @"DELETE FROM doctor WHERE id=@Id";
    public const string deleteParient = @"DELETE FROM parient WHERE id=@Id";
    public const string deleteAppointment = @"DELETE FROM appointment WHERE id=@Id";
    #endregion

    #region getAll
    public const string getAllCassa = @"SELECT * FROM cassa";
    public const string getAllDoctors = @"SELECT * FROM doctor";
    public const string getAllParients = @"SELECT * FROM parient";
    public const string getAllAppointments = @"SELECT * FROM appointment";
    #endregion

    #region GetById
    public const string getCassaById = @"SELECT * FROM cassa WHERE id=@Id";
    public const string getDoctorById = @"SELECT * FROM doctor WHERE id=@Id";
    public const string getParientById = @"SELECT * FROM parient WHERE id=@Id";
    public const string getAppointmentById = @"SELECT * FROM appointment WHERE id=@Id";
    #endregion


    #region join

    public const string getPatientAndTotalPrice = @"
    SELECT p.FirstName || ' ' || p.LastName as FullName,
    SUM(c.TotalPrice) as TotalPrice,
     c.Date, COUNT(c.TotalPrice) as OperationCount
    FROM patient as p  JOIN 
    Cassa as c ON   p.Id = c.PatientId
    GROUP BY p.Id, p.FirstName, p.LastName, c.Date
    ORDER BY  p.FirstName, p.LastName;
";

    public const string getDoctorAndAppointmentCount = @"
    SELECT d.FirstName || ' ' || d.LastName as FullName,
    COUNT(a.Id) as AppointmentCount
    FROM  doctor as d
    JOIN appointment as a 
    ON d.Id = a.DoctorId
    GROUP BY  d.Id, d.FirstName, d.LastName
    ORDER BY AppointmentCount DESC;
";
    
    public const string getPatientAndAppointmentCount = @"
    SELECT  p.FirstName || ' ' || p.LastName as FullName,
    COUNT(a.Id) as AppointmentCount
    FROM  patient as p
    JOIN appointment as a 
    ON p.Id = a.PatientId
    GROUP BY  p.Id, p.FirstName, p.LastName
    ORDER BY AppointmentCount DESC;
";

    public const string getAppointmentAndTotalPayments = @"
    SELECT  a.Id as AppointmentId,
    SUM(c.TotalPrice) as TotalPayment
    FROM  appointment as a
    JOIN cassa as c 
    ON a.Id = c.AppointmentId
    GROUP BY  a.Id
    ORDER BY TotalPayment DESC;
";


    #endregion
}