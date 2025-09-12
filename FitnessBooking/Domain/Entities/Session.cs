namespace FitnessBooking.Domain.Entities
{
    public class Session
    {
        public int Id { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; } = null!;

        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; } = null!;

        public string Title { get; set; } = string.Empty;

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
