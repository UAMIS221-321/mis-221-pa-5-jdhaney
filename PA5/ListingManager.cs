namespace PA5
{
    public class ListingManager
    {
      private List<Listing> listings;
    private string filePath;

    public ListingManager(string filePath){
       this.filePath = filePath;
        LoadListings(); 
    }  
    private void LoadListings(){
        listings = new List<Listing>();

        if (File.Exists(filePath)){
          using (StreamReader reader = new StreamReader(filePath)){
            while (!reader.EndOfStream){
              string line = reader.ReadLine();
                    string[] parts = line.Split('#');

                    int id = int.Parse(parts[0]);
                    string trainerName = parts[1];
                    DateTime date = DateTime.Parse(parts[2]);
                    TimeSpan time = TimeSpan.Parse(parts[3]);
                    decimal cost = decimal.Parse(parts[4]);
                    bool taken = bool.Parse(parts[5]);

                    Listing listing = new Listing(id, trainerName, date, time, cost, taken);
                    listings.Add(listing);  
            }
          }  
        }
    }
    public void AddListing(Listing listing){
      listings.Add(listing);
        SaveListings();  
    }
    public void EditListing(int id, Listing updatedListing){
    Listing listing = GetListingById(id);

        if (listing != null){
            listing.ListingID = updatedListing.Id;
           listing.TrainerName = updatedListing.TrainerName;
            listing.Date = updatedListing.Date;
            listing.Time = updatedListing.Time;
            listing.Cost = updatedListing.Cost;
            listing.Taken = updatedListing.Taken;
            SaveListings(); 
        }
    }
    public void DeleteListing(int id){
      Listing listing = GetListingById(id);

        if (listing != null){
          listings.Remove(listing);
            SaveListings();   
        }  
    }
   public Listing GetListingById(int id){
    foreach (Listing listing in listings){
       if (listing.Id == id){
        return listing;
       } 
    }
    return null;
   } 
   private void SaveListings(){
    using (StreamWriter writer = new StreamWriter(filePath)){
        foreach (Listing listing in listings){
           writer.WriteLine($"{listing.Id},{listing.TrainerName},{listing.Date},{listing.Time},{listing.Cost},{listing.Taken}"); 
        }
    }
   }
}
}