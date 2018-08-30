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
                Name = "teste",
                Password = "teste",
                Email = "teste@teste.com"
            };
        }

        public static User GetInvalidUser()
        {
            return new User()
            {
                Id = 1,
                Name = "teste 2",
                Password = "teste2",
                Email = "teste2@teste.com"
            };
        }
    }
}
