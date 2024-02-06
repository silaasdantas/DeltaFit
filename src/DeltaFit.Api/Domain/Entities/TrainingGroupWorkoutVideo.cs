using DeltaFit.Api.Domain.Primitives;

namespace DeltaFit.Api.Domain.Entities
{
    public class TrainingGroupWorkoutVideo: Entity
    {
        public int ExerciseTrainingId { get; set; }
        public TrainingGroupWorkout ExerciseTraining { get; set; }
        public virtual ICollection<Video> Video { get; set; }
    }
}
