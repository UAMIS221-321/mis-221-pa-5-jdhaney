namespace PA5
{
    public class Session
    {
        public int Id { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
    public string TrainerId { get; set; }
    public string TrainerName { get; set; }
    public decimal Cost { get; set; }
    public string Status { get; set; }
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    }
}