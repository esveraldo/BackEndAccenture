using Bogus;
using FluentAssertions;
using Log.Accenture.Domain.Entities;
using Log.Accenture.Domain.Interfaces.Repositories;
using Xunit;

namespace Log.Accenture.UnitTests.Repositories
{
    public class LogSystemRepositoryTest
    {
        private readonly ILogSystemRepository _logSystemRepository;

        public LogSystemRepositoryTest(ILogSystemRepository logSystemRepository)
        {
            _logSystemRepository = logSystemRepository;
        }

        [Fact]
        public void TestCreate()
        {
            var log = CreateLog();

            var logById = _logSystemRepository.GetById(log.Id);

            logById.Should().NotBeNull();
            logById.Description.Should().Be(log.Description);
        }

        [Fact]
        public void TestUpdate()
        {
            var log = CreateLog();

            
            _logSystemRepository.Update(log);

            var logById = _logSystemRepository.GetById(log.Id);

            logById.Should().NotBeNull();
            logById.Description.Should().Be(log.Description);
        }

        [Fact]
        public void TestDelete()
        {
            var log = CreateLog();

            _logSystemRepository.Delete(log);

            var logById = _logSystemRepository.GetById(log.Id);

            logById.Should().BeNull();
        }

        [Fact]
        public void TestGetAll()
        {
            var log = CreateLog();

            var lista = _logSystemRepository.GetAll();

            lista.FirstOrDefault(u => u.Id.Equals(log.Id)).Should().NotBeNull();
        }

        [Fact]
        public void TestGetById()
        {
            var log = CreateLog();

            var logById = _logSystemRepository.GetById(log.Id);

            logById.Should().NotBeNull();
            logById.Description.Should().Be(log.Description);
        }

        [Fact]
        public void TestGetByPredicate()
        {
            var log = CreateLog();

            var logByPredicate = _logSystemRepository.Get(x => x.Description.Equals(log.Description));

            logByPredicate.Should().NotBeNull();
        }

        private LogSystem CreateLog()
        {
            var faker = new Faker("pt_BR");

            var logSystem = new LogSystem
            {
                Id = Guid.NewGuid(),
                Description = "pam_unix(cron:session): session closed for user root",
            };

            _logSystemRepository.Create(logSystem);
            return logSystem;
        }
    }
}
