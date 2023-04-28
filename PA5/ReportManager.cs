namespace PA5
{
    public class ReportManager
    {
      private string _transactionsFilePath;
    private List<Session> _sessions;

    public ReportManager(string transactionFilePath){
        _transactionsFilePath = transactionFilePath;
        LoadSessions();
    }
     private void LoadSessions(){
        _sessions = new List<Session>();
       if (File.Exists(_transactionsFilePath)){
        using (StreamReader reader = new StreamReader(_transactionsFilePath)){
            string line;
                while ((line = reader.ReadLine()) != null){
                   string[] parts = line.Split('#');
                    Session session = new Session{
                       Id = int.Parse(parts[0]),
                        Date = DateTime.Parse(parts[1]),
                        Time = TimeSpan.Parse(parts[2]),
                        TrainerId = parts[3],
                        TrainerName = parts[4],
                        Cost = decimal.Parse(parts[5]),
                        Status = parts[6],
                        CustomerName = parts[7],
                        CustomerEmail = parts[8] 
                    }; 
                 _sessions.Add(session);   
                }
        }
       } 
     }
       public List<Session> GetSessionsForCustomer(string customerEmail){
        return _sessions.FindAll(session => session.CustomerEmail == customerEmail);
       }
       public void GenerateHistoricalCustomerSessionsReport(){
        var groupedSessions = _sessions.OrderBy(session => session.Date)
                                        .GroupBy(session => session.CustomerEmail);
        foreach (var group in groupedSessions){
         Console.WriteLine($"Customer: {group.First().CustomerName} ({group.Key})");
            int count = 0;
            foreach (Session session in group){
             count++;
                Console.WriteLine($"- Session {count}: {session.Date.ToShortDateString()} {session.Time} with {session.TrainerName}, Status: {session.Status}, Cost: {session.Cost}");   
            } 
         Console.WriteLine($"Total sessions: {count}\n");     
        }
       }
       public void GenerateHistoricalRevenueReport(){
        var groupedSessions = _sessions.GroupBy(session => new { session.Date.Year, session.Date.Month })
                                        .Select(group => new {
                                            Year = group.Key.Year,
                                            Month = group.Key.Month,
                                            Revenue = group.Sum(session => session.Cost)
       });
      foreach (var group in groupedSessions){
        Console.WriteLine($"{group.Year}/{group.Month} Revenue: {group.Revenue:C}");
      } 
    }
    public void SaveReportToFile(string reportText){
        using (StreamWriter writer = new StreamWriter("report.txt")){
           writer.Write(reportText); 
        }
    }

}
}