namespace DeltaFit.Api.Domain.Entities
{
    public class TrainerVideo
    {
        public int Guid { get; set; }
        public int TrainerId { get; set; }
        public int VideoId { get; set; }
        public Trainer Trainer { get; set; }
        public Video Video { get; set; }
    }
}
