using DeltaFit.Api.Domain.Entities;
using DeltaFit.Api.Infrastructure.Cryptography;

namespace DeltaFit.UnitTest
{
    public class JornadaProfessor
    {
        [Fact]
        public void DeveCadastrarUmProfessor()
        {
            var password = "123@asd";
            var criptography = Hashing.DoCompute(password);
            var member = new Member(Guid.NewGuid(), "alex@hotmail.com", "Alex", "Encore", criptography.Hash, criptography.Salt);
            var professor = new Trainer(Guid.NewGuid(), member.Id, "Alex Encore");
            
            Assert.NotNull(professor);
        }
    }
}