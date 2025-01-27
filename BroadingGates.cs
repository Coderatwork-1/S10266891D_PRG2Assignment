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
public class BoardingGate
{
    public string GateName { get; set; }
    public bool SupportsDDJB { get; set; }
    public bool SupportsCFFT { get; set; }
    public bool SupportsLWTT { get; set; }
    public string AssignedFlight { get; set; }

    public BoardingGate(string gateName, bool supportsDDJB, bool supportsCFFT, bool supportsLWTT)
    {
        GateName = gateName;
        SupportsDDJB = supportsDDJB;
        SupportsCFFT = supportsCFFT;
        SupportsLWTT = supportsLWTT;
    }

    public override string ToString()
    {
        return $"{GateName}\t{SupportsDDJB}\t{SupportsCFFT}\t{SupportsLWTT}\t{AssignedFlight ?? "None"}";
    }
}


