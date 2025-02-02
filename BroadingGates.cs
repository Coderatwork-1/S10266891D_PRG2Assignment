using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//=========================================
// Student Number: S10266891D
// Student Name: Sakthivel Murugan Pranesh
// Partner Name: Kamalkannan Kavin Balaji
//========================================

namespace S102266891D_PRG2Assignment
{
    public class BoardingGate
    {
    
            public string GateName { get; set; }
            public bool SupportsCFFT { get; set; }
            public bool SupportsDDJB { get; set; }
            public bool SupportsLWTT { get; set; }
            public Flight Flight { get; set; }

            public BoardingGate(string gateName, bool supportsCFFT, bool supportsDDJB, bool supportsLWTT)
            {
                GateName = gateName;
                SupportsCFFT = supportsCFFT;
                SupportsDDJB = supportsDDJB;
                SupportsLWTT = supportsLWTT;
            }

            public double CalculateFees()
            {
                return Flight?.CalculateFees() ?? 0;
            }

            public override string ToString()
            {
                return "Gate: " + GateName +
                    "\tSupports CFFT: " + SupportsCFFT +
                    "\tSupports DDJB: " + SupportsDDJB +
                    "\tSupports LWTT: " + SupportsLWTT;
            }

        }
    }




