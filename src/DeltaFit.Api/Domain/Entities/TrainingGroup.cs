using DeltaFit.Api.Domain.Primitives;

namespace DeltaFit.Api.Domain.Entities
{
    public class TrainingGroup : Entity
    {
        public string Description { get; set; }
        public Guid TrainerId { get; set; }

        public Trainer Trainer { get; set; }
        public virtual ICollection<Workout> Workouts { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
