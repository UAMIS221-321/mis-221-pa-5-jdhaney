namespace PA5
{
    public class TrainerManager
    {
        private List<Trainer> trainers = new List<Trainer>();
        private string filePath = "trainer.txt";

        public void AddTrainer(string id, string name, string address, string email){
            Trainer newTrainer = new Trainer(id, name, address, email);
            trainers.Add(newTrainer);
            SaveToFile();
        }
        public void EditTrainer(string id, string name, string address, string email){
            Trainer trainerToEdit = trainers.Find(t=> t.GetTrainerId() == id);
            if (trainerToEdit != null){
                trainerToEdit.SetTrainerName(name);
                trainerToEdit.SetMailingAddress(address);
                trainerToEdit.SetTrainerEmail(email);
                trainerToEdit.SetTrainerId(id);
                SaveToFile();
            }
        }
        public void DeleteTrainer(string id){
            trainers.RemoveAll(t => t.GetTrainerId() == id);
            SaveToFile();
        }
        private void SaveToFile(){
            using(StreamWriter writer = new StreamWriter(filePath)){
                foreach (Trainer trainer in trainers){
                    writer.WriteLine(trainer.GetTrainerId() + "#" + trainer.GetTrainerName() + "#" + trainer.GetMailingAddress() + "#" + trainer.GetTrainerEmail());
                }
            }
        }
    }
}