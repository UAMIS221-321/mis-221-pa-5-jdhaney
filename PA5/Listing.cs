namespace PA5
{
    public class Listing
    {
        internal readonly object ID;

        public int ListingID{ get; set;}
        public string TrainerName { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
    public decimal Cost { get; set; }
    public bool Taken { get; set; }
        public int Id { get; internal set; }

        public Listing(int id, string trainerName, DateTime date, TimeSpan time, decimal cost, bool taken)
    {
        ListingID = id;
        TrainerName = trainerName;
        Date = date;
        Time = time;
        Cost = cost;
        Taken = taken;
    }

        internal static void AddListing(Listing newListing)
        {
            throw new NotImplementedException();
        }

        internal static Listing GetListingById(int id)
        {
            throw new NotImplementedException();
        }

        internal static void EditListing(int id, Listing updatedListing)
        {
            throw new NotImplementedException();
        }

        internal static void DeleteListing(int id)
        {
            throw new NotImplementedException();
        }
    }
}