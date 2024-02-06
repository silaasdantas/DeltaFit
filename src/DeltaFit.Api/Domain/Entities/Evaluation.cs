using DeltaFit.Api.Domain.Primitives;

namespace DeltaFit.Api.Domain.Entities
{
    public class Evaluation : Entity
    {
        public Guid TrainerId { get; set; }
        public Guid ClientId { get; set; }

        public Trainer Trainer { get; set; }
        public Client Client { get; set; }
    }
}
