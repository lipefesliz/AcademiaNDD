using Anderson.MF7.Application.Mapping;
using NUnit.Framework;

namespace Anderson.MF7.Application.Tests.Initializer
{
    [TestFixture]
    public class TestServiceBase
    {
        [OneTimeSetUp]
        public void InitializeOnceTime()
        {
            AutoMapperInitializer.Reset();
            AutoMapperInitializer.Initialize();
        }
    }
}
