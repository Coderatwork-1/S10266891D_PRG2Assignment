namespace Programming_II_Assignment;
//=============================================================
// Student Number: S10266891D
// Student Name: Sakthivel Murugan Pranesh
// Partner Name: Kamalkannan Kavin Balaji
//=============================================================
public class Terminal
{
 public string TerminalNm { get; set; }
        public Dictionary<string, Airline> Airlines { get; private set; } = new Dictionary<string, Airline>();
        public Dictionary<string, Flight> Flights { get; private set; } = new Dictionary<string, Flight>();
        public Dictionary<string, BoardingGate> BoardingGates { get; private set; } = new Dictionary<string, BoardingGate>();
        public Dictionary<string, double> GateFees { get; private set; } = new Dictionary<string, double>();

        public Terminal(string terminalNm)
        {
            TerminalNm = terminalNm
                
                
        }

        public bool AddAirline(Airline airline)
        {
            if (!Airlines.ContainsKey(airline.Code))
            {
                Airlines[airline.Code] = airline;
                return true;
            }
            return false;
        }

        public bool AddBoardingGate(BoardingGate gate)
        {
            if (!BoardingGates.ContainsKey(gate.GateName))
            {
                BoardingGates[gate.GateName] = gate;
                return true;
            }
            return false;
        }

        public Airline GetAirlineFromFlight(Flight flight)
        {
            foreach (var airline in Airlines.Values)
            {
                if (airline.Flights.ContainsKey(flight.FlightNumber))
                {
                    return airline;
                }
            }
            return null;
        }

        public void PrintAirlineFees()
        {
            foreach (var airline in Airlines.Values)
            {
                Console.WriteLine($"{airline.Name} Fees: {airline.CalculateFees():C}");
            }
        }
        public double CalculateGateFees()
        {
            double total = 0;
            foreach (var gate in BoardingGates.Values)
            {
                if (GateFees.ContainsKey(gate.GateName))
                    total += GateFees[gate.GateName];
            }
            return total;
        }
        public override string ToString()
        {
            return "Terminal: " + TerminalName +
                "\tAirlines: " + Airlines.Count +
                "\tFlights: " + Flights.Count +
                "\tGates: " + BoardingGates.Count;
        }
    }
}


