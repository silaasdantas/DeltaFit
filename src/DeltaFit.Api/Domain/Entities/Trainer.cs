using DeltaFit.Api.Domain.Primitives;

namespace DeltaFit.Api.Domain.Entities
{
    public class Trainer : Entity
    {
        public ICollection<Client> Clients { get; set; }
        public ICollection<Video> Videos { get; set; }
        public ICollection<Workout> Workouts { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }

    }
}
