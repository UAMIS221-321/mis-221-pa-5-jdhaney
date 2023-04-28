//Main
using PA5;

static void Main(string[] args){
    bool exit = false;
    while(!exit){
        Console.WriteLine("Welcome to the TLAC management system!");
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. Manage trainer data");
            Console.WriteLine("2. Manage listing data");
            Console.WriteLine("3. Manage customer booking data");
            Console.WriteLine("4. Run reports");
            Console.WriteLine("5. Exit");
         int choice = int.Parse(Console.ReadLine()); 

         switch(choice){
            case 1:
                ManageTrainerData();
                break;
             case 2:
                    ManageListingData();
                    break;
                case 3:
                    ManageBookingData();
                    break;
                case 4:
                    RunReports();
                    break;
                case 5:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
         }   
    }
    Console.WriteLine("Exiting the application. Goodbye!");
}
//End Main

static void ManageTrainerData(){
Console.WriteLine("You chose to manage trainer data.");
    PA5.TrainerManager manager = new PA5.TrainerManager();
manager.AddTrainer("T001", "John Doe", "123 Main St.", "Jdoe@gmail.com");
manager.EditTrainer("T001", "Jane Doe", "456 Main St.", "jane@example.com");
manager.DeleteTrainer("T001");
}

static void ManageListingData(){
Console.WriteLine("You chose to manage listing data.");
    //create new listing
    PA5.Listing newListing = new PA5.Listing(1, "John Doe", DateTime.Now, TimeSpan.FromHours(1), 50.00m, false);
    Listing.AddListing(newListing);

    //Edit listing
    int id = 1;
        Listing updatedListing = Listing.GetListingById(id);
        updatedListing.TrainerName = "Jane Smith";
        Listing.EditListing(id, updatedListing);
    
    //Delete an existing listing
    id = 1;
    Listing.DeleteListing(id);
}

static void ManageBookingData(){
    Console.WriteLine("You chose to manage customer booking data.");
    SessionManager sessionManager = new SessionManager("transactions.txt");
    //View available sessions
    List<Session> availableSessions = sessionManager.GetAvailableSessions();
foreach (Session session in availableSessions){
  Console.WriteLine($"ID: {session.Id}, Date: {session.Date.ToShortDateString()}, Time: {session.Time}, Trainer: {session.TrainerName}, Cost: {session.Cost}");  
}
// Book a session
Session selectedSession = availableSessions[0];
string customerName = "Jane Doe";
}

static void RunReports(){
    Console.WriteLine("You chose to run reports.");
    ReportManager reportManager = new ReportManager("transaction.txt");
    // Generate report of individual customer sessions
    string customerEmail = "jane.doe@example.com";
        var sessions = reportManager.GetSessionsForCustomer(customerEmail);
        Console.WriteLine($"Sessions for customer {customerEmail}:");
        foreach (Session session in sessions){
           Console.WriteLine($"- {session.Date.ToShortDateString()} {session.Time} with {session.TrainerName}, Status: {session.Status}, Cost: {session.Cost}");
        }
        Console.WriteLine();

        //Generate a report of historical customer sessions
        reportManager.GenerateHistoricalCustomerSessionsReport();

        // Generate a report of historical revenue
        reportManager.GenerateHistoricalRevenueReport();
        reportManager.SaveReportToFile("Historical revenue report generated on " + DateTime.Now.ToString());
}