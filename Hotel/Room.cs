namespace Hotel
{
    public class Room
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public int Quadrahtmeter { get; set; }
        public decimal Preis { get; set; }
        public bool IstGebucht { get; set; }
        public Category Kategorie { get; set; }
    }
}