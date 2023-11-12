using ConsoleBookingAppointment.Modelos;
using ConsoleBookingAppointment.Models;
using ConsoleBookingAppointment.Utils;

public class Program
{
    static void Main()
    {
        // Lectura de archivo
        string[] FileLine = File.ReadAllLines(Constants.FilePath);
        //string[] FileLine = File.ReadAllLines(Constants.FilePath1);

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
                    BookingAppointment dataRegisteredAppointment = new BookingAppointment
                    {
                        DateAppointment = dateCurrentAppointments,
                        HourAppointment = lineValue[0]
                        
                    };

                    //dataPreviousAppointment.Doctor = new Doctor
                    //{
                    //    SpecialtyType = lineValue[1],
                    //    Specialty = lineValue[2],
                    //    Name = lineValue[3]
                    //};
                    dataRegisteredAppointment.SpecialtyType = lineValue[1];
                    dataRegisteredAppointment.Specialty = lineValue[2];
                    dataRegisteredAppointment.Patient = new Patient
                    {
                        NamePerson = lineValue[3],
                        PatientType = lineValue[4],
                        DocumentType = lineValue[5],
                        IndentifierDocument = lineValue[6],
                        Phone = lineValue[7],
                        Birthdate = lineValue[8],
                        //Age = ""
                    };

                    //dataPreviousAppointment.Patient.Age = UtilityDates.calculateAge(lineValue[8]);

                    //if (lineValue[4].Trim() == "PMENOR" && lineValue.Length >= 13)
                    if (dataRegisteredAppointment.Patient.PatientType == "PMENOR")
                    {
                        dataRegisteredAppointment.MedicalRepresentative = new MedicalRepresentative
                        {
                            NamePerson = lineValue[10],
                            DocumentType = lineValue[11],
                            IndentifierDocument = lineValue[12],
                            Birthdate = lineValue[13]
                        };
                    }

                    if (dataFileSegment != null)
                    {
                        dataReservationsAppointmentsRegistered.Add(dataRegisteredAppointment);
                    }


                    //if (dataPreviousAppointment.Doctor != null)
                    //{
                    //    bool exists = dataDoctors.Any(objectDataMedical => objectDataMedical.Name.Equals(dataPreviousAppointment.Doctor.Name));

                    //    if (!exists)
                    //    {
                    //        dataDoctors.Add(dataPreviousAppointment.Doctor);
                    //    }
                    //}
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
                    DateAppointment = lineValue[0],
                    HourAppointment = lineValue[1],
                    SpecialtyType = lineValue[2],
                    Specialty = lineValue[3],
                };

                //dataNewAppointment.Doctor = new Doctor
                //{
                //    SpecialtyType = lineValue[2],
                //    Specialty = lineValue[3],
                //    Name = lineValue[4]
                //};

                dataNewAppointment.Patient = new Patient
                {
                    NamePerson = lineValue[4],
                    PatientType = lineValue[5],
                    DocumentType = lineValue[6],
                    IndentifierDocument = lineValue[7],
                    Phone = lineValue[8],
                    Birthdate = lineValue[9],
                    //Age = ""
                };

                //dataNewAppointment.Patient.Age = UtilityDates.calculateAge(lineValue[9]);


                //if (lineValue[5].Trim() == "PMENOR" && lineValue.Length >= 13)
                if (dataNewAppointment.Patient.PatientType == "PMENOR")
                {
                    dataNewAppointment.MedicalRepresentative = new MedicalRepresentative
                    {
                        NamePerson = lineValue[11],
                        DocumentType = lineValue[12],
                        IndentifierDocument = lineValue[13],
                        Birthdate = lineValue[14]
                    };
                }

                if (dataFileSegment != null)
                {
                    dataReservationsAppointmentsNew.Add(dataNewAppointment);
                }

                //if (dataNewAppointment.Doctor != null)
                //{
                //    bool exists = dataDoctors.Any(objectDataMedical => objectDataMedical.Name.Equals(dataNewAppointment.Doctor.Name));

                //    if (!exists)
                //    {
                //        dataDoctors.Add(dataNewAppointment.Doctor);
                //    }
                //}

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


