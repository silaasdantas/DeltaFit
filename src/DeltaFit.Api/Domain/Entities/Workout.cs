using DeltaFit.Api.Domain.Primitives;

namespace DeltaFit.Api.Domain.Entities
{
    public class Workout : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Video> Videos { get; set; }
    }
}
