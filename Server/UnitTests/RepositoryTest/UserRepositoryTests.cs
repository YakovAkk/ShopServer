using DataDomain.Data.Sql.Models;
using Repositories.Repositories.Base;
using Xunit;

namespace UnitTests.RepositoryTest
{

    public class UserRepositoryTests
    {
        private BaseRepository<UserModel> _userRepositoryForTests;

        public UserRepositoryTests(BaseRepository<UserModel> baseRepository)
        {
            _userRepositoryForTests = baseRepository;
        }

        


    }
}
