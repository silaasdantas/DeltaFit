using DeltaFit.Api.Domain.Primitives;

namespace DeltaFit.Api.Domain.Entities
{
    public class Client : Entity
    {
        public string Name { get; set; }
        public byte[] Photo { get; set; }
        public Guid TrainerId { get; set; }

        public Trainer Trainer { get; set; }
        public ICollection<TrainingGroup> TrainingGroups { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
        public ICollection<Evaluation> Evaluations { get; set; }
    }
}
