namespace PA5
{
    public class SessionManager
    {
        private string _transactionsFilePath;
    private List<Session> _sessions;

    public SessionManager(string transactionFilePath){
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
                        Status = parts[6]   
                    };  
                 _sessions.Add(session);    
                }   
        }    
        }
    }
    public List<Session> GetAvailableSessions(){
      return _sessions.FindAll(session => session.Status == "Booked");  
    }
    public void BookSession(Session session, string customerName, string customerEmail){
        session.Status = "Completed";
        session.Cost = 50.00m;
        _sessions.Add(session);
        using (StreamWriter writer = new StreamWriter(_transactionsFilePath, true)){
            writer.WriteLine($"{session.Id}|{session.Date}|{session.Time}|{session.TrainerId}|{session.TrainerName}|{session.Cost}|{session.Status}|{customerName}|{customerEmail}");
        }
    }
    public void CancelSession(int sessionId){
       Session session = _sessions.Find(s => s.Id == sessionId);
        session.Status = "Cancelled"; 

        using (StreamWriter writer = new StreamWriter(_transactionsFilePath)){
          foreach (Session s in _sessions){
           writer.WriteLine($"{s.Id}|{s.Date}|{s.Time}|{s.TrainerId}|{s.TrainerName}|{s.Cost}|{s.Status}"); 
          }  
        }
    }
    }

}