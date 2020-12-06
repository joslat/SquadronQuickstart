using Xunit;
using Squadron;
using System.Threading.Tasks;

namespace SquadronQuickstart
{
    public class AccountRepositoryTests
        : IClassFixture<MongoResource>
    {
        private readonly MongoResource _mongoResource;

        public AccountRepositoryTests(
            MongoResource mongoResource)
        {
            _mongoResource = mongoResource;
        }

        [Fact]
        public async Task Repository_WhenAddingAndRetrievingUser_WeGetAMatchingUser()
        {
            //arrange
            var user = User.CreateSample();
            var db = _mongoResource.CreateDatabase();
            var repo = new UserRepository(db);

            //act
            await repo.AddAsync(user);
            User createdUser = await repo.GetUserAsync(user.Id);

            //assert
            Assert.Equal(user.Email, createdUser.Email);
        }
    }
}
