using Anderson.MF7.Domain.Features.Users;

namespace Anderson.MF7.Common.Tests.Features.Users
{
    public static partial class ObjectMother
    {
        public static User GetValidUser()
        {
            return new User()
            {
                Id = 1,
                Username = "teste",
                Password = "teste",
            };
        }

        public static User GetInvalidUser()
        {
            return new User()
            {
                Id = 1,
                Username = "teste 2",
                Password = "teste2",
            };
        }
    }
}
