namespace OOP_Part1
{
    // Room class stores hotel room information
    public class Room
    {
        public int RoomNumber { get; set; }
        public string RoomType { get; set; }
        public double PricePerNight { get; set; }
        public bool IsAvailable { get; set; }


        public Room(int roomNumber, string roomType,double pricePerNight, bool isAvailable)
        {
            RoomNumber = roomNumber;
            RoomType = roomType;
            PricePerNight = pricePerNight;
            IsAvailable = isAvailable;
        }

        // Displays room details
        public void DisplayRoom()
        {
            Console.WriteLine("Room Number: " + RoomNumber);
            Console.WriteLine("Room Type: " + RoomType);
            Console.WriteLine("Price Per Night: " + PricePerNight);
            Console.WriteLine("Available: " + IsAvailable);
        }

    }
    // Guest class stores guest information and booking details
    public class Guest
    {
        public string GuestId { get; set; }
        public string GuestName { get; set; }
        public string RoomNumber { get; set; }
        public string CheckInDate { get; set; }
        public int TotalNights { get; set; }

        // Constructor initializes guest details
        public Guest(string guestId, string guestName, string roomNumber, string checkInDate,  int totalNights)
        {
            GuestId = guestId;
            GuestName = guestName;
            RoomNumber = roomNumber;
            CheckInDate = checkInDate;
            TotalNights = totalNights;
        }

        // Displays guest details
        public void DisplayGuest()
        {
            Console.WriteLine("Guest ID: " + GuestId);
            Console.WriteLine("Guest Name: " + GuestName);
            Console.WriteLine("Room Number: " + RoomNumber);
            Console.WriteLine("Check-In Date: " + CheckInDate);
            Console.WriteLine("Total Nights: " + TotalNights);
        }
    }
   
    internal class Program
    {
        // Displays the main menu
        public static void MainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("================================================");
            Console.WriteLine("        GRAND VISTA HOTEL - MANAGEMENT SYSTEM");
            Console.WriteLine("================================================");
            Console.WriteLine("  1. Add New Room");
            Console.WriteLine("  2. Register New Guest");
            Console.WriteLine("  3. Book a Room for a Guest");
            Console.WriteLine("  4. Search & Filter Rooms");
            Console.WriteLine("  5. Guest & Booking Statistics");
            Console.WriteLine("  6. Check Out a Guest");
            Console.WriteLine("  7. Remove Unavailable Rooms");
            Console.WriteLine("  0. Exit");
            Console.WriteLine("================================================");
            Console.Write("Enter your choice: ");
        }
        // Case1 - Add New Room
        public static void AddNewRoom(List<Room> rooms)
        {
            Console.WriteLine("Add New Room");
            Console.Write("Enter Room Number : ");
            int roomNumber = int.Parse(Console.ReadLine());

            Console.Write("Enter Room Type (Single / Double / Suite): ");
            string roomType = Console.ReadLine();

            Console.Write("Enter Price Per Night: ");
            double pricePerNight = double.Parse(Console.ReadLine());

            // Validate that room number and price are positive
            if (roomNumber <= 0 || pricePerNight <= 0)
            {
                Console.WriteLine("Please enter positive numbers");
            }
            // Check if the room number already exists
            else if (rooms.Any(r => r.RoomNumber == roomNumber))
            {
                Console.WriteLine("Error: Room number already exists.");
            }
            else
            {
                // Create and add the new room
                Room newRoom = new Room(roomNumber, roomType, pricePerNight, true);

                rooms.Add(newRoom);
                Console.WriteLine("Room added successfully.");
                Console.WriteLine("Total Rooms: " + rooms.Count);
                newRoom.DisplayRoom();
            }
        }
        // Register a new guest in the system
        public static void RegisterNewGuest(List<Guest> guests)
        {
            Console.Write("Enter Guest Name: ");
            string guestName = Console.ReadLine();
            Console.Write("Enter Check-In Date: ");
            string checkInDate = Console.ReadLine();
            Console.Write("Enter Total Nights: ");
            int totalNights = int.Parse(Console.ReadLine());

            // Number of nights must be validated as a positive integer.
            if (totalNights <= 0)
            {
                Console.WriteLine("Please enter a positive number of nights.");
                return;
            }
            //guests list (format: G001, G002, G003 ...).
            string guestId = "G" + (guests.Count + 1).ToString("000");

            Guest newGuest = new Guest( guestId, guestName,"Not Assigned", checkInDate, totalNights);

            guests.Add(newGuest);

            Console.WriteLine("Guest registered successfully.");
            newGuest.DisplayGuest();
        }
            static void Main(string[] args)
        {
            //System Lists
            List<Room> rooms = new List<Room>();
            rooms.Add(new Room(101, "Single", 25, true));
            rooms.Add(new Room(102, "Single", 30, true));
            rooms.Add(new Room(201, "Double", 45, true));
            rooms.Add(new Room(202, "Double", 50, true));
            rooms.Add(new Room(301, "Suite", 80, true));
            rooms.Add(new Room(302, "Suite", 95, true));
            List<Guest> guests = new List<Guest>();

            bool exit = false;
            while (exit==false)
            {
                MainMenu();
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddNewRoom(rooms);
                        break;

                    case 2:
                        Console.WriteLine("Register New Guest");
                        RegisterNewGuest(guests);
                        break;

                    case 3:
                        Console.WriteLine("Book a Room for a Guest");
                        Console.Write("Enter Guest Id: ");
                        int guestId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Room Number: ");
                        int roomNumber = int.Parse(Console.ReadLine());

                        Guest foundGuest = guests.FirstOrDefault(g => g.GuestId == guestId);
                        break;

                    case 4:
                        Console.WriteLine("Search & Filter Rooms");
                        break;

                    case 5:
                        Console.WriteLine("Guest & Booking Statistics");
                        break;

                    case 6:
                        Console.WriteLine("Check Out a Guest");
                        break;

                    case 7:
                        Console.WriteLine("Remove Unavailable Rooms");
                        break;

                    case 0:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
               
                Console.WriteLine("Enter any key to continue ..");
                Console.ReadKey();
                Console.Clear();
            }//End of While
           
        }
    }
}
