using DeltaFit.Api.Domain.Primitives;

namespace DeltaFit.Api.Domain.Entities
{
    public class TrainingGroupWorkout : Entity
    {
        public Guid TrainingGroupId { get; set; }
        public Guid WorkoutId { get; set; }

        public TrainingGroup TrainingGroup { get; set; }
        public Workout Workout { get; set; }
    }
}
