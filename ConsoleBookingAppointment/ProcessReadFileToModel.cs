using BussinessBookingAppointment.Modelos;
using BussinessBookingAppointment.Models;
using BussinessBookingAppointment.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessBookingAppointment
{
    public class ProcessReadFileToModel
    {
        public static FileMedInput ReadFileMedInput()
        {
            // Lectura de archivo
            string[] FileLine = File.ReadAllLines(Constants.FilePath);
            //string[] FileLine = File.ReadAllLines(Constants.FilePath1);

            FileMedInput dataFileMedInput = new FileMedInput();
            List<BookingAppointment> dataReservationsAppointmentsRegistered = new List<BookingAppointment>();
            BookingAppointment dataReservationsAppointmentsNew = new BookingAppointment();
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

                        dataRegisteredAppointment.SpecialtyType = lineValue[1];
                        dataRegisteredAppointment.Specialty = lineValue[2];
                        dataRegisteredAppointment.PhoneContact = lineValue[7];
                        dataRegisteredAppointment.Patient = new Patient
                        {
                            NamePerson = lineValue[3],
                            PatientType = lineValue[4],
                            DocumentType = lineValue[5],
                            IndentifierDocument = lineValue[6],
                            Birthdate = lineValue[8],
                        };

                        if (dataRegisteredAppointment.Patient.PatientType == "PMENOR")
                        {
                            dataRegisteredAppointment.MedicalRepresentative = new PatientRepresentative
                            {
                                NamePerson = lineValue[10],
                                DocumentType = lineValue[11],
                                IndentifierDocument = lineValue[12],
                                Birthdate = lineValue[13]
                            };
                        }

                        dataReservationsAppointmentsRegistered.Add(dataRegisteredAppointment);
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
                        SpecialtyType = lineValue[2].Trim(),
                        Specialty = lineValue[3],
                        PhoneContact = lineValue[8],
                    };

                    dataNewAppointment.Patient = new Patient
                    {
                        NamePerson = lineValue[4],
                        PatientType = lineValue[5],
                        DocumentType = lineValue[6],
                        IndentifierDocument = lineValue[7],
                        Birthdate = lineValue[9],
                    };


                    if (dataNewAppointment.Patient.PatientType == "PMENOR")
                    {
                        dataNewAppointment.MedicalRepresentative = new PatientRepresentative
                        {
                            NamePerson = lineValue[11],
                            DocumentType = lineValue[12],
                            IndentifierDocument = lineValue[13],
                            Birthdate = lineValue[14]
                        };
                    }

                    if (dataFileMedInput != null)
                    {
                        dataReservationsAppointmentsNew = dataNewAppointment;
                    }

                }
            }
            dataFileMedInput.DataReservationsAppointmentsRegistered = dataReservationsAppointmentsRegistered;
            dataFileMedInput.DataReservationsAppointmentsNew = dataReservationsAppointmentsNew;

            return dataFileMedInput;
        }
    }
}
