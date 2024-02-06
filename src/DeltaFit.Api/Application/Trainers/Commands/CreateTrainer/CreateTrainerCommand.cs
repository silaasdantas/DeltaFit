using DeltaFit.Api.Application.Abstractions.Messaging;

namespace DeltaFit.Api.Application.Trainers.Commands.CreateTrainer
{
    public sealed record CreateTrainerCommand(
      string NameOfWork,
      string TypeDocument,
      string Document,
      string Cnpj) : ICommand<Guid>;
}
