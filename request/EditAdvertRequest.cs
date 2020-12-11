namespace gustav_v2.request
{
    public class EditAdvertRequest : BaseAuthRequest
    {
        public int Id { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public int Area { get; set; }
        public int Floor { get; set; }
        public int Rooms { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public string OwnerName { get; set; }
        public long OwnerPhone { get; set; }
    }
}