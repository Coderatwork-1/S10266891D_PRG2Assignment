using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//=============================================================
// Student Number: S10266891D
// Student Name: Sakthivel Murugan Pranesh
// Partner Name: Kamalkannan Kavin Balaji
//=============================================================

namespace Assignment
{
    public class Flight
    {
        public string FlightNumber { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime ExpectedTime { get; set; }
        public string Status { get; set; }
        public string SpecialRequestCode { get; set; }
        public string BoardingGate { get; set; }

        public Flight(string fn, string ori, string dest, DateTime et, string status = "On Time")
        {
            FlightNumber = fn;
            Origin = ori;
            Destination = dest;
            ExpectedTime = et;
            Status = status;
        }

        public virtual double CalculateFees()
        {
            return 100.0;
        }

        public override string ToString()
        {
            return $"Flight: {FlightNumber}\tOrigin: {Origin}\tDestination: {Destination}\tExpectedTime: {ExpectedTime}\tStatus: {Status}";
        }
    }

    //DDJBFLight
    class DDJBFlight : Flight
    {
        public DDJBFlight(string fn, string ori, string dest, DateTime et)
            : base(fn, ori, dest, et)
        {
        }

        public override double CalculateFees()
        {
            double fee = 0;
            if (Origin == "Singapore (SIN)")
                fee += 800;
            if (Destination == "Singapore (SIN)")
                fee += 500;
            fee += 300;
            fee += 300;
            return fee;
        }
    }


    // LWTTFFight
    class LWTTFlight : Flight
    {
        public LWTTFlight(string fn, string ori, string dest, DateTime et)
            : base(fn, ori, dest, et)
        {
        }

        public override double CalculateFees()
        {
            double fee = 0;
            if (Origin == "Singapore (SIN)")
                fee += 800;
            if (Destination == "Singapore (SIN)")
                fee += 500;
            fee += 300;
            fee += 500;
            return fee;
        }
    }

    // NormalFlight
    class NormalFlight : Flight
    {
        public NormalFlight(string fn, string ori, string dest, DateTime et)
            : base(fn, ori, dest, et)
        {
        }

        public override double CalculateFees()
        {
            double fee = 0;
            if (Origin == "Singapore (SIN)")
                fee += 800;
            if (Destination == "Singapore (SIN)")
                fee += 500;
            fee += 300;
            return fee;
        }
    }

    // CFFTFLight
    class CFFTFlight : Flight
    {
        public CFFTFlight(string fn, string ori, string dest, DateTime et)
            : base(fn, ori, dest, et)
        {
        }

        public override double CalculateFees()
        {
            double fee = 0;
            if (Origin == "Singapore (SIN)")
                fee += 800;
            if (Destination == "Singapore (SIN)")
                fee += 500;
            fee += 300;
            fee += 150;
            return fee;
        }
    }
}

