using ConsoleBookingAppointment.Modelos;
using ConsoleBookingAppointment.Models;
using ConsoleBookingAppointment.Utils;

public class Program
{
    static void Main()
    {
        // Lectura de archivo
        //string[] LineaArchivo = File.ReadAllLines(Constantes.RutaArchivo);
        string[] FileLine = File.ReadAllLines(Constants.FilePath1);

        FileSegment dataFileSegment = new FileSegment();
        List<Doctor> dataDoctors = new List<Doctor>();
        List<BookingAppointment> dataReservationsAppointmentsRegistered = new List<BookingAppointment>();
        List<BookingAppointment> dataReservationsAppointmentsNew = new List<BookingAppointment>();
        int sectionFileSegment = Constants.CurrentRegisteredSection;
        string dateCurrentAppointments = String.Empty;
        foreach (string line in FileLine)
        {
            if (line.Contains(Constants.NewAppointmentsSectionIdentifier))
            {
                sectionFileSegment = Constants.CurrentSectionNewAppointments;
                continue;
            }

            string[] lineValue = line.Split('|');
            
            if (sectionFileSegment == Constants.CurrentRegisteredSection)
            {
                if (lineValue.Length > 1)
                {
                    BookingAppointment dataPreviousAppointment = new BookingAppointment
                    {
                        DateAppointments = dateCurrentAppointments,
                        Hour = lineValue[0]
                        
                    };

                    dataPreviousAppointment.Doctor = new Doctor
                    {
                        SpecialtyType = lineValue[1],
                        Specialty = lineValue[2],
                        Name = lineValue[3]
                    };

                    dataPreviousAppointment.Patient = new Patient
                    {
                        DocumentType = lineValue[5],
                        Document = lineValue[6],
                        Phone = lineValue[7],
                        Birthdate = lineValue[8],
                        Age = ""
                    };

                    dataPreviousAppointment.Patient.Age = UtilityDates.calculateAge(lineValue[8]);

                    if (lineValue[4].Trim() == "PMENOR" && lineValue.Length >= 13)
                    {
                        dataPreviousAppointment.MedicalRepresentative = new MedicalRepresentative
                        {
                            Name = lineValue[10],
                            DocumentType = lineValue[11],
                            Document = lineValue[12],
                            Birthdate = lineValue[13]
                        };
                    }

                    if (dataFileSegment != null)
                    {
                        dataReservationsAppointmentsRegistered.Add(dataPreviousAppointment);
                    }


                    if (dataPreviousAppointment.Doctor != null)
                    {
                        bool exists = dataDoctors.Any(objectDataMedical => objectDataMedical.Name.Equals(dataPreviousAppointment.Doctor.Name));

                        if (!exists)
                        {
                            dataDoctors.Add(dataPreviousAppointment.Doctor);
                        }
                    }
                }
                else
                {
                    dateCurrentAppointments = lineValue[0];
                }
            }
            else
            {
                BookingAppointment dataNewAppointment = new BookingAppointment
                {
                    DateAppointments = lineValue[0],
                    Hour = lineValue[1]
                };

                dataNewAppointment.Doctor = new Doctor
                {
                    SpecialtyType = lineValue[2],
                    Specialty = lineValue[3],
                    Name = lineValue[4]
                };

                dataNewAppointment.Patient = new Patient
                {
                    DocumentType = lineValue[6],
                    Document = lineValue[7],
                    Phone = lineValue[8],
                    Birthdate = lineValue[9],
                    Age = ""
                };

                dataNewAppointment.Patient.Age = UtilityDates.calculateAge(lineValue[9]);


                if (lineValue[5].Trim() == "PMENOR" && lineValue.Length >= 13)
                {
                    dataNewAppointment.MedicalRepresentative = new MedicalRepresentative
                    {
                        Name = lineValue[11],
                        DocumentType = lineValue[12],
                        Document = lineValue[13],
                        Birthdate = lineValue[14]
                    };
                }

                if (dataFileSegment != null)
                {
                    dataReservationsAppointmentsNew.Add(dataNewAppointment);
                }


                if (dataNewAppointment.Doctor != null)
                {
                    bool exists = dataDoctors.Any(objectDataMedical => objectDataMedical.Name.Equals(dataNewAppointment.Doctor.Name));

                    if (!exists)
                    {
                        dataDoctors.Add(dataNewAppointment.Doctor);
                    }
                }

            }
        }
        dataFileSegment.DataReservationsAppointmentsRegistered = dataReservationsAppointmentsRegistered;
        dataFileSegment.DataReservationsAppointmentsNew = dataReservationsAppointmentsNew;

        ProgramHelpers.PrintListAppointments(dataFileSegment.DataReservationsAppointmentsRegistered);
        ProgramHelpers.PrintNewAppointment(dataFileSegment.DataReservationsAppointmentsNew);
    }


    public void LecturaCitasAnteriores()
    {

    }


}


