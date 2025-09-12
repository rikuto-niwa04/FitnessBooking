namespace FitnessBooking.Domain.Entities
{
    public class TrainingSession
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int TrainerId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
