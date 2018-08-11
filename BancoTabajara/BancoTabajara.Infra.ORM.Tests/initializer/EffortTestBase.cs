using Effort.Provider;
using NUnit.Framework;

namespace BancoTabajara.Infra.ORM.Tests.initializer
{
    [TestFixture]
    public class EffortTestBase
    {
        [OneTimeSetUp]
        public void InitializeOnTime()
        {
            EffortProviderConfiguration.RegisterProvider();
        }

        [SetUp]
        public void initialize()
        {
            EffortProviderFactory.ResetDb();
        }
    }
}
