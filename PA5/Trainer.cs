namespace PA5
{
    public class Trainer
    {
        private string trainerId;
        private string trainerName;
        private string mailingAddress;
        private string trainerEmail;


        public Trainer(string id, string name, string address, string email){
           trainerId = id;
           trainerName = name;
           mailingAddress = address;
           trainerEmail = email;
    }
    public void SetTrainerId(string id){
        trainerId = id;
    }
    public string GetTrainerId(){
        return trainerId;
    }
    public void SetTrainerName(string name){
        trainerName = name;
    }
    public string GetTrainerName(){
        return trainerName;
    }
    public void SetMailingAddress(string address){
        mailingAddress = address;
    }
    public string GetMailingAddress(){
        return mailingAddress;
    }
    public void SetTrainerEmail(string email){
        trainerEmail = email;
    }
    public string GetTrainerEmail(){
        return trainerEmail;
    }
}
}