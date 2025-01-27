using Programming_II_Assignment;
//=============================================================
// Student Number: S10266891D
// Student Name: Sakthivel Murugan Pranesh
// Partner Name: Kamalkannan Kavin Balaji
//=============================================================

class Program
{
    private static Dictionary<string, Airline> airlines = new Dictionary<string, Airline>();
    private static List<Flight> flights = new List<Flight>();
    private static List<BoardingGate> boardingGates = new List<BoardingGate>();

    static void Main(string[] args)
    {
        LoadData();

        while (true)
        {
            Console.WriteLine("=============================================");
            Console.WriteLine("Welcome to Changi Airport Terminal 5");
            Console.WriteLine("=============================================");
            Console.WriteLine("1. List All Flights");
            Console.WriteLine("2. List Boarding Gates");
            Console.WriteLine("3. Assign a Boarding Gate to a Flight");
            Console.WriteLine("4. Exit");
            Console.Write("Please select your option: ");

            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    ListFlights();
                    break;
                case "2":
                    ListBoardingGates();
                    break;
                case "3":
                    AssignBoardingGate();
                    break;
                case "4":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private static void LoadData()
    {
        string basePath = AppDomain.CurrentDomain.BaseDirectory;

        // Load airlines
        Console.WriteLine("Loading Airlines...");
        try
        {
            string airlinesPath = Path.Combine(basePath, "airlines.csv");
            foreach (var line in File.ReadLines(airlinesPath))
            {
                var parts = line.Split(',');
                if (parts.Length == 2)
                {
                    airlines.Add(parts[0].Trim(), new Airline(parts[0].Trim(), parts[1].Trim()));
                }
            }
            Console.WriteLine("Airlines Loaded: " + airlines.Count);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading airlines: " + ex.Message);
        }

        // Load boarding gates
        Console.WriteLine("Loading Boarding Gates...");
        try
        {
            string boardingGatesPath = Path.Combine(basePath, "boardinggates.csv");
            foreach (var line in File.ReadLines(boardingGatesPath))
            {
                var parts = line.Split(',');
                if (parts.Length == 4 && bool.TryParse(parts[1].Trim(), out bool open))
                {
                    boardingGates.Add(new BoardingGate(parts[0].Trim(), open, bool.Parse(parts[2].Trim()), bool.Parse(parts[3].Trim())));
                }
            }
            Console.WriteLine("Boarding Gates Loaded: " + boardingGates.Count);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading boarding gates: " + ex.Message);
        }

        // Load flights
        Console.WriteLine("Loading Flights...");
        try
        {
            string flightsPath = Path.Combine(basePath, "flights.csv");
            foreach (var line in File.ReadLines(flightsPath))
            {
                var parts = line.Split(',');
                if (parts.Length >= 5 && airlines.ContainsKey(parts[1].Trim()))
                {
                    flights.Add(new Flight(
                        parts[0].Trim(),
                        airlines[parts[1].Trim()],
                        parts[2].Trim(),
                        parts[3].Trim(),
                        DateTime.Parse(parts[4].Trim())));
                }
            }
            Console.WriteLine("Flights Loaded: " + flights.Count);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading flights: " + ex.Message);
        }
    }
}
