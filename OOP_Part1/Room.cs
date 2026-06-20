using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Part1
{
    // Room class stores hotel room information
    public class Room
    {
        public int RoomNumber { get; set; }
        public string RoomType { get; set; }
        public double PricePerNight { get; set; }
        public bool IsAvailable { get; set; }


        public Room(int roomNumber, string roomType, double pricePerNight, bool isAvailable)
        {
            RoomNumber = roomNumber;
            RoomType = roomType;
            PricePerNight = pricePerNight;
            IsAvailable = isAvailable;
        }

        // Displays room details
        public void DisplayRoom()
        {
            Console.WriteLine();
            Console.WriteLine($"Room Number: {RoomNumber} | Room Type: {RoomType} | Price Per Night: {PricePerNight:0.00} OMR | Available: {IsAvailable}");
            Console.WriteLine();

        } 

    }
}
