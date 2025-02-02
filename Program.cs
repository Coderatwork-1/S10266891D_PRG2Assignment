using S102266891D_PRG2Assignment;
//=============================================================
// Student Number: S10266891D
// Student Name: Sakthivel Murugan Pranesh
// Partner Name: Kamalkannan Kavin Balaji
//=============================================================
Dictionary<string, Airline> airlineDictionary = new Dictionary<string, Airline>();
Dictionary<string, BoardingGate> boardingGates = new Dictionary<string, BoardingGate>();
Dictionary<string, Flight> flights = new Dictionary<string, Flight>();

LoadAirlines(airlineDictionary);
LoadBoardingGates(boardingGates);
LoadFlights(flights, airlineDictionary);

while (true)
{
    DisplayMenu();
    Console.Write("Enter your option: ");
    string option = Console.ReadLine();

    if (option == "0")
    {
        Console.WriteLine("Goodbye!");
        break;
    }
    else if (option == "1")
    {
        ListFlightsInformation(flights, airlineDictionary);
    }
    else if (option == "2")
    {
        ListBoardingGates(boardingGates);
    }
    else if (option == "3")
    {
        AssignBoardingGate(flights, boardingGates);
    }
    else if (option == "4")
    {
        CreateFlight(flights);
    }
    else if (option == "5")
    {
        DisplayFlightDetailsFromAirline(airlineDictionary, boardingGates);
    }
    else if (option == "6")
    {
        ListFlightsForAirline(airlineDictionary);
        ModifyFlightDetails(flights, airlineDictionary);
    }
    else if (option == "7")
    {
        DisplayFlightSchedule(flights);
    }
    else if (option == "8")
    {
        ProcessUnassignedFlights(flights, boardingGates);
    }
    else
    {
        Console.WriteLine("Invalid option, please try again.");
    }

    Console.WriteLine();
}


static void DisplayMenu()
{
    Console.WriteLine("");
    Console.WriteLine("==================================================\r\nWelcome to Changi Airport Terminal 5\r\n==================================================\r\n1. List All Flights\r\n2. List Boarding Gates\r\n3. Assign a Boarding Gate to a Flight\r\n4. Create Flight\r\n5. Display Airline Flights\r\n6. Modify Flight Details\r\n7. Display Flight Schedule\r\n8. Process Unassigned Flights \r\n9. Display Total Fee\r\n0. Exit\r\nPlease select your option:");
}

static void LoadAirlines(Dictionary<string, Airline> airlines)
{
    try
    {
        
        string airlinesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "C:\\Users\\Kavin\\source\\repos\\Assignment\\Assignment\\airlines.csv");
        Console.WriteLine("Loading Airlines from: " + Path.GetFullPath(airlinesPath));

        string[] airlinesLines = File.ReadAllLines(airlinesPath);
        for (int i = 1; i < airlinesLines.Length; i++)
        {
            string[] columns = airlinesLines[i].Split(',');
            string name = columns[0];
            string code = columns[1];

            Airline airline = new Airline(code, name);
            airlines[code] = airline;
        }
        Console.WriteLine($"{airlines.Count} Airlines Loaded!");
    }
    catch (FileNotFoundException ex)
    {
        Console.WriteLine($"Error: The file 'airlines.csv' was not found. Please ensure it exists in the correct directory.");
        Console.WriteLine($"Expected Path: {Path.GetFullPath("airlines.csv")}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
}

static void LoadBoardingGates(Dictionary<string, BoardingGate> boardingGates)
{
    Console.WriteLine("Loading Boarding Gates...");

   
    string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "C:\\Users\\Kavin\\source\\repos\\Assignment\\Assignment\\boardinggates.csv");

    if (File.Exists(filePath))
    {
        string[] gatesLines = File.ReadAllLines(filePath);
        for (int i = 1; i < gatesLines.Length; i++)
        {
            string[] columns = gatesLines[i].Split(',');
            string gateName = columns[0];
            bool supportsDDJB = bool.Parse(columns[1]);
            bool supportsCFFT = bool.Parse(columns[2]);
            bool supportsLWTT = bool.Parse(columns[3]);

            BoardingGate gate = new BoardingGate(gateName, supportsCFFT, supportsDDJB, supportsLWTT);
            boardingGates[gateName] = gate;
        }
        Console.WriteLine($"{boardingGates.Count} Boarding Gates Loaded!");
    }
    else
    {
        Console.WriteLine($"File not found at path: {filePath}");
    }
}

static void LoadFlights(Dictionary<string, Flight> flights, Dictionary<string, Airline> airlineDictionary)
{
    Console.WriteLine("Loading Flights...");

    string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "C:\\Users\\Kavin\\source\\repos\\Assignment\\Assignment\\flights.csv");

    if (File.Exists(filePath))
    {
        string[] flightsLines = File.ReadAllLines(filePath);
        for (int i = 1; i < flightsLines.Length; i++)
        {
            string[] columns = flightsLines[i].Split(',');
            string flightNumber = columns[0];
            string origin = columns[1];
            string destination = columns[2];
            DateTime expectedTime = DateTime.Parse(columns[3]);
            string requestCode = columns[4];

            Flight newFlight;

            if (requestCode == "DDJB")
            {
                newFlight = new DDJBFlight(flightNumber, origin, destination, expectedTime);
            }
            else if (requestCode == "CFFT")
            {
                newFlight = new CFFTFlight(flightNumber, origin, destination, expectedTime);
            }
            else if (requestCode == "LWTT")
            {
                newFlight = new LWTTFlight(flightNumber, origin, destination, expectedTime);
            }
            else
            {
                newFlight = new NormalFlight(flightNumber, origin, destination, expectedTime);
            }

            flights[flightNumber] = newFlight;

            string airlineCode = flightNumber.Substring(0, 2);
            if (airlineDictionary.ContainsKey(airlineCode))
            {
                Airline airline = airlineDictionary[airlineCode];
                airline.AddFlight(newFlight);
            }
        }
        Console.WriteLine($"{flights.Count} Flights Loaded!");
    }
    else
    {
        Console.WriteLine($"File not found at path: {filePath}");
    }
}

static void ListFlightsInformation(Dictionary<string, Flight> flights, Dictionary<string, Airline> airlineDictionary)
{
    Console.WriteLine("==================================================");
    Console.WriteLine("List of Flights for Changi Airport Terminal 5");
    Console.WriteLine("==================================================");
    Console.WriteLine("{0,-16} {1,-20} {2,-20} {3,-25} {4,-10}", "Flight Number", "Airline Name", "Origin", "Destination", "Expected Departure/Arrival Time");

    foreach (var flight in flights.Values)
    {
        string airlineCode = flight.FlightNumber.Substring(0, 2);
        string airlineName = airlineDictionary.ContainsKey(airlineCode) ? airlineDictionary[airlineCode].Name : "Unknown Airline";
        string formattedTime = flight.ExpectedTime.ToString("dd/MM/yyyy hh:mm:ss tt");

        Console.WriteLine("{0,-16} {1,-20} {2,-20} {3,-25} {4,-10}",
            flight.FlightNumber, airlineName, flight.Origin, flight.Destination, formattedTime);
    }

    Console.WriteLine("==================================================");
}


static void ListBoardingGates(Dictionary<string, BoardingGate> boardingGates)
{
    Console.WriteLine("==================================================\r\nList of Boarding Gates for Changi Airport Terminal 5\r\n==================================================");
    Console.WriteLine("{0,-12} {1,-8} {2,-8} {3,-8}", "Gate Name", "DDJB", "CFFT", "LWTT");
    foreach (var gate in boardingGates.Values)
    {
        Console.WriteLine("{0,-12} {1,-8} {2,-8} {3,-8}",
            gate.GateName, gate.SupportsDDJB ? "True" : "False", gate.SupportsCFFT ? "True" : "False", gate.SupportsLWTT ? "True" : "False");
    }
}
