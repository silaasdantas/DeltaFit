using Azure.Core;
using DeltaFit.Api.Application.Members.Commands.CreateMember;
using DeltaFit.Api.Domain.Entities;
using DeltaFit.Api.Domain.Repositories;
using DeltaFit.Api.Domain.Shared;
using DeltaFit.Api.Infrastructure.Cryptography;
using Moq;

namespace DeltaFit.UnitTest
{
    public class JornadaProfessor
    {
        [Fact]
        public void CreateMemberCommandHandler_DeveCriarUmMembro()
        {
            //Arrange
            Mock<IMemberRepository> memberRepositorymock = new Mock<IMemberRepository>();
            Mock<IUnitOfWork> UnitOfWorkmock = new Mock<IUnitOfWork>();
            //CreateMemberCommand requestMock = 


            //var password = "123@asd";
            //var criptography = Hashing.DoCompute(password);


            //var member = new Member(Guid.NewGuid(), "alex@hotmail.com", "+5511978017890", "Alex", "Encore", criptography.Hash, criptography.Salt);
            //var professor = new Trainer(Guid.NewGuid(), member.Id, "Alex Encore");

            //Assert.NotNull(professor);
        }
    }
}