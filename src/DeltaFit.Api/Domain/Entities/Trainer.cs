using DeltaFit.Api.Domain.Primitives;
using Microsoft.AspNetCore.Identity;
using static DeltaFit.Api.Domain.Errors.DomainErrors;

namespace DeltaFit.Api.Domain.Entities
{
    public class Trainer : Entity
    {
       public Trainer(Guid id, Guid memberId, string nameOfWork)
           : base(id)
        {
            MemberId = memberId;
            NameOfWork = nameOfWork;
        }

        public Guid MemberId { get; set; }
        public string NameOfWork { get; set; }
        public string Document { get; set; }
        public string TypeDocument { get; set; }

        public Member Member { get; set; }
        public ICollection<Client> Clients { get; set; }
        public ICollection<Video> Videos { get; set; }
        public ICollection<Workout> Workouts { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }

    }
}
