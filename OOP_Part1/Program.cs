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
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
