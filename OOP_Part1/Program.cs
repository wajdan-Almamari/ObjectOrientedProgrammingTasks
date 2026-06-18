using System.Linq;
using System.Collections.Generic;
namespace OOP_Part1
{
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
        // Books an available room for a registered guest
        public static void BookRoomForGuest(List<Guest> guests, List<Room> rooms)
        {
            // Get guest ID and room number from the user
            Console.Write("Enter Guest Id: ");
            string guestId = Console.ReadLine();

            Console.Write("Enter Room Number: ");
            int roomNumber = int.Parse(Console.ReadLine());

            // Search for the guest and room using LINQ
            Guest foundGuest = guests.FirstOrDefault(g => g.GuestId == guestId);
            Room foundRoom = rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
            // Check if the guest exists
            if (foundGuest == null)
            {
                Console.WriteLine("Guest not found.");
            }

            // Check if the room exists
            else if (foundRoom == null)
            {
                Console.WriteLine("Room not found.");
            }

            // Check if the room is already booked
            else if (foundRoom.IsAvailable == false)
            {
                Console.WriteLine("Room is already booked.");
            }
            // Complete the booking process
            else
            {
                // Assign the room to the guest
                foundGuest.RoomNumber = foundRoom.RoomNumber.ToString();

                // Mark the room as unavailable
                foundRoom.IsAvailable = false;

                // Calculate the total stay cost
                double totalCost = foundGuest.CalculateTotalCost(foundRoom.PricePerNight);

                // Display booking confirmation
                Console.WriteLine("Booking Successful");
                Console.WriteLine("Guest Name: " + foundGuest.GuestName);
                Console.WriteLine("Total Cost: " + totalCost.ToString("0.00"));
                Console.WriteLine("Room Number: " + foundRoom.RoomNumber);
                Console.WriteLine("Room Type: " + foundRoom.RoomType);
                Console.WriteLine("Price Per Night: " + foundRoom.PricePerNight);
                Console.WriteLine("Total Nights: " + foundGuest.TotalNights); 
            }
        }
        public static void SearchFilterRoom(List <Room>rooms)
        {
            bool exit = false;
            while (exit == false)
            {
                Console.WriteLine("====================================");
                Console.WriteLine("SEARCH & FILTER ROOMS");
                Console.WriteLine("====================================");
                Console.WriteLine("1. Show all available rooms");
                Console.WriteLine("2. Filter by room type");
                Console.WriteLine("3. Filter by max price");
                Console.WriteLine("4. Room price statistics");
                Console.WriteLine("0. Back");
                Console.WriteLine("====================================");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Show all available rooms");

                        // Retrieve all available rooms and sort them by price
                        List<Room> availableRooms = rooms.Where(r => r.IsAvailable == true)
                                                          .OrderBy(r => r.PricePerNight)
                                                          .ToList();
                        // Display the total number of available rooms
                        Console.WriteLine("\nAvailable Rooms Count: " + availableRooms.Count);
                        if (availableRooms.Count == 0)
                        {
                            Console.WriteLine("No rooms found for the selected criteria.");
                        }
                        else
                        {
                            foreach (Room room in availableRooms)
                            {
                                room.DisplayRoom();
                            }
                        }
                        break;

                    case 2:
                        Console.WriteLine("Filter by room type");
                        Console.Write("Enter Room Type (Single / Double / Suite): ");
                        string roomType = Console.ReadLine();
                        // Retrieve rooms matching the selected type and sort by price
                        List<Room> filteredRooms = rooms.Where(r => r.RoomType.ToLower() == roomType.ToLower())
                                                        .OrderBy(r => r.PricePerNight)
                                                        .ToList();
                        // Display the number of matching rooms
                        Console.WriteLine("Matching Rooms Count: " + filteredRooms.Count);
                        if (filteredRooms.Count == 0)
                        {
                            Console.WriteLine("No rooms found for the selected criteria.");
                        }
                        else
                        {
                            foreach (Room room in filteredRooms)
                            {
                                room.DisplayRoom();
                            }
                        }
              
                        break;

                    case 3:
                        Console.WriteLine("Filter by max price");
                        // Filter available rooms by maximum price
                        Console.Write("Enter Maximum Price: ");
                        double maxPrice = double.Parse(Console.ReadLine());

                        // Retrieve available rooms within the price limit
                        List<Room> filterRooms = rooms
                            .Where(r => r.IsAvailable && r.PricePerNight <= maxPrice)
                            .OrderBy(r => r.PricePerNight)
                            .ToList();

                        // Display the number of matching rooms
                        Console.WriteLine("Matching Rooms Count: " + filterRooms.Count);
                        if (filterRooms.Count == 0)
                        {
                            Console.WriteLine("No rooms found for the selected criteria.");
                        }
                        else
                        {
                            // Display room details
                            foreach (Room room in filterRooms)
                            {
                                room.DisplayRoom();
                            }
                        }
                        break;

                    case 4:
                        Console.WriteLine("Room price statistics");
                        int totalRooms = rooms.Count;
                        int availableRoomsCount = rooms.Count(r => r.IsAvailable);
                        double averagePrice = Math.Round(rooms.Average(r=> r.PricePerNight),2);
                        double cheapestPrice = rooms.Min(r =>r.PricePerNight);
                        double expensivePrice = rooms.Max(r => r.PricePerNight);
                        Console.WriteLine("Room Price Statistics");
                        Console.WriteLine("=====================");
                        Console.WriteLine("Total Rooms: " + totalRooms);
                        Console.WriteLine("Available Rooms: " + availableRoomsCount);
                        Console.WriteLine("Average Price: " + averagePrice.ToString("0.00 OMR"));
                        Console.WriteLine("Cheapest Price: " + cheapestPrice.ToString("0.00 OMR"));
                        Console.WriteLine("Most Expensive Price: " + expensivePrice.ToString("0.00 OMR"));
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

            }//End of while
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
                        BookRoomForGuest(guests, rooms);
                        break;

                    case 4:
                        //Console.WriteLine("Search & Filter Rooms");
                        SearchFilterRoom(rooms,guests);
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
