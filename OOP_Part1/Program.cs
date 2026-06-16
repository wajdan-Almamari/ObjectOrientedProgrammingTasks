namespace OOP_Part1
{
    internal class Program
    {
        // Room class stores hotel room information
        public class Room
        {
            public int RoomNumber { get; set; }
            public string RoomType { get; set; }
            public double PricePerNight { get; set; }
            public bool IsAvailable { get; set; }

        }
        // Guest class stores guest information and booking details
        public class Guest
        {
            public string GuestId { get; set; }
            public string GuestName { get; set; }
            public string RoomNumber { get; set; }
            public string CheckInDate { get; set; }
            public int TotalNights { get; set; }
        }
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

        static void Main(string[] args)
        {
            //System Lists
            List<Room> rooms = new List<Room>();
            List<Guest> guests = new List<Guest>();

            bool exit = false;
            while (exit==false)
            {
                MainMenu();
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Add New Room");
                        break;

                    case 2:
                        Console.WriteLine("Register New Guest");
                        break;

                    case 3:
                        Console.WriteLine("Book a Room for a Guest");
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
