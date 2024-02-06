using DeltaFit.Api.Domain.Primitives;

namespace DeltaFit.Api.Domain.Entities
{
    public class Feedback : Entity
    {
        public string Message { get; set; }
        public Guid? TrainingId { get; set; }
        public Guid? WorkoutId { get; set; }

        public TrainingGroup TrainingGroup { get; set; }
        public Workout Workout { get; set; }

    }
}
