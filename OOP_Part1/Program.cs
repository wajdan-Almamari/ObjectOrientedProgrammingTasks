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
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
