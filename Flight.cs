using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_II_Assignment;
//=============================================================
// Student Number: S10266891D
// Student Name: Sakthivel Murugan Pranesh
// Partner Name: Kamalkannan Kavin Balaji
//=============================================================
public class Flight : IComparable<Flight>
{
    public string FlightNumber { get; set; }
    public Airline Airline { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
    public DateTime ExpectedTime { get; set; }
    public string Status { get; set; }
    public string SpecialRequestCode { get; set; }
    public string BoardingGate { get; set; }

    public Flight(string flightNumber, Airline airline, string origin, string destination, DateTime expectedTime, string status = "Scheduled")
    {
        FlightNumber = flightNumber;
        Airline = airline;
        Origin = origin;
        Destination = destination;
        ExpectedTime = expectedTime;
        Status = status;
    }

    public int CompareTo(Flight other)
    {
        return ExpectedTime.CompareTo(other.ExpectedTime);
    }

    public override string ToString()
    {
        return $"{FlightNumber}\t{Airline.Name}\t{Origin}\t{Destination}\t{ExpectedTime:dd/MM/yyyy hh:mm tt}\t{Status}\t{BoardingGate ?? "Unassigned"}";
    }

    // NORMFlight Class
    public class NORMFlight : Flight
    {
        public override double CalculateFees()
        {
            
        }

        public override string ToString()
        {
            return base.ToString() + ", Type: Normal";
        }
    }

    // CFFTFlight Class
    public class CFFTFlight : Flight
    {
        public override double CalculateFees()
        {
            
        }

        public override string ToString()
        {
            return base.ToString() + ", Type: CFFT";
        }
    }

    // LWTFlight Class
    public class LWTFlight : Flight
    {
        public override double CalculateFees()
        {
           
        }

        public override string ToString()
        {
            return base.ToString() + ", Type: LWT";
        }
    }

    // DDJFlight Class
    public class DDJFlight : Flight
    {
        public override double CalculateFees()
        {
         
        }

        public override string ToString()
        {
            return base.ToString() + ", Type: DDJ";
        }
    }


